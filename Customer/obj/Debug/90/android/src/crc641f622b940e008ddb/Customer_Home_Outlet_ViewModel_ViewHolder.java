package crc641f622b940e008ddb;


public class Customer_Home_Outlet_ViewModel_ViewHolder
	extends android.support.v7.widget.RecyclerView.ViewHolder
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("Customer.Customer_Home_Outlet_ViewModel_ViewHolder, Customer", Customer_Home_Outlet_ViewModel_ViewHolder.class, __md_methods);
	}


	public Customer_Home_Outlet_ViewModel_ViewHolder (android.view.View p0)
	{
		super (p0);
		if (getClass () == Customer_Home_Outlet_ViewModel_ViewHolder.class)
			mono.android.TypeManager.Activate ("Customer.Customer_Home_Outlet_ViewModel_ViewHolder, Customer", "Android.Views.View, Mono.Android", this, new java.lang.Object[] { p0 });
	}

	private java.util.ArrayList refList;
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
