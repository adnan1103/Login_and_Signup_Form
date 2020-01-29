using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CodeFirstApproachOnetoMany.Models
{
	public class fee
	{
		[Key]
		public int feeid { get; set; }

		[Required(ErrorMessage = "Amount is Required")]
		[Display(Name = "Fees Amount")]
		public int feeamount { get; set; }

		[DataType(DataType.Date)]
		[Required(ErrorMessage = "Date is Required")]
		[Display(Name = "Fee Submission Date")]
		public DateTime date { get; set; }

		public virtual Student student { get; set; }

		public int StudentId { get; set; }
	}
}