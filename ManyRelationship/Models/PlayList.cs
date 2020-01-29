using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManyRelationship.Models
{
	public class PlayList
	{
		public int ID { get; set; }
		public string Title { get; set; }
		public List<Video> GoodVideos { get; set; }
		public List<Video> BadVideos { get; set; }
	}
}