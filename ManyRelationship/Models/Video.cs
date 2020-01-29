using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManyRelationship.Models
{
	public class Video
	{
		public int ID { get; set; }
		public string Title { get; set; }
		public string Desccription { get; set; }
		public List<PlayList> PlayLists { get; set; }
	}
}