using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Support.V7.Widget;
using System;
using GoldenSpa.API;
using Refit;
using Customer.Models;
using System.Collections.Generic;

namespace Customer
{
    [Activity(Label = "GoldenSpa", Theme = "@style/Theme.AppCompat.Light.DarkActionBar")]
    class activity_Outlet_Customer:AppCompatActivity
    {
        IMyAPI myAPI;

        ImageView back;
        TextView outletName;


        RecyclerView.LayoutManager mLayoutManagerService;
        RecyclerView mRecyclerViewService;
        List<ListService> mService_List;
        Outlet_Service_Customer_Adapter mAdapterService;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource  
            SetContentView(Resource.Layout.Outlet_Customer);

            back = FindViewById<ImageView>(Resource.Id.imgback_Outlet_Customer);
            back.Click += Back_Click;

            outletName = FindViewById<TextView>(Resource.Id.TxtOutletName_Outlet_Customer);
            outletName.Text = Intent.GetStringExtra("OutletName");


            mRecyclerViewService = FindViewById<RecyclerView>(Resource.Id.recyclerViewService_Outlet_Customer);
            mLayoutManagerService = new LinearLayoutManager(this);
            mRecyclerViewService.SetLayoutManager(mLayoutManagerService);
            getServiceAndCombo();
            
            

        }


        private void Back_Click(object sender, EventArgs e)
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

        private async void getServiceAndCombo()
        {
            myAPI = RestService.For<IMyAPI>("https://goldenspa.azurewebsites.net");
            var maCN= Intent.GetStringExtra("OutletId");
            var resultService = await myAPI.GetServiceFromOutlet(maCN);
            var resultCombo = await myAPI.GetComboFromOutlet(maCN);
            var max = resultService.Count + resultCombo.Count;
            mService_List = new List<ListService>(max);

            for (int i = 0; i < resultService.Count; i++)
            {
                var DataSample_Services_Outlet_ViewModel = new ListService();
                DataSample_Services_Outlet_ViewModel.MaDV = resultService[i].MaDV;
                DataSample_Services_Outlet_ViewModel.Image = resultService[i].Image;
                DataSample_Services_Outlet_ViewModel.NameService = resultService[i].NameService;
                DataSample_Services_Outlet_ViewModel.price = resultService[i].price;
                DataSample_Services_Outlet_ViewModel.Discount = resultService[i].Discount;
                mService_List.Add(DataSample_Services_Outlet_ViewModel);
            }

            for (int i = resultService.Count; i < max; i++)
            {
                var DataSample_Services_Outlet_ViewModel = new ListService();
                DataSample_Services_Outlet_ViewModel.MaDV = resultCombo[i - resultService.Count].MaDV;
                DataSample_Services_Outlet_ViewModel.Image = resultCombo[i - resultService.Count].Image;
                DataSample_Services_Outlet_ViewModel.NameService = resultCombo[i - resultService.Count].NameService;
                DataSample_Services_Outlet_ViewModel.price = resultCombo[i - resultService.Count].price;
                DataSample_Services_Outlet_ViewModel.Discount = resultCombo[i - resultService.Count].Discount;
                mService_List.Add(DataSample_Services_Outlet_ViewModel);
            }

            mAdapterService = new Outlet_Service_Customer_Adapter(mService_List);
            mRecyclerViewService.SetAdapter(mAdapterService);
        }

    }
}