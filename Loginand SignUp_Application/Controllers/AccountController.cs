
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Loginand_SignUp_Application.Models;
using System.Web.Security;

namespace Loginand_SignUp_Application.Controllers
{
	[AllowAnonymous]
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

		[HttpPost]
		public ActionResult Login(Models.Membership model)
		{
			using (var context = new OfficeEntities1())
			{
				bool isValid = context.User.Any(x => x.UserName == model.UserName && x.Password == model.Password);
				if (isValid) {

					FormsAuthentication.SetAuthCookie(model.UserName, false);
					return RedirectToAction("Index","Employees");
				}

				ModelState.AddModelError("","Invalid UserName and Password");
				return View();
			}
				
		}

		// GET: Account
		public ActionResult Signup()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Signup(User model)
		{
			using (var context = new OfficeEntities1()) {

				context.User.Add(model);
				context.SaveChanges(); 
			}
				return RedirectToAction("Login"); 
		}

		public ActionResult Logout()
        {
			FormsAuthentication.SignOut();
			return RedirectToAction("Login");
		}
	}
}