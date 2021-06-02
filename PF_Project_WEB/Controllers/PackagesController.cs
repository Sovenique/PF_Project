using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PF_Project_CORE.Entities;
using PF_Project_CORE.Interfaces;
using PF_Project_CORE.Options;
using PF_Project_WEB.Services;

namespace PF_Project_WEB.Controllers
{
    public class PackagesController : Controller
    {

        private readonly ICurrentUserService _currentUserService;
        private readonly IApplicationDbContext _context;
        private readonly IServicePackage _servicePackage;
        private readonly IServiceProject _serviceProject;
      
       
        public PackagesController(ICurrentUserService currentUserService,
                  IApplicationDbContext context,
                  IServicePackage servicePackage,
                  IServiceProject serviceProject)
        
        {
            _currentUserService = currentUserService;
            _context = context;
            _servicePackage = servicePackage;
            _serviceProject = serviceProject;
        }


        // GET: Packages
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Packages.Include(p => p.Project);
            return View(await applicationDbContext.ToListAsync());
        }

        // Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var package = await _context.Packages
                .Include(p => p.Project)
                .FirstOrDefaultAsync(m => m.Id == id);
           
            if (package == null)
            {
                return NotFound();
            }
            return View(package);
        }


        public IActionResult Create()
        {
            var Id = _currentUserService.UserId;
            var projects = _serviceProject.GetAllProjects();
            var currentProjects = projects.Where(x => x.CreatorId == Id).ToList();
            ViewBag.ProjectId = new SelectList(currentProjects, "Id", "Id");
            return View();
        }

        // Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,Value,ProjectId")] Package package)
        {
            var Id = _currentUserService.UserId;
            var projects = _serviceProject.GetAllProjects();
            var currentProjects = projects.Where(x => x.CreatorId == Id).ToList();

            ViewBag.ProjectId = new SelectList(currentProjects, "Id", "Id", package.Id);

            if (ModelState.IsValid)
            {
                _servicePackage.CreatePackage(new OptionPackage
                {
                    Title = package.Title,
                    Description = package.Description,
                    Value = package.Value,
                    ProjectId = package.ProjectId
                });
            }
            return View(package);
        }

        // Edit Id
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var package = await _context.Packages.FindAsync(id);
            if (package == null)
            {
                return NotFound();
            }
            ViewData["ProjectId"] = new SelectList(_context.Projects, "Id", "Id", package.ProjectId);
            return View(package);
        }

        // Edit

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,Value,ProjectId")] Package package)
        {
            if (id != package.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Packages.Update(package);
                    await _context.SaveChangesAsync();
                }
               
                catch (DbUpdateConcurrencyException)
                {
                    if (!PackageExists(package.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
           
            }
            ViewData["ProjectId"] = new SelectList(_context.Projects, "Id", "Id", package.ProjectId);
            return View(package);
        }

        // Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var package = await _context.Packages
                .Include(p => p.Project)
                .FirstOrDefaultAsync(m => m.Id == id);
           
            if (package == null)
            {
                return NotFound();
            }

            return View(package);
        }

        // Delete Confirmed
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var package = await _context.Packages.FindAsync(id);
            _context.Packages.Remove(package);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PackageExists(int id)
        {
            return _context.Packages.Any(e => e.Id == id);
        }
    }
}
