using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Text;
using Android.Text.Style;

namespace LegendsOfClassicalMusic
{
	public class BaseActivity : Activity
	{

		protected override void OnCreate (Bundle savedInstanceState)
		{

			base.OnCreate(savedInstanceState);
			var st = new SpannableString("Test");
			st.SetSpan(new TypefaceSpan("Arial"), 0, st.Length(), SpanTypes.ExclusiveExclusive);
			ActionBar.TitleFormatted = st;
		}
	}
}

