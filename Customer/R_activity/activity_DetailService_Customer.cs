using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Support.V7.Widget;
namespace Customer
{
    //[Activity(Label = "RecycleView", MainLauncher = true, Theme = "@style/Theme.AppCompat.Light.DarkActionBar")]
    class activity_DetailService_Customer : Activity
    {
        RecyclerView.LayoutManager mLayoutManagerService;
        RecyclerView mRecyclerViewService;
        Customer_DetailService_Service_ViewModel_List mService_List;
        DetailService_Service_Customer_Adapter mAdapterService;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource  
            SetContentView(Resource.Layout.DetailService_Customer);


            mRecyclerViewService = FindViewById<RecyclerView>(Resource.Id.recyclerViewService_DetailService_Customer);
            mLayoutManagerService = new LinearLayoutManager(this);
            mRecyclerViewService.SetLayoutManager(mLayoutManagerService);
            mService_List = new Customer_DetailService_Service_ViewModel_List();
            mAdapterService = new DetailService_Service_Customer_Adapter(mService_List);
            mRecyclerViewService.SetAdapter(mAdapterService);



        }

        private void MAdapter_ItemClick(object sender, int e)
        {
            int photoNum = e + 1;
            Toast.MakeText(this, "This is photo number " + photoNum, ToastLength.Short).Show();
        }

    }
}