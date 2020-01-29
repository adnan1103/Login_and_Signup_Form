using CodeFirstSignup_Login.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using PagedList;
using System.Web.Mvc;


namespace CodeFirstSignup_Login.Controllers
{
	[Authorize]
	public class EmployeeController : Controller
    {
		private MyDbContext db = new MyDbContext();

		// GET: Employees
		public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page, int? selectedItem)
		{
			ViewBag.CurrentSort = sortOrder;
			ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
			ViewBag.DepartmentSortParm = sortOrder == "Department" ? "department_name" : "Department";
			ViewBag.EmailSortParm = sortOrder == "Email" ? "employee_email" : "Email";
			ViewBag.SalarySortParm = sortOrder == "Salary" ? "employee_salary" : "Salary";

			ViewBag.selectedItem = selectedItem;


			if (searchString != null)
			{
				page = 1;
			}
			else
			{
				searchString = currentFilter;
			}

			ViewBag.CurrentFilter = searchString;

			var employees = db.Employees.Include(e => e.Department);

			if (!String.IsNullOrEmpty(searchString))
			{
				employees = employees.Where(s => s.EmployeeName.Contains(searchString)
									  || s.Department.Name.Contains(searchString));
			}

			switch (sortOrder)
			{
				case "name_desc":
					employees = employees.OrderByDescending(emp => emp.EmployeeName);
					break;

				case "Department":
					employees = employees.OrderBy(emp => emp.Department.Name);
					break;

				case "department_name":
					employees = employees.OrderByDescending(emp => emp.Department.Name);
					break;

				case "Email":
					employees = employees.OrderBy(emp => emp.EmployeeEmail);
					break;

				case "employee_email":
					employees = employees.OrderByDescending(emp => emp.EmployeeEmail);
					break;

				case "Salary":
					employees = employees.OrderBy(emp => emp.EmployeeSalary);
					break;

				case "employee_salary":
					employees = employees.OrderByDescending(emp => emp.EmployeeSalary);
					break;

				default:
					employees = employees.OrderBy(emp => emp.EmployeeName);
					break;

			}

			int pageSize = 3;
			if (selectedItem == 5)
			{
				pageSize = 5;
			}
			else if (selectedItem == 10)
			{
				pageSize = 10;
			}


			int pageNumber = (page ?? 1);
			return View(employees.ToPagedList(pageNumber, pageSize));

		}


		// GET: Employees/Details/5
		public ActionResult Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Employee employee = db.Employees.Find(id);
			if (employee == null)
			{
				return HttpNotFound();
			}
			return View(employee);
		}

		// GET: Employees/Create
		public ActionResult Create()
		{
			ViewBag.DepartmentID = new SelectList(db.Departments, "ID", "Name");
			return View();
		}

		// POST: Employees/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "ID,EmployeeName,EmployeeEmail,EmployeeSalary,DepartmentID")] Employee employee)
		{
			if (ModelState.IsValid)
			{
				db.Employees.Add(employee);
				db.SaveChanges();
				return RedirectToAction("Index");
			}

			ViewBag.DepartmentID = new SelectList(db.Departments, "ID", "Name", employee.DepartmentID);
			return View(employee);
		}

		// GET: Employees/Edit/5
		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Employee employee = db.Employees.Find(id);
			if (employee == null)
			{
				return HttpNotFound();
			}
			ViewBag.DepartmentID = new SelectList(db.Departments, "ID", "Name", employee.DepartmentID);
			return View(employee);
		}

		// POST: Employees/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "ID,EmployeeName,EmployeeEmail,EmployeeSalary,DepartmentID")] Employee employee)
		{
			if (ModelState.IsValid)
			{
				db.Entry(employee).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			ViewBag.DepartmentID = new SelectList(db.Departments, "ID", "Name", employee.DepartmentID);
			return View(employee);
		}

		// GET: Employees/Delete/5
		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Employee employee = db.Employees.Find(id);
			if (employee == null)
			{
				return HttpNotFound();
			}
			return View(employee);
		}

		// POST: Employees/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			Employee employee = db.Employees.Find(id);
			db.Employees.Remove(employee);
			db.SaveChanges();
			return RedirectToAction("Index");
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				db.Dispose();
			}
			base.Dispose(disposing);
		}
	}
}