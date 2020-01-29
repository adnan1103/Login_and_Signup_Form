using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewBag.Models;

namespace ViewBag.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
			List<Employee> emp = new List<Employee>
			{
				new Employee(){ Name="Ali",Id=1, Email="ali12@gmail.com"},
				new Employee(){ Name="Ali1",Id=2, Email="ali123@gmail.com"},
				new Employee(){ Name="Ali2",Id=3, Email="ali124@gmail.com"}
			};

			ViewBag.EmployeeData = emp;

            return View();
        }
    }
}