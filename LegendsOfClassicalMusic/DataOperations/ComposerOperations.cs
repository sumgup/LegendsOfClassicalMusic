using System;
using System.Xml;
using System.IO;
using System.Collections.Generic;
using System.Xml.XPath;
using Android.Content;

namespace LegendsOfClassicalMusic
{
	public class ComposerOperations
	{
		public ComposerDetail GetComposerDetailsById(Context context, string id)
		{
			var composerDetail = new ComposerDetail ();
			var xmlDocument = GetXmlDocument (context);
			XmlNode root = xmlDocument.DocumentElement;

			string selectNodeXpathValue = string.Format (@"//Composer[@id='{0}']", id);

			foreach (XmlNode item in root.SelectNodes(selectNodeXpathValue))
			{
				// Composer
				composerDetail.Id = Convert.ToInt32(item.Attributes["id"].Value);
				composerDetail.DisplayName = item.Attributes["DisplayName"].Value;
				composerDetail.FullName = item.Attributes["FullName"].Value;
				composerDetail.ImageName = item.Attributes["ImageName"].Value;
				composerDetail.ComposerAge = item.Attributes["Era"].Value;

				// Nationality
				XmlNode nationalityNode = item.SelectSingleNode("Nationality");
				composerDetail.NationalityName = nationalityNode.Attributes ["FullName"].Value;
				composerDetail.NationalityIsoCode = nationalityNode.Attributes ["IsoCode"].Value;

				// Biography
				XmlNode biographyNode = item.SelectSingleNode("Biography");
				composerDetail.Biography = biographyNode.InnerText;

				// Famous work
				XmlNode famousWorkNode = item.SelectSingleNode("FamousWork");
				composerDetail.FamousWork = famousWorkNode.InnerText;

				// Youtube Links
				XmlNode youTubeLinks = item.SelectSingleNode("YouTubeLinks");
				if (youTubeLinks != null) 
				{
					var youTubeLinksList = new List<YouTubeLink> ();

					foreach (XmlNode link in youTubeLinks) {
						var youTubeLink = new YouTubeLink ();
						youTubeLink.LinkDescription = link.Attributes ["Description"].Value;
						youTubeLink.LinkUrl  = link.Attributes ["Url"].Value;
						youTubeLinksList.Add (youTubeLink);
					}
					composerDetail.YoutubeLinks = youTubeLinksList;
				}
			}

			return composerDetail;
		}



		public Composer[] GetAllComposers(Context context)
		{
			List<Composer> composerList = new List<Composer>();

			var xmlDocument = GetXmlDocument (context);
			XmlNode root = xmlDocument.DocumentElement;

			foreach (XmlNode item in root.SelectNodes(@"/Composers/Composer"))
			{
				Composer composer = new Composer();
				composer.Id = Convert.ToInt32(item.Attributes["id"].Value);
				composer.DisplayName = item.Attributes["DisplayName"].Value;
				composer.FullName = item.Attributes["FullName"].Value;
				composer.ImageName = item.Attributes["ImageName"].Value;
				composer.ComposerAge = item.Attributes["Era"].Value;
				composerList.Add(composer);
			}

			return composerList.ToArray();
		}

		private XmlDocument GetXmlDocument (Context context)
		{
			string content;
			using (var input = context.Assets.Open (Globals.COMPOSERFILENAME))
			using (StreamReader sr = new StreamReader (input)) 
			{
				content = sr.ReadToEnd ();
			}
			XmlDocument xmlDocument = new XmlDocument ();
			xmlDocument.LoadXml (content);
			return xmlDocument;
		}


	}
}

