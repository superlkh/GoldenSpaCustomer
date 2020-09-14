using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Support.V7.Widget;

namespace Customer
{
    //[Activity(Label = "RecycleView", MainLauncher = true, Theme = "@style/Theme.AppCompat.Light.DarkActionBar")]
    class activity_Home_Customer:Activity
    {

        RecyclerView.LayoutManager mLayoutManagerAdvertisement;
        RecyclerView mRecyclerViewAdvertisement;
        Customer_Home_Advertisement_ViewModel_List mAdvertisement_List;
        Home_Advertisement_Customer_Adapter mAdapterAdvertisement;

        RecyclerView.LayoutManager mLayoutManagerDiscount; // set vertical hay horizontal
        RecyclerView mRecyclerViewDiscount;
        Customer_Home_Service_List mdichvu_ViewModel;// thong tin hien thi len 1 item
        Home_Discount_Customer_Adapter mAdapterDiscount;

        RecyclerView.LayoutManager mLayoutManagerOutlet;
        RecyclerView mRecyclerViewOutlet;
        Customer_Home_Outlet_ViewModel_List mOutlet_List;
        Home_Outlet_Customer_Adapter mAdapterOutlet;

        RecyclerView.LayoutManager mLayoutManagerUsedService;
        RecyclerView mRecyclerViewUsedService;
        Customer_Home_UsedService_List mUsedService_List;
        Home_UsedService_Customer_Adapter mAdapterUsedService;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource  
            SetContentView(Resource.Layout.Home_Customer);


            mRecyclerViewAdvertisement = FindViewById<RecyclerView>(Resource.Id.recyclerViewAdvertisement_Home_Customer);
            mLayoutManagerAdvertisement = new LinearLayoutManager(this, LinearLayoutManager.Horizontal, false);
            mRecyclerViewAdvertisement.SetLayoutManager(mLayoutManagerAdvertisement);
            mAdvertisement_List = new Customer_Home_Advertisement_ViewModel_List();
            mAdapterAdvertisement = new Home_Advertisement_Customer_Adapter(mAdvertisement_List);
            mRecyclerViewAdvertisement.SetAdapter(mAdapterAdvertisement);


            mRecyclerViewDiscount = FindViewById<RecyclerView>(Resource.Id.recyclerViewDiscount_Home_Customer);
            mLayoutManagerDiscount = new LinearLayoutManager(this, LinearLayoutManager.Horizontal, false);
            mRecyclerViewDiscount.SetLayoutManager(mLayoutManagerDiscount);
            mdichvu_ViewModel = new Customer_Home_Service_List();
            mAdapterDiscount = new Home_Discount_Customer_Adapter(mdichvu_ViewModel);
            mAdapterDiscount.ItemClick += MAdapter_ItemClick;
            mRecyclerViewDiscount.SetAdapter(mAdapterDiscount);

            //mRecyclerViewOutlet = FindViewById<RecyclerView>(Resource.Id.recyclerViewOutlet_Home_Customer);
            //mLayoutManagerOutlet = new GridLayoutManager(this, 2, LinearLayoutManager.Horizontal, false);
            //mRecyclerViewOutlet.SetLayoutManager(mLayoutManagerOutlet);
            //mOutlet_List = new Customer_Home_Outlet_ViewModel_List();
            //mAdapterOutlet = new Home_Outlet_Customer_Adapter(mOutlet_List);
            //mRecyclerViewOutlet.SetAdapter(mAdapterOutlet);


            mRecyclerViewUsedService = FindViewById<RecyclerView>(Resource.Id.recyclerViewUsedService_Home_Customer);
            mLayoutManagerUsedService = new GridLayoutManager(this, 2, LinearLayoutManager.Horizontal, false);
            mRecyclerViewUsedService.SetLayoutManager(mLayoutManagerUsedService);
            mUsedService_List = new Customer_Home_UsedService_List();
            mAdapterUsedService = new Home_UsedService_Customer_Adapter(mUsedService_List);
            mRecyclerViewUsedService.SetAdapter(mAdapterUsedService);
        }

        private void MAdapter_ItemClick(object sender, int e)
        {
            int photoNum = e + 1;
            Toast.MakeText(this, "This is photo number " + photoNum, ToastLength.Short).Show();
        }

    }
}