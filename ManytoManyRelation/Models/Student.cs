using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ManytoManyRelation.Models
{
	[Table("tbl_student")]

	public class Student
	{   
		[Key]
		public int StudentID { get; set; }
		public string StudentName { get; set; }
		public ICollection<Course> Courses { get; set; }
	}
}