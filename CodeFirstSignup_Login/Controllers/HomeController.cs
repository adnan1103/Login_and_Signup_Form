using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeFirstSignup_Login.Controllers
{
    public class Home1Controller : Controller
    {
		public ActionResult Index()
		{
			return RedirectToAction("Login", "Accounts");
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
	}
}