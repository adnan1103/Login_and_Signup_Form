using CodeFirstSignup_Login.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;
using System.Web.Security;
using CodeFirstSignup_Login.ViewModel;

namespace CodeFirstSignup_Login.Controllers
{
    public class AccountsController : Controller
    {
		[HttpGet]
		public ActionResult Login()
		{
			return View();
		}

		[HttpPost, ValidateAntiForgeryToken]
		public ActionResult Login(Login login)
		{
			if (ModelState.IsValid)
			{
				bool isAuthenticated = WebSecurity.Login(login.UserName, login.UserPassword, login.RememberMe);

				if (isAuthenticated)
				{
					string returnUrl = Request.QueryString["ReturnUrl"];

					if (returnUrl == null)
					{
						return RedirectToAction("Index", "Dashboard");
					}
					else
					{
						return Redirect(Url.Content(returnUrl));
					}

				}
				else
				{
					ModelState.AddModelError("", "User Name or Password are invalid.");
				}
			}
			return View();
		}

		public ActionResult LogOut()
		{
			WebSecurity.Logout();
			return RedirectToAction("Login", "Accounts");
		}

		[HttpGet]
		[Authorize(Roles = "Administrator, Manager")]
		public ActionResult Registar()
		{
			GetRolesForCurrentUser();

			return View();
		}

		private void GetRolesForCurrentUser()
		{
			if (Roles.IsUserInRole(WebSecurity.CurrentUserName, "Administrator"))
				ViewBag.RoleId = (int)Role.Administrator;
			else
				ViewBag.RoleId = (int)Role.NoRole;
		}

		[HttpPost, ValidateAntiForgeryToken]
		[Authorize(Roles = "Administrator, Manager")]
		public ActionResult Registar(Registar registar)
		{
			GetRolesForCurrentUser();

			if (ModelState.IsValid)
			{
				bool isUserExists = WebSecurity.UserExists(registar.UserName);

				if (isUserExists)
				{
					ModelState.AddModelError("UserName", "User Name already exists");
				}
				else
				{
					WebSecurity.CreateUserAndAccount(registar.UserName, registar.Password, new { FullName = registar.FullName, Email = registar.Email });
					Roles.AddUserToRole(registar.UserName, registar.Role);

					return RedirectToAction("Index", "Dashboard");
				}
			}

			return View();
		}

		[HttpGet, Authorize]
		public ActionResult ChangePassword()
		{
			return View();
		}

		[HttpPost, Authorize, ValidateAntiForgeryToken]
		public ActionResult ChangePassword(ChangePassword changePassword)
		{
			if (ModelState.IsValid)
			{
				bool isPasswordChanged = WebSecurity.ChangePassword(WebSecurity.CurrentUserName, changePassword.OldPassword, changePassword.NewPassword);

				if (isPasswordChanged)
				{
					return RedirectToAction("Index", "Dashboard");
				}
				else
				{
					ModelState.AddModelError("", "Old Password is not correct");
				}
			}
			return View();
		}

		[HttpGet, Authorize]
		public ActionResult UserProfile()
		{
			UserProfile userProfile = AccountViewModel.GetUserProfileData(WebSecurity.CurrentUserId);
			return View(userProfile);
		}

		[HttpPost, Authorize, ValidateAntiForgeryToken]
		public ActionResult UserProfile(UserProfile userProfile)
		{
			if (ModelState.IsValid)
			{
				AccountViewModel.UpdateUserProfile(userProfile);
				ViewBag.Message = "Profile is saved successfully";
			}
			return View();
		}

	}
}