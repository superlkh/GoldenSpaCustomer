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
using Customer.Models;
using Refit;

namespace Customer.Fragment
{
    public class Home : Android.Support.V4.App.Fragment
    {
        IMyAPI myAPI;

        RecyclerView.LayoutManager mLayoutManagerAdvertisement;
        RecyclerView mRecyclerViewAdvertisement;
        List<ListAdvertisement> mAdvertisement;
        Home_Advertisement_Customer_Adapter mAdapterAdvertisement;

        RecyclerView.LayoutManager mLayoutManagerDiscount; // set vertical hay horizontal
        RecyclerView mRecyclerViewDiscount;
        List<ListPromotion> mDiscount;// thong tin hien thi len 1 item
        Home_Discount_Customer_Adapter mAdapterDiscount;

        RecyclerView.LayoutManager mLayoutManagerCombo; // set vertical hay horizontal
        RecyclerView mRecyclerViewCombo;
        List<ListPromotion> mCombo;// thong tin hien thi len 1 item
        Home_Combo_Customer_Adapter mAdapterCombo;

        RecyclerView.LayoutManager mLayoutManagerOutlet;
        RecyclerView mRecyclerViewOutlet;
        List<ListOutlet> mOutlet;
        Home_Outlet_Customer_Adapter mAdapterOutlet;

        RecyclerView.LayoutManager mLayoutManagerUsedService;
        RecyclerView mRecyclerViewUsedService;
        List<ListPromotion> mUsedService;
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
            GetAdvertisement();


            mRecyclerViewDiscount = dv.FindViewById<RecyclerView>(Resource.Id.recyclerViewDiscount_Home_Customer);
            mLayoutManagerDiscount = new LinearLayoutManager(Context, LinearLayoutManager.Horizontal, false);
            mRecyclerViewDiscount.SetLayoutManager(mLayoutManagerDiscount);
            GetDiscount();


            mRecyclerViewCombo = dv.FindViewById<RecyclerView>(Resource.Id.recyclerViewCombo_Home_Customer);
            mLayoutManagerCombo = new LinearLayoutManager(Context, LinearLayoutManager.Horizontal, false);
            mRecyclerViewCombo.SetLayoutManager(mLayoutManagerCombo);
            GetCombo();


            mRecyclerViewOutlet = dv.FindViewById<RecyclerView>(Resource.Id.recyclerViewOutlet_Home_Customer);
            mLayoutManagerOutlet = new GridLayoutManager(Context, 2, LinearLayoutManager.Horizontal, false);
            mRecyclerViewOutlet.SetLayoutManager(mLayoutManagerOutlet);
            GetOutlet();

                       

            mRecyclerViewUsedService = dv.FindViewById<RecyclerView>(Resource.Id.recyclerViewUsedService_Home_Customer);
            mLayoutManagerUsedService = new GridLayoutManager(Context, 2, LinearLayoutManager.Horizontal, false);
            mRecyclerViewUsedService.SetLayoutManager(mLayoutManagerUsedService);
            GetUsedService();




            search = dv.FindViewById<ImageView>(Resource.Id.imgSearch_Home_Customer);
            search.Click += Search_Click;

            return dv;
        }

        private void Search_Click(object sender, EventArgs e)
        {
            StartActivity(new Android.Content.Intent(Activity, typeof(Customer.activity_ResultSearch_Customer)));
        }


        public async void GetAdvertisement()
        {
            // lay du lieu tu db
            myAPI = RestService.For<IMyAPI>("https://goldenspa.azurewebsites.net");
            var result = await myAPI.GetListAdvertisement();
            mAdvertisement = new List<ListAdvertisement>(result.Count());


            for (int i = 0; i < result.Count; i++)
            {
                var DataSample_Services_Advertisement_ViewModel = new ListAdvertisement();
                DataSample_Services_Advertisement_ViewModel.Image = result[i].Image;
                mAdvertisement.Add(DataSample_Services_Advertisement_ViewModel);
            }


            mAdapterAdvertisement = new Home_Advertisement_Customer_Adapter(mAdvertisement);
            mRecyclerViewAdvertisement.SetAdapter(mAdapterAdvertisement);
        }

        public async void GetDiscount()
        {
            // lay du lieu tu db
            myAPI = RestService.For<IMyAPI>("https://goldenspa.azurewebsites.net");
            var result = await myAPI.GetListPromotion();
            mDiscount = new List<ListPromotion>(result.Count());


            for (int i = 0; i < result.Count; i++)
            {
                var DataSample_Services_Outlet_ViewModel = new ListPromotion();
                DataSample_Services_Outlet_ViewModel.MaDV = result[i].MaDV;
                DataSample_Services_Outlet_ViewModel.Image = result[i].Image;
                DataSample_Services_Outlet_ViewModel.NameService = result[i].NameService;
                DataSample_Services_Outlet_ViewModel.price = result[i].price;
                DataSample_Services_Outlet_ViewModel.Discount = result[i].Discount;
                DataSample_Services_Outlet_ViewModel.TotalOutlets = result[i].TotalOutlets;
                mDiscount.Add(DataSample_Services_Outlet_ViewModel);
            }


            mAdapterDiscount = new Home_Discount_Customer_Adapter(result);
            mRecyclerViewDiscount.SetAdapter(mAdapterDiscount);

            mAdapterDiscount.ItemClick += (s, e) =>
            {
                var intent = new Intent(Activity, typeof(Customer.activity_Service_Customer));
                intent.PutExtra("ServiceId", mDiscount[e].MaDV);
                intent.PutExtra("ServiceName", mDiscount[e].NameService);
                intent.PutExtra("PromotionName", mDiscount[e].NamePromotion);
                intent.PutExtra("Index", e.ToString());
                StartActivity(intent);


                //int photoNum = e + 1;
                //Toast.MakeText(Context, "This is photo number " + photoNum, ToastLength.Short).Show();
            };
        }

