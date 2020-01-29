using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CodeFirstApproachOnetoMany.Models
{
	public enum GENDER
	{
		MALE,FEMALE
	}

	[Table("tbl_Student")]
	public class Student
	{
		[Key]
		public int StudentId { get; set; }

		[Display(Name="Name")]
		[Required(ErrorMessage ="Name is Required")]
		[MinLength(3,ErrorMessage ="Name Should contain atleast 3 characters")]
		//[RegularExpression("^[a-zA-Z''-'\\s]{1,40}$	",ErrorMessage ="invalid name")]
		public string Std_name { get; set; }

		[DataType(DataType.Date)]
		[Required(ErrorMessage ="Date is Required")]
		[Display(Name ="Date of Birth")]
		public DateTime date { get; set; }

		[Required(ErrorMessage = "Gender is Required")]
		[Display(Name = "Gender")]
		public GENDER? GENDER { get; set; }
	}
}