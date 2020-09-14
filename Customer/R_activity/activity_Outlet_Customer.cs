using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Support.V7.Widget;

namespace Customer
{
    //[Activity(Label = "RecycleView", MainLauncher = true, Theme = "@style/Theme.AppCompat.Light.DarkActionBar")]
    class activity_Outlet_Customer
    {
        
        class activity_UpdateInfo_Customer : Activity
        {

            RecyclerView.LayoutManager mLayoutManagerService;
            RecyclerView mRecyclerViewService;
            Customer_Outlet_Service_ViewModel_List mService_List;
            Outlet_Service_Customer_Adapter mAdapterService;

            protected override void OnCreate(Bundle savedInstanceState)
            {
                base.OnCreate(savedInstanceState);
                // Set our view from the "main" layout resource  
                SetContentView(Resource.Layout.Outlet_Customer);


                mRecyclerViewService = FindViewById<RecyclerView>(Resource.Id.recyclerViewService_Outlet_Customer);
                mLayoutManagerService = new LinearLayoutManager(this/*, LinearLayoutManager.Horizontal, false*/);
                mRecyclerViewService.SetLayoutManager(mLayoutManagerService);
                mService_List = new Customer_Outlet_Service_ViewModel_List();
                mAdapterService = new Outlet_Service_Customer_Adapter(mService_List);
                mRecyclerViewService.SetAdapter(mAdapterService);

            }
        }
    }
}