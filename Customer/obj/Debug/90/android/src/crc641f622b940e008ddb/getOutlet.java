package crc641f622b940e008ddb;


public class getOutlet
	extends android.support.v7.app.AppCompatActivity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("Customer.getOutlet, Customer", getOutlet.class, __md_methods);
	}


	public getOutlet ()
	{
		super ();
		if (getClass () == getOutlet.class)
			mono.android.TypeManager.Activate ("Customer.getOutlet, Customer", "", this, new java.lang.Object[] {  });
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
