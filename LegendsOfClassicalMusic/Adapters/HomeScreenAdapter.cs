using System;
using Android.Widget;
using Android.Graphics;
using Android.Content.Res;
using Android.App;
using Android.Views;
using System.Threading.Tasks;
using Android.Graphics.Drawables;
using System.Threading;
using Android.OS;

namespace LegendsOfClassicalMusic
{
	public class HomeScreenAdapter : BaseAdapter<Composer>
	{
		Composer[] composers;
		Activity context;

		public HomeScreenAdapter (Activity context, Composer[] composers):base()
		{
			this.context = context;
			this.composers = composers;
		}

		public override long GetItemId(int position)
		{
			return position;
		}
		public override Composer this[int position] {  
			get { return composers[position]; }
		}
		public override int Count {
			get { return composers.Length; }
		}

		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			View view = convertView; // re-use an existing view, if one is available
			if (view == null) // otherwise create a new one
				view = context.LayoutInflater.Inflate(Resource.Layout.home_menu_list_item, null);

			Typeface tf = Typeface.CreateFromAsset (Application.Context.Assets, "fonts/font.ttf");

			var composerNameText = view.FindViewById<TextView> (Resource.Id.composerName);
			var composerAgeText = view.FindViewById<TextView> (Resource.Id.composerAge);

			composerNameText.SetTypeface (tf, TypefaceStyle.Bold);
			composerAgeText.SetTypeface (tf,TypefaceStyle.Bold);

			composerNameText.Text = composers [position].DisplayName;
			composerAgeText.Text = composers [position].ComposerAge;
			// Save the id in tag which will be used in detail view
			view.Tag = composers[position].Id;

			ImageView composerImage = view.FindViewById<ImageView>(Resource.Id.composerImage);

			ThreadPool.QueueUserWorkItem (o => SetComposerImage (composerImage,composers [position].DisplayName));

			return view;
		}

		private void SetComposerImage(ImageView imageView, string displayName)
		{
			var drawableId = Utility.GetComposerDrawableImage(displayName);
			Resources res = context.Resources;
			context.RunOnUiThread(() => imageView.SetBackgroundDrawable (res.GetDrawable (drawableId)));
		}
	}


}

