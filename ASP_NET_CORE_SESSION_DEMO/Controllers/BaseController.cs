using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace ASP_NET_CORE_SESSION_DEMO.Controllers
{
    public class BaseController : Controller
    {
        public BaseController() { }

        public BaseController(IConfiguration config, IHttpContextAccessor httpContextAccessor)
        {

        }

        public ISession Session { get => this.HttpContext.Session; }

        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
