package md51558244f76c53b6aeda52c8a337f2c37;


public class CarouselViewRenderer_CarouselViewOnScrollListener
	extends md5423e3a95c357eb7d6aad61b4f54abbd4.RecyclerViewScrollListener_2
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onScrollStateChanged:(Landroid/support/v7/widget/RecyclerView;I)V:GetOnScrollStateChanged_Landroid_support_v7_widget_RecyclerView_IHandler\n" +
			"";
		mono.android.Runtime.register ("Xamarin.Forms.Platform.Android.CarouselViewRenderer+CarouselViewOnScrollListener, Xamarin.Forms.Platform.Android", CarouselViewRenderer_CarouselViewOnScrollListener.class, __md_methods);
	}


	public CarouselViewRenderer_CarouselViewOnScrollListener ()
	{
		super ();
		if (getClass () == CarouselViewRenderer_CarouselViewOnScrollListener.class)
			mono.android.TypeManager.Activate ("Xamarin.Forms.Platform.Android.CarouselViewRenderer+CarouselViewOnScrollListener, Xamarin.Forms.Platform.Android", "", this, new java.lang.Object[] {  });
	}


	public void onScrollStateChanged (android.support.v7.widget.RecyclerView p0, int p1)
	{
		n_onScrollStateChanged (p0, p1);
	}

	private native void n_onScrollStateChanged (android.support.v7.widget.RecyclerView p0, int p1);

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
