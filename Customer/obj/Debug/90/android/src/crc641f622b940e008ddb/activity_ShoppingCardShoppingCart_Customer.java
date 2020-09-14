package crc641f622b940e008ddb;


public class activity_ShoppingCardShoppingCart_Customer
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("Customer.activity_ShoppingCardShoppingCart_Customer, Customer", activity_ShoppingCardShoppingCart_Customer.class, __md_methods);
	}


	public activity_ShoppingCardShoppingCart_Customer ()
	{
		super ();
		if (getClass () == activity_ShoppingCardShoppingCart_Customer.class)
			mono.android.TypeManager.Activate ("Customer.activity_ShoppingCardShoppingCart_Customer, Customer", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

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