        public async void GetCombo()
        {
            // lay du lieu tu db
            myAPI = RestService.For<IMyAPI>("https://goldenspa.azurewebsites.net");
            var result = await myAPI.GetListCombo();
            mCombo = new List<ListPromotion>(result.Count());


            for (int i = 0; i < result.Count; i++)
            {
                var DataSample_Services_Outlet_ViewModel = new ListPromotion();
                DataSample_Services_Outlet_ViewModel.Image = result[i].Image;
                DataSample_Services_Outlet_ViewModel.NameService = result[i].NameService;
                DataSample_Services_Outlet_ViewModel.price = result[i].price;
                DataSample_Services_Outlet_ViewModel.TotalOutlets = result[i].TotalOutlets;
                mCombo.Add(DataSample_Services_Outlet_ViewModel);

            }


            mAdapterCombo = new Home_Combo_Customer_Adapter(mCombo);
            mRecyclerViewCombo.SetAdapter(mAdapterCombo);

            mAdapterCombo.ItemClick += (s, e) =>
            {
                var intent = new Intent(Activity, typeof(Customer.activity_Service_Customer));
                intent.PutExtra("ServiceId", mCombo[e].MaDV);
                intent.PutExtra("ComboName", mCombo[e].NameService);
                intent.PutExtra("PromotionName", mCombo[e].price.ToString());
                StartActivity(intent);

            };
        }

        public async void GetOutlet()
        {
            // lay du lieu tu db
            myAPI = RestService.For<IMyAPI>("https://goldenspa.azurewebsites.net");
            var result = await myAPI.GetListChiNhanh();
            mOutlet = new List<ListOutlet>(result.Count());


            for (int i = 0; i < result.Count; i++)
            {
                var DataSample_Services_Outlet_ViewModel = new ListOutlet();
                DataSample_Services_Outlet_ViewModel.MaCN = result[i].MaCN;
                DataSample_Services_Outlet_ViewModel.Image = result[i].Image;
                DataSample_Services_Outlet_ViewModel.name = result[i].name;
                DataSample_Services_Outlet_ViewModel.address = result[i].address;
                mOutlet.Add(DataSample_Services_Outlet_ViewModel);

            }
            mAdapterOutlet = new Home_Outlet_Customer_Adapter(mOutlet);
            mRecyclerViewOutlet.SetAdapter(mAdapterOutlet);

            mAdapterOutlet.ItemClick += (s, e) =>
            {
                var intent = new Intent(Activity, typeof(Customer.activity_Outlet_Customer));
                intent.PutExtra("OutletId", mOutlet[e].MaCN);
                intent.PutExtra("OutletName", mOutlet[e].name);
                StartActivity(intent);
            };
        }

        
        public async void GetUsedService()
        {
            // lay du lieu tu db
            myAPI = RestService.For<IMyAPI>("https://goldenspa.azurewebsites.net");
            var idCustomer = await myAPI.GetIdCustomer("0123456789");
            string cus = idCustomer.Substring(2, idCustomer.Length - 4);
            var resultService = await myAPI.GetListServiceUsed(cus);
            var resultCombo = await myAPI.GetListComboUsed("KH1");
            var max = resultService.Count() + resultCombo.Count();
            mUsedService = new List<ListPromotion>(max);



            for (int i = 0; i < resultService.Count; i++)
            {
                var DataSample_Services_Outlet_ViewModel = new ListPromotion();
                DataSample_Services_Outlet_ViewModel.Image = resultService[i].Image;
                DataSample_Services_Outlet_ViewModel.NameService = resultService[i].NameService;
                DataSample_Services_Outlet_ViewModel.price = resultService[i].price;
                DataSample_Services_Outlet_ViewModel.TotalOutlets = resultService[i].TotalOutlets;
                mUsedService.Add(DataSample_Services_Outlet_ViewModel);
            }

            for (int i = resultService.Count; i < max; i++)
            {
                var DataSample_Services_Outlet_ViewModel = new ListPromotion();
                DataSample_Services_Outlet_ViewModel.Image = resultCombo[i- resultService.Count].Image;
                DataSample_Services_Outlet_ViewModel.NameService = resultCombo[i - resultService.Count].NameService;
                DataSample_Services_Outlet_ViewModel.price = resultCombo[i - resultService.Count].price;
                DataSample_Services_Outlet_ViewModel.TotalOutlets = resultCombo[i - resultService.Count].TotalOutlets;
                mUsedService.Add(DataSample_Services_Outlet_ViewModel);
            }


            mAdapterUsedService = new Home_UsedService_Customer_Adapter(mUsedService);
            mRecyclerViewUsedService.SetAdapter(mAdapterUsedService);

            mAdapterCombo.ItemClick += (s, e) =>
            {
                int photoNum = e + 1;
                Toast.MakeText(Context, "This is photo number " + photoNum, ToastLength.Short).Show();
            };
        }

    }
}