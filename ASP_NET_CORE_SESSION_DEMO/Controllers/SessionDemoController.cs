using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP_NET_CORE_SESSION_DEMO.HelperClass;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;

namespace ASP_NET_CORE_SESSION_DEMO.Controllers
{
    public class SessionDemoController : BaseController
    {
        public IActionResult Index()
        {

            // CASE 3 >> GET session on different controller.
            var str_val = Session.Get<string>(Constants.key_string);
            var int_val = Session.Get<int>(Constants.key_int);
            var obj_val = Session.Get<Student>(Constants.key_object);

            Assert.AreEqual("Ravi", str_val);
            Assert.AreEqual(int.MaxValue, int_val);
            if (obj_val == null)
                Assert.AreEqual(true, false, "Object with session not working");

            return View();
        }
    }

    [Serializable]
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
