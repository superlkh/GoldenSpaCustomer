using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Support.V7.Widget;
using System;

namespace Customer
{
    [Activity(Label = "activity_ResultSearch_Customer")]
    class activity_ResultSearch_Customer : AppCompatActivity
    {
        RecyclerView.LayoutManager mLayoutManagerService;
        RecyclerView mRecyclerViewService;
        Customer_ResultSearch_Result_ViewModel_List mService_List;
        ResultSearch_Result_Customer_Adapter mAdapterService;

        ImageView back;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource  
            SetContentView(Resource.Layout.ResultSearch_Customer);


            mRecyclerViewService = FindViewById<RecyclerView>(Resource.Id.recyclerViewSearch_ResultSearch_Customer);
            mLayoutManagerService = new LinearLayoutManager(this);
            mRecyclerViewService.SetLayoutManager(mLayoutManagerService);
            mService_List = new Customer_ResultSearch_Result_ViewModel_List();
            mAdapterService = new ResultSearch_Result_Customer_Adapter(mService_List);
            mRecyclerViewService.SetAdapter(mAdapterService);

            back = FindViewById<ImageView>(Resource.Id.imgback_ResultSearch_Customer);
            back.Click += back_Click;

        }

        private void MAdapter_ItemClick(object sender, int e)
        {
            int photoNum = e + 1;
            Toast.MakeText(this, "This is photo number " + photoNum, ToastLength.Short).Show();
        }


        private void back_Click(object sender, EventArgs e)
        {
            Finish();
            SetContentView(Resource.Layout.Home_Customer);
            var navBottom = FindViewById<Android.Support.Design.Widget.BottomNavigationView>(Resource.Id.bottom_navigation);
            navBottom.NavigationItemSelected += (s, c) =>
            {
                var trans = SupportFragmentManager.BeginTransaction();
                trans.Replace(Resource.Id.frame_container, new Fragment.Home()).Commit();
            };
        }

    }
}