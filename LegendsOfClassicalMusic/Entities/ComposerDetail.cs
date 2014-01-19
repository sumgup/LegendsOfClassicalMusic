
using System;
using System.Collections.Generic;

namespace LegendsOfClassicalMusic
{
	public class ComposerDetail
	{
		public ComposerDetail (){}

		public string NationalityName { get; set;}
		public string NationalityIsoCode { get; set;}
		public string Biography { get; set;}
		public string FamousWork { get; set;}
		public List<YouTubeLink> YoutubeLinks { get; set;}
		public int Id { get; set; } 
		public String DisplayName { get; set;} 
		public String FullName { get; set;}
		public String ImageName { get; set;}
		public String ComposerAge { get; set;}
	}

	public class YouTubeLink
	{
		public string LinkUrl { get; set;}
		public string LinkDescription { get; set;}
	}
}

