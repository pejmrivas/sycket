package sycket;


public class MainActivity
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer,
		android.widget.AbsListView.OnScrollListener
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"n_onScroll:(Landroid/widget/AbsListView;III)V:GetOnScroll_Landroid_widget_AbsListView_IIIHandler:Android.Widget.AbsListView/IOnScrollListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"n_onScrollStateChanged:(Landroid/widget/AbsListView;I)V:GetOnScrollStateChanged_Landroid_widget_AbsListView_IHandler:Android.Widget.AbsListView/IOnScrollListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"";
		mono.android.Runtime.register ("sycket.MainActivity, sycket, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", MainActivity.class, __md_methods);
	}


	public MainActivity () throws java.lang.Throwable
	{
		super ();
		if (getClass () == MainActivity.class)
			mono.android.TypeManager.Activate ("sycket.MainActivity, sycket, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);


	public void onScroll (android.widget.AbsListView p0, int p1, int p2, int p3)
	{
		n_onScroll (p0, p1, p2, p3);
	}

	private native void n_onScroll (android.widget.AbsListView p0, int p1, int p2, int p3);


	public void onScrollStateChanged (android.widget.AbsListView p0, int p1)
	{
		n_onScrollStateChanged (p0, p1);
	}

	private native void n_onScrollStateChanged (android.widget.AbsListView p0, int p1);

	java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
