using System;
using System.Data;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Android.Util;
using Android.Views.Animations;

namespace sycket
{
	[Activity (Label = "sycket", MainLauncher = true)]
	public class ticketActivity : Activity, View.IOnClickListener,ViewSwitcher.IViewFactory
	{
	





		ImageSwitcher images;
		int imageIndex;

		int [] imageResources = new int[]{ 
			Resource.Drawable.ticket1,
			Resource.Drawable.ticket2,
			Resource.Drawable.ticket3
		};




		public void OnClick (View v)
		{
			var activityMain = new Intent (this, typeof(MainActivity));
			StartActivity (activityMain);  
		}

		//	string myConnectionString = "Server=212.104.172.61;Database=sycketApp_0146q234234234234235xYdads;Uid=sycket;pass=fRLK9nLJ9PEMMpvU";
		Button back;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.ticketSwitcher);
			back = FindViewById<Button> (Resource.Id.buttonback);
			back.SetOnClickListener (this);
			string text = Intent.GetStringExtra ("idTicket") ?? "Data not available";

			//Toast.MakeText (this, text + " Clicked!", ToastLength.Short).Show ();

			images = FindViewById<ImageSwitcher> (Resource.Id.imageSwitcher1);

			images.SetInAnimation(this.ApplicationContext,Android.Resource.Animation.SlideInLeft);
			images.SetOutAnimation(this.ApplicationContext,Android.Resource.Animation.SlideOutRight);
			imageIndex = 0;

			images.SetFactory (this);			
			int i = Convert.ToInt32 (text);
			images.SetImageResource(imageResources[i%3]);
			//images.SetOnTouchListener (this);

			//images.SetImageResource(

		}

		public View MakeView() {

			ImageView imageView = new ImageView(this.ApplicationContext);
			imageView.SetScaleType(ImageView.ScaleType.FitCenter);

			ViewGroup.LayoutParams params2 = new ImageSwitcher.LayoutParams(
				WindowManagerLayoutParams.MatchParent, WindowManagerLayoutParams.MatchParent);

			imageView.LayoutParameters=params2;
			return imageView;

		}





	}
}