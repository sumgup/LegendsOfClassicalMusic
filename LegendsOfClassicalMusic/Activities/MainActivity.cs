using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Graphics;
using Android.Text;
using Android.Text.Style;

namespace LegendsOfClassicalMusic
{
	[Activity (Label = "LegendsOfClassicalMusic", MainLauncher = true,Theme = "@android:style/Theme.NoTitleBar.Fullscreen")]
	public class MainActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			var composerNameText = FindViewById<TextView> (Resource.Id.composerName);
			Typeface tf = Typeface.CreateFromAsset (Application.Context.Assets, "fonts/font.ttf");
			composerNameText.SetTypeface (tf, TypefaceStyle.Normal);

			var composerOperations = new ComposerOperations ();
			GridView gridview = (GridView) this.FindViewById(Resource.Id.gridview);
			gridview.Adapter = new HomeScreenAdapter (this, composerOperations.GetAllComposers (this.ApplicationContext));
			gridview.ItemClick += delegate (object sender, Android.Widget.AdapterView.ItemClickEventArgs args) {
				var composerDetailActivity = new Intent (this, typeof(ComposerDetailActivity));
				composerDetailActivity.PutExtra ("ComposerId", args.View.Tag.ToString ());
				StartActivity(composerDetailActivity);
				this.OverridePendingTransition(Resource.Animator.inanim,Resource.Animator.outanim);

			};
		}

	}
}


