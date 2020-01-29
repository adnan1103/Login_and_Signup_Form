using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CodeFirstSignup_Login.Models
{
	public class MyDbContext:DbContext
	{
		public MyDbContext():base("name=MyDbContext")
		{

		}
		public DbSet<Department> Departments { get; set; }
		public DbSet<Employee> Employees { get; set; }

		public DbSet<Login> Logins { get; set; }
		public DbSet<Registar> Registars { get; set; }
	}

	public class Department
	{
		[Key]
		public int ID { get; set; }
		[Required]
		public string Name { get; set; }

		public ICollection<Employee> Employees { get; set; }
	}

	public class Employee
	{
		[Key]
		public int ID { get; set; }
		[Required]
		public string EmployeeName { get; set; }
		[Required]
		public string EmployeeEmail { get; set; }
		public int? EmployeeSalary { get; set; }

		[ForeignKey("Department")]
		public int DepartmentID { get; set; }
		public Department Department { get; set; }
	}

	public class Login
	{
		[Key]
		public int ID { get; set; }

		[Display(Name = "User Name")]
		[Required(ErrorMessage = "User Name is required.")]
		public string UserName { get; set; }

		[Display(Name = "Password")]
		[DataType(DataType.Password)]
		[Required(ErrorMessage = "Password is required.")]
		public string UserPassword { get; set; }

		[Display(Name = "Remember Me")]
		public bool RememberMe { get; set; }
	}

	public class Registar
	{
		[Key]
		public int ID { get; set; }
		[Display(Name = "Full Name")]
		[Required(ErrorMessage = "Full Name is required")]
		public string FullName { get; set; }

		[Display(Name = "User Name")]
		[Required(ErrorMessage = "User Name is required")]
		public string UserName { get; set; }

		[Display(Name = "Password")]
		[DataType(DataType.Password)]
		[Required(ErrorMessage = "Passwor is required")]
		public string Password { get; set; }

		[Display(Name = "Confirm Password")]
		[DataType(DataType.Password)]
		[Compare(otherProperty: "Password", ErrorMessage = "Password does not match")]
		public string ConfirmPassword { get; set; }

		[Display(Name = "Email")]
		[DataType(DataType.EmailAddress)]
		[Required(ErrorMessage = "Email is required")]
		public string Email { get; set; }

		[Display(Name = "Confirm Email")]
		[DataType(DataType.EmailAddress)]
		[Compare(otherProperty: "Email", ErrorMessage = "Email does not match")]
		public string ConfirmEmail { get; set; }

		[Display(Name = "Role")]
		[Required(ErrorMessage = "Role is required")]
		[UIHint("RolesComboBox")]
		public string Role { get; set; }
	}

	public enum Role
	{
		NoRole = 0,
		Administrator = 1,
		Manager = 2,
		User = 3
	}

	public class AppSetting
	{
		public static string ConnectionString()
		{
			return ConfigurationManager.ConnectionStrings["MyDbContext"].ConnectionString;
		}
	}

	public class ChangePassword
	{
		[Display(Name = "Old Password")]
		[DataType(DataType.Password)]
		[Required(ErrorMessage = "Old Password is required")]
		public string OldPassword { get; set; }

		[Display(Name = "New Password")]
		[Required(ErrorMessage = "New Password is required")]
		[DataType(DataType.Password)]
		public string NewPassword { get; set; }

		[Display(Name = "Confirm New Password")]
		[DataType(DataType.Password)]
		[Compare(otherProperty: "NewPassword", ErrorMessage = "Confirm New Password does not match")]
		public string ConfirmNewPassword { get; set; }
	}


	public class UserProfile
	{
		[Display(Name = "Full Name")]
		[Required(ErrorMessage = "Full Name is required")]
		public string FullName { get; set; }

		[Display(Name = "Email")]
		[Required(ErrorMessage = "Email is required")]
		public string Email { get; set; }

		[Display(Name = "Address")]
		public string Address { get; set; }
	}
}