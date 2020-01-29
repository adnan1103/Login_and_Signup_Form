using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ManyRelationship.Models
{
	public class MeContext:DbContext
	{
		public MeContext():base("DbSet") {

		}

		public DbSet<Video> Videos { get; set; }
		public DbSet<PlayList> PlayLists { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<PlayList>().HasMany(p => p.GoodVideos).WithMany(v=>v.PlayLists);
			modelBuilder.Entity<PlayList>().HasMany(p => p.BadVideos).WithMany();
		}
	}
}