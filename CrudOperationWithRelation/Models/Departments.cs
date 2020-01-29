using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CrudOperationWithRelation.Models
{
	[Table("Departments")]
	public class Departments
	{
		public Departments()
		{
			this.Employee = new HashSet<Employee>();
		}
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		[Key]

		public int DepartmentId { get; set; }

		public string DepartmentName { get; set; }

		public virtual ICollection<Employee> Employees { get; set; }
		public HashSet<Employee> Employee { get; }
	}
}