using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace CodeFirstApproachOnetoMany.Models
{
	public class cs:DbContext
	{
		public DbSet<Student> students{ get; set; }

		public DbSet<fee> fees{ get; set; }
	}
}