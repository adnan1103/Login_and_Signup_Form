using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ManytoManyRelation.Models
{

	[Table("tbl_course")]
	public class Course
	{
		[Key]
		public int CourseID { get; set; }
		public string CourseName { get; set; }
		public ICollection<Student> Students { get; set; }
	}
}