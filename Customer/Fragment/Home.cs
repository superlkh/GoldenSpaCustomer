using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.Support.V7.Widget;
using GoldenSpa.API;
using Customer.Model;
using Refit;

namespace Customer.Fragment
{
    public class Home : Android.Support.V4.App.Fragment
    {
        IMyAPI myAPI;

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
        //List<ListOutlet> mOutlet_List;
        Home_Outlet_Customer_Adapter mAdapterOutlet;

        RecyclerView.LayoutManager mLayoutManagerUsedService;
        RecyclerView mRecyclerViewUsedService;
        Customer_Home_UsedService_List mUsedService_List;
        Home_UsedService_Customer_Adapter mAdapterUsedService;

        ImageView search;


       

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            View dv = inflater.Inflate(Resource.Layout.Home_Customer, container, false);

            mRecyclerViewAdvertisement = dv.FindViewById<RecyclerView>(Resource.Id.recyclerViewAdvertisement_Home_Customer);
            mLayoutManagerAdvertisement = new LinearLayoutManager(Context, LinearLayoutManager.Horizontal, false);
            mRecyclerViewAdvertisement.SetLayoutManager(mLayoutManagerAdvertisement);
            mAdvertisement_List = new Customer_Home_Advertisement_ViewModel_List();
            mAdapterAdvertisement = new Home_Advertisement_Customer_Adapter(mAdvertisement_List);
            mRecyclerViewAdvertisement.SetAdapter(mAdapterAdvertisement);


            mRecyclerViewDiscount = dv.FindViewById<RecyclerView>(Resource.Id.recyclerViewDiscount_Home_Customer);
            mLayoutManagerDiscount = new LinearLayoutManager(Context, LinearLayoutManager.Horizontal, false);
            mRecyclerViewDiscount.SetLayoutManager(mLayoutManagerDiscount);
            mdichvu_ViewModel = new Customer_Home_Service_List();
            mAdapterDiscount = new Home_Discount_Customer_Adapter(mdichvu_ViewModel);
            mAdapterDiscount.ItemClick += (s, e) =>
            {
                int photoNum = e + 1;
                Toast.MakeText(dv.Context, "This is photo number " + photoNum, ToastLength.Short).Show();
            };
            mRecyclerViewDiscount.SetAdapter(mAdapterDiscount);


            mRecyclerViewOutlet = dv.FindViewById<RecyclerView>(Resource.Id.recyclerViewOutlet_Home_Customer);
            mLayoutManagerOutlet = new GridLayoutManager(Context, 2, LinearLayoutManager.Horizontal, false);
            mRecyclerViewOutlet.SetLayoutManager(mLayoutManagerOutlet);
            GetOutlet();

                       

            mRecyclerViewUsedService = dv.FindViewById<RecyclerView>(Resource.Id.recyclerViewUsedService_Home_Customer);
            mLayoutManagerUsedService = new GridLayoutManager(Context, 2, LinearLayoutManager.Horizontal, false);
            mRecyclerViewUsedService.SetLayoutManager(mLayoutManagerUsedService);
            mUsedService_List = new Customer_Home_UsedService_List();
            mAdapterUsedService = new Home_UsedService_Customer_Adapter(mUsedService_List);
            mRecyclerViewUsedService.SetAdapter(mAdapterUsedService);


            search = dv.FindViewById<ImageView>(Resource.Id.imgSearch_Home_Customer);
            search.Click += Search_Click;

            return dv;
        }

        private void Search_Click(object sender, EventArgs e)
        {
            StartActivity(new Android.Content.Intent(Activity, typeof(Customer.activity_ResultSearch_Customer)));
        }

        public async void GetOutlet()
        {
            // lay du lieu tu db
            myAPI = RestService.For<IMyAPI>("https://goldenspa.azurewebsites.net");
            var result = await myAPI.GetListChiNhanh();
            List<ListOutlet> outlet = new List<ListOutlet>(result.Count());


            for (int i = 0; i < result.Count; i++)
            {
                var DataSample_Services_Outlet_ViewModel = new ListOutlet();
                DataSample_Services_Outlet_ViewModel.Image = result[i].Image;
                DataSample_Services_Outlet_ViewModel.name = result[i].name;
                DataSample_Services_Outlet_ViewModel.address = result[i].address;
                outlet.Add(DataSample_Services_Outlet_ViewModel);

            }


            mAdapterOutlet = new Home_Outlet_Customer_Adapter(outlet);
            mRecyclerViewOutlet.SetAdapter(mAdapterOutlet);
        }

    }
}