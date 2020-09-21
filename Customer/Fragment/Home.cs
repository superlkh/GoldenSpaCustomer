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
        Home_Advertisement_Customer_Adapter mAdapterAdvertisement;

        RecyclerView.LayoutManager mLayoutManagerDiscount; 
        RecyclerView mRecyclerViewDiscount;
        Home_Discount_Customer_Adapter mAdapterDiscount;

        RecyclerView.LayoutManager mLayoutManagerCombo;
        RecyclerView mRecyclerViewCombo;
        Home_Combo_Customer_Adapter mAdapterCombo;

        RecyclerView.LayoutManager mLayoutManagerOutlet;
        RecyclerView mRecyclerViewOutlet;
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

            mAdapterAdvertisement = new Home_Advertisement_Customer_Adapter(result);
            mRecyclerViewAdvertisement.SetAdapter(mAdapterAdvertisement);
        }

        public async void GetDiscount()
        {
            // lay du lieu tu db
            myAPI = RestService.For<IMyAPI>("https://goldenspa.azurewebsites.net");
            var result = await myAPI.GetListPromotion();

            mAdapterDiscount = new Home_Discount_Customer_Adapter(result);
            mRecyclerViewDiscount.SetAdapter(mAdapterDiscount);

            mAdapterDiscount.ItemClick += (s, e) =>
            {
                var intent = new Intent(Activity, typeof(Customer.activity_Service_Customer));
                intent.PutExtra("ServiceId", result[e].MaDV);
                intent.PutExtra("ServiceName", result[e].NameService);
                intent.PutExtra("PromotionName", result[e].NamePromotion);
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
           
            mAdapterCombo = new Home_Combo_Customer_Adapter(result);
            mRecyclerViewCombo.SetAdapter(mAdapterCombo);

            mAdapterCombo.ItemClick += (s, e) =>
            {
                var intent = new Intent(Activity, typeof(Customer.activity_Service_Customer));
                intent.PutExtra("ServiceId", result[e].MaDV);
                intent.PutExtra("ComboName", result[e].NameService);
                intent.PutExtra("PromotionName", result[e].price.ToString());
                intent.PutExtra("Index", e.ToString());
                StartActivity(intent);

            };
        }

        public async void GetOutlet()
        {
            myAPI = RestService.For<IMyAPI>("https://goldenspa.azurewebsites.net");
            var result = await myAPI.GetListChiNhanh();
            
            mAdapterOutlet = new Home_Outlet_Customer_Adapter(result);
            mRecyclerViewOutlet.SetAdapter(mAdapterOutlet);

            mAdapterOutlet.ItemClick += (s, e) =>
            {
                var intent = new Intent(Activity, typeof(Customer.activity_Outlet_Customer));
                intent.PutExtra("OutletId", result[e].MaCN);
                intent.PutExtra("OutletName", result[e].name);
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
            var resultCombo = await myAPI.GetListComboUsed(cus);
            var max = resultService.Count() + resultCombo.Count();
            mUsedService = new List<ListPromotion>(max);



            for (int i = 0; i < resultService.Count; i++)
            {
                var DataSample_Services_Outlet_ViewModel = new ListPromotion();
                DataSample_Services_Outlet_ViewModel.MaDV = resultService[i].MaDV;
                DataSample_Services_Outlet_ViewModel.Image = resultService[i].Image;
                DataSample_Services_Outlet_ViewModel.NameService = resultService[i].NameService;
                DataSample_Services_Outlet_ViewModel.price = resultService[i].price;
                DataSample_Services_Outlet_ViewModel.TotalOutlets = resultService[i].TotalOutlets;
                mUsedService.Add(DataSample_Services_Outlet_ViewModel);
            }

            for (int i = resultService.Count; i < max; i++)
            {
                var DataSample_Services_Outlet_ViewModel = new ListPromotion();
                DataSample_Services_Outlet_ViewModel.MaDV = resultCombo[i - resultService.Count].MaDV;
                DataSample_Services_Outlet_ViewModel.Image = resultCombo[i- resultService.Count].Image;
                DataSample_Services_Outlet_ViewModel.NameService = resultCombo[i - resultService.Count].NameService;
                DataSample_Services_Outlet_ViewModel.price = resultCombo[i - resultService.Count].price;
                DataSample_Services_Outlet_ViewModel.TotalOutlets = resultCombo[i - resultService.Count].TotalOutlets;
                mUsedService.Add(DataSample_Services_Outlet_ViewModel);
            }


            mAdapterUsedService = new Home_UsedService_Customer_Adapter(mUsedService);
            mRecyclerViewUsedService.SetAdapter(mAdapterUsedService);

            mAdapterUsedService.ItemClick += (s, e) =>
            {
                var intent = new Intent(Activity, typeof(Customer.activity_Service_Customer));
                intent.PutExtra("ServiceId", mUsedService[e].MaDV);
                intent.PutExtra("ServiceName", mUsedService[e].NameService);
                intent.PutExtra("PromotionName", mUsedService[e].price.ToString());
                intent.PutExtra("Index", e.ToString());
                StartActivity(intent);
            };
        }

    }
}