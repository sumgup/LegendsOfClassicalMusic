using System;
using System.Collections.Generic;
using System.Linq;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Webkit;
using System.Text;
using Android.Text;
using Android.Graphics;
using Android.Content.Res;

namespace LegendsOfClassicalMusic
{
	[Activity (Label = "ComposerDetailActivity", Theme = "@android:style/Theme.NoTitleBar.Fullscreen")]			
	public class ComposerDetailActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.composer_detail);

			string composerId = Intent.GetStringExtra("ComposerId");

			var composerOperations = new ComposerOperations();
			var composerDetails = composerOperations.GetComposerDetailsById (this, composerId);

			ImageView composerImage = FindViewById<ImageView> (Resource.Id.composerImage);
			composerImage.SetBackgroundResource(Utility.GetComposerDrawableImage(composerDetails.DisplayName));

			Typeface tf = Typeface.CreateFromAsset (Application.Context.Assets, "fonts/font.ttf");
			Typeface sansLight = Typeface.CreateFromAsset (Application.Context.Assets, "fonts/sanslight.ttf");


			var composerTitleText = FindViewById<TextView> (Resource.Id.titleBar);
			var composerNameText = FindViewById<TextView> (Resource.Id.composerName);
			var composerNationalityText = FindViewById<TextView> (Resource.Id.composerNationality);
			var composerEraText = FindViewById<TextView> (Resource.Id.composerEra);
			var composerBiographyText = FindViewById<TextView> (Resource.Id.biographyText);
			var composerFamousWork = FindViewById<TextView> (Resource.Id.famousWork);
			var labelBiography =  FindViewById<TextView> (Resource.Id.labelBiography);
			var labelFamousWork =  FindViewById<TextView> (Resource.Id.labelFamousWork);
			var labelYouTubeFamousWork = FindViewById<TextView> (Resource.Id.labelYouTubeFamousWork);
			WebView youtubeWebView = FindViewById<WebView> (Resource.Id.youtubeWebView);

			composerNationalityText.Text = composerDetails.NationalityName;
			composerNameText.Text = composerDetails.FullName;
			composerEraText.Text = composerDetails.ComposerAge;
			composerBiographyText.Text = composerDetails.Biography;
			composerFamousWork.Text = composerDetails.FamousWork;
			composerTitleText.Text = composerDetails.DisplayName;

			composerTitleText.SetTypeface (tf, TypefaceStyle.Normal);
			composerNameText.SetTypeface (tf, TypefaceStyle.Bold);
			composerNationalityText.SetTypeface (tf, TypefaceStyle.Bold);
			composerEraText.SetTypeface (tf, TypefaceStyle.Bold);

			labelBiography.SetTypeface (sansLight,TypefaceStyle.Normal);
			labelFamousWork.SetTypeface (sansLight,TypefaceStyle.Normal);
			labelYouTubeFamousWork.SetTypeface (sansLight,TypefaceStyle.Normal);

			var sans = Typeface.Create ("sans-serif-light", TypefaceStyle.Normal);
			composerBiographyText.SetTypeface (sans, TypefaceStyle.Normal);
			composerFamousWork.SetTypeface (sans, TypefaceStyle.Normal);

			var stringbuilder = new StringBuilder ();
			foreach (var item in composerDetails.YoutubeLinks) {

				stringbuilder.AppendFormat ("<a style='color:#fff; font :sans-serif-light' href='{0}' > <h4> {1} </h4>", item.LinkUrl,item.LinkDescription);
				//stringbuilder.Append (" </h4>");
				stringbuilder.Append(" </a>");
				//stringbuilder.Append (" </br>");
			}
			string mimeType = "text/html";
			string encoding = "UTF-8";
			youtubeWebView.LoadDataWithBaseURL("", stringbuilder.ToString (), mimeType, encoding, "");
			Resources res = this.Resources;
			var drawable = res.GetDrawable (Resource.Drawable.app_bg);
			youtubeWebView.SetBackgroundDrawable(drawable);
			youtubeWebView.SetBackgroundColor (Color.Transparent);
		}

		public override void OnBackPressed ()
		{
			Finish ();
			this.OverridePendingTransition(Resource.Animator.zoomexit1,Resource.Animator.zoomexit2);
		}
	}
}

