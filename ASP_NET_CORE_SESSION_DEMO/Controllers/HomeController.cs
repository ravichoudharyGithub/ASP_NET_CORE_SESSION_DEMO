using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ASP_NET_CORE_SESSION_DEMO.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using ASP_NET_CORE_SESSION_DEMO.HelperClass;
using NUnit.Framework;

namespace ASP_NET_CORE_SESSION_DEMO.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            // Set session
            Session.Set(Constants.key_string, "Ravi");
            Session.Set(Constants.key_int, int.MaxValue);

            var stobj = new Student
            {
                Id = 1,
                Name = "Ravi"
            };

            Session.Set(Constants.key_object, stobj);


            // CASE 1 >> GET session on same action.
            var str_val = Session.Get<string>(Constants.key_string);
            var int_val = Session.Get<int>(Constants.key_int);
            var obj_val = Session.Get<Student>(Constants.key_object);

            Assert.AreEqual("Ravi", str_val);
            Assert.AreEqual(int.MaxValue, int_val);
            if (obj_val == null)
                Assert.AreEqual(true, false, "Object with session not working");


            return View();
        }

        public IActionResult Privacy()
        {
            // CASE 2 >> GET session on same controller and different action.
            var str_val = Session.Get<string>(Constants.key_string);
            var int_val = Session.Get<int>(Constants.key_int);
            var obj_val = Session.Get<Student>(Constants.key_object);

            Assert.AreEqual("Ravi", str_val);
            Assert.AreEqual(int.MaxValue, int_val);
            if (obj_val == null)
                Assert.AreEqual(true, false, "Object with session not working");

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
