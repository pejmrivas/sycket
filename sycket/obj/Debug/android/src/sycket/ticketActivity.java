package sycket;


public class ticketActivity
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer,
		android.view.View.OnClickListener,
		android.widget.ViewSwitcher.ViewFactory
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"n_onClick:(Landroid/view/View;)V:GetOnClick_Landroid_view_View_Handler:Android.Views.View/IOnClickListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"n_makeView:()Landroid/view/View;:GetMakeViewHandler:Android.Widget.ViewSwitcher/IViewFactoryInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"";
		mono.android.Runtime.register ("sycket.ticketActivity, sycket, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", ticketActivity.class, __md_methods);
	}


	public ticketActivity () throws java.lang.Throwable
	{
		super ();
		if (getClass () == ticketActivity.class)
			mono.android.TypeManager.Activate ("sycket.ticketActivity, sycket, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);


	public void onClick (android.view.View p0)
	{
		n_onClick (p0);
	}

	private native void n_onClick (android.view.View p0);


	public android.view.View makeView ()
	{
		return n_makeView ();
	}

	private native android.view.View n_makeView ();

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
