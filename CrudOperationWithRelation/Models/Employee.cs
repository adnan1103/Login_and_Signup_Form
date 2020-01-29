using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CrudOperationWithRelation.Models
{
	[Table("Employee")]
	public class Employee
	{
		[Key]
		[Column(Order = 1)]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int EmployeeId { get; set; }
		public string Name { get; set; }
		public string Address { get; set; }
		public string Email { get; set; }

		[Column(Order = 2)]
		[Key, ForeignKey("Departments")]
		public int DepartmentID { get; set; }

		public virtual Departments Departments { get; set; }

	}
}