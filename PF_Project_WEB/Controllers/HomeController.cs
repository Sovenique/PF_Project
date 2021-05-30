using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PF_Project_CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PF_Project_WEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<Member> _userManager;
        private readonly SignInManager<Member> _signInManager;
        public HomeController(UserManager<Member> userManager, SignInManager<Member> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            ViewBag.userid = _userManager.GetUserId(HttpContext.User);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }
}
