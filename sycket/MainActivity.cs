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

namespace sycket
{
	[Activity (Label = "sycket", MainLauncher = true)]
	public class MainActivity : Activity,  AbsListView.IOnScrollListener
	{
		//	string myConnectionString = "Server=212.104.172.61;Database=sycketApp_0146q234234234234235xYdads;Uid=sycket;pass=fRLK9nLJ9PEMMpvU";
		ListView ticketListView;
		private List<List<String>> sycketList;
		private Boolean loading = false;
		private SycketListAdapter adapterSycket;
		private TextView infoTextView;
		private ViewGroup mainLayoutView;
		private int ticketNumber=0;


		public void OnScrollStateChanged(AbsListView view, ScrollState scrollState) {}
		//dumdumdum

		public void OnScroll(AbsListView view, int firstVisibleItem,
			int visibleItemCount, int totalItemCount) {
			//what is the bottom iten that is visible
		
			int lastInScreen = firstVisibleItem + visibleItemCount;
			Log.Info ("SYCKETDEBUG","cargando "+firstVisibleItem.ToString()+ " " +visibleItemCount.ToString()+" "+totalItemCount.ToString()+"\n");
			//is the bottom item visible & not loading more already ? Load more !
			if((lastInScreen == totalItemCount)&!loading){
				//ticketListView.RefreshDrawableState ();
				//infoTextView.Text="asdfaCargando...";
				mainLayoutView.Invalidate ();
				Thread.Sleep (70);

				loading = true;
				Log.Info ("SYCKETDEBUG"," ENTRA cargando "+firstVisibleItem.ToString()+ " " +visibleItemCount.ToString()+" "+totalItemCount.ToString()+"\n");
				Random random = new Random();
				int randomNumber = random.Next(0, 100);

				sycketList.Add (new List <String>(){(++ticketNumber).ToString(), "24/03/2014", "Prueba ",(double)randomNumber*0.84 + " €" });
				adapterSycket.NotifyDataSetChanged ();
				//	sycketList.Add (new List <String>(){ "22/02/2014", "Mercadona","12.98 €" });
				//	sycketList.Add (new List <String>(){ "19/02/2014", "Mercadona","7.6 €" });
				loading = false;
				infoTextView.Text = totalItemCount.ToString() +" tickets ordenados por fecha";
				//Thread thread =  new Thread(null, loadMoreListItems);
				//thread.start();
			}
		}


		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);
			ticketListView = FindViewById<ListView> (Resource.Id.ticketList);
			infoTextView = FindViewById<TextView> (Resource.Id.infoText);
			mainLayoutView = FindViewById<ViewGroup> (Resource.Id.mainLayout);

			//add the footer before adding the adapter, else the footer will not load!


			//LISTA DEMO
			sycketList = new List<List<String>>();
			sycketList.Add (new List <String>(){ (++ticketNumber).ToString(),"03/04/2014", "Mercadona","95.9 €" });
			sycketList.Add (new List <String>(){(++ticketNumber).ToString(),"02/04/2014", "AppInformatica","95.9 €" });
			sycketList.Add (new List <String>(){ (++ticketNumber).ToString(),"02/04/2014", "Supermercados Mas", "45.5 €" });
			sycketList.Add (new List <String>(){ (++ticketNumber).ToString(),"01/04/2014", "Mercadona","95 €" });
			sycketList.Add (new List <String>(){ (++ticketNumber).ToString(),"29/03/2014", "Bar Sevilla Betis","38.1 €" });
			//sycketList.Add (new List <String>(){ "28/03/2014", "Zara","75 €" });
			/*sycketList.Add (new List <String>(){ "26/03/2014", "Mercadona","12.24 €" });*/			


			//ArrayAdapter a = new ArrayAdapter<String>(this, Android.Resource.Layout.SimpleListItem1, values);

			//ADAPTER SYCKET
			adapterSycket = new SycketListAdapter(this, sycketList);
			ticketListView.Adapter = adapterSycket;

			ticketListView.SetOnScrollListener (this);
			ticketListView.ItemClick += delegate(object sender, AdapterView.ItemClickEventArgs e) {
				var item = sycketList [e.Position] [0];

				//Make a toast with the item name just to show it was clicked
				//Toast.MakeText (this, item.ToString () + " Clicked!", ToastLength.Short).Show ();

				var activityTicket = new Intent (this, typeof(ticketActivity));
				activityTicket.PutExtra ("idTicket", item);
				StartActivity (activityTicket);  

			};
			/*	MySqlConnection connection = new MySqlConnection (myConnectionString);
			try{
				MySqlCommand cmd = connection.CreateCommand();
				cmd.CommandText = "SELECT * FROM ticket";
				MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
				//	DataSet ds = new DataSet();
				//	adap.Fill(ds);

			}
			catch(Exception){
				throw;
			}
			*/
			// Get our button from the layout resource,
			// and attach an event to it
			//Button button = FindViewById<Button> (Resource.Id.myButton);
			
			//button.Click += delegate {
			//	button.Text = string.Format ("{0} clicks!", count++);
			//};


		}
	}


				//SICKET LIST ADAPTER
	public class SycketListAdapter : BaseAdapter<string> {
		List<List<String>> items;
		Activity context;
		public SycketListAdapter(Activity context, List<List<String>> items) : base() {
			this.context = context;
			this.items = items;
		}
		public override long GetItemId(int position)
		{
			return position;
		}
		public override string this[int position] {  
			get { return items[position][0]; }
		}
		public override int Count {
			get { return items.Count; }
		}
		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			View view = convertView; // re-use an existing view, if one is available
			if (view == null) // otherwise create a new one
				view = context.LayoutInflater.Inflate(Resource.Layout.listElement, null);
			view.FindViewById<TextView>(Resource.Id.ticketDate).Text  =  items[position][1];
			view.FindViewById<TextView>(Resource.Id.ticketShop).Text  =  items[position][2];
			view.FindViewById<TextView>(Resource.Id.ticketTotal).Text =  items[position][3];
			return view;

		}
	}
}