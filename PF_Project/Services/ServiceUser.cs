using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using PF_Project_CORE.Interfaces;

namespace PF_Project_CORE.Services
{
    public class ServiceUser : IServiceUser
    {
        private readonly IHttpContextAccessor _httpContext;
        public ServiceUser(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }


        public string GetUserId()
        {
            return _httpContext
                .HttpContext.User?
                .FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }

}