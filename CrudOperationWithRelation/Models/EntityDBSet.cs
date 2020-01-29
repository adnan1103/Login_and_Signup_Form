using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CrudOperationWithRelation.Models
{
	public partial class EntityDBSet:DbContext
	{
		public EntityDBSet():base("entities") {

		}

		public virtual DbSet<Departments> Departments { get; set; }
		public virtual DbSet<Employee> Employee{ get; set; }
	}
}