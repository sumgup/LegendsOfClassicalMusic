using System;

namespace LegendsOfClassicalMusic
{
	public static class Utility
	{
		public static int GetComposerDrawableImage(string displayName)
		{
			int id;
			switch (displayName) {
			case "Beethoven":
				id = Resource.Drawable.Beethoven;
				break;
			case "Bach":
				id = Resource.Drawable.Bach;
				break;
			case "Brahms":
				id = Resource.Drawable.Brahms;
				break;
			case "Chopin":
				id = Resource.Drawable.Chopin;
				break;
			case "Debussy":
				id = Resource.Drawable.Debussy;
				break;
			case "Handel":
				id = Resource.Drawable.Handel;
				break;
			case "Haydn":
				id = Resource.Drawable.Haydn;
				break;
			case "Mendelssohn":
				id = Resource.Drawable.Mendelssohn;
				break;
			case "Mozart":
				id = Resource.Drawable.Mozart;
				break;
			case "Rachmaninoff":
				id = Resource.Drawable.Rachmaninoff;
				break;
			case "Rossini":
				id = Resource.Drawable.Rossini;
				break;
			case "Tchaikovsky":
				id = Resource.Drawable.Tchaikovsky;
				break;
			case "Verdi":
				id = Resource.Drawable.Verdi;
				break;
			case "Vivaldi":
				id = Resource.Drawable.Vivaldi;
				break;
			case "Wagner":
				id = Resource.Drawable.Wagner;
				break;
			default:
				id = 0;
				break;
			}
			return id;
		}
	}
}

