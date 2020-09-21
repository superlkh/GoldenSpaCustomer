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
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using GoldenSpa.API;
using Refit;

namespace Customer.Fragment
{
    public class ShoppingCardShoppingCart : Android.Support.V4.App.Fragment
    {
        IMyAPI myAPI;

        TextView HistoryAppointment;
        ImageView imgService;
        TextView serviceName, outletName;
        Spinner outlet, date, time, therapist;

        RecyclerView.LayoutManager mLayoutManagerService;
        RecyclerView mRecyclerViewService;
        ShoppingCardShoppingCart_Service_Customer_Adapter mAdapterService;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            View dv = inflater.Inflate(Resource.Layout.ShoppingCardShoppingCart_Customer, container, false);

            HistoryAppointment = dv.FindViewById<TextView>(Resource.Id.txtAppointment_ShoppingCardHistoryAppointment_Customer);

            mRecyclerViewService = dv.FindViewById<RecyclerView>(Resource.Id.recyclerViewAppointment_ShoppingCardShoppingCart_Customer);
            mLayoutManagerService = new LinearLayoutManager(Context);
            mRecyclerViewService.SetLayoutManager(mLayoutManagerService);
            //GetListService();
            //imgService = dv.FindViewById<ImageView>(Resource.Id.imgService_ItemService_ShoppingCardShoppingCart_Customer);
            //serviceName = dv.FindViewById<TextView>(Resource.Id.txtServiceName_ItemService_ShoppingCardShoppingCart_Customer);
            //outletName = dv.FindViewById<TextView>(Resource.Id.txtOutlet_ItemAppointment_ShoppingCardHistoryAppointment_Customer);
            //outlet = dv.FindViewById<Spinner>(Resource.Layout.spnOutlet_ItemService_ShoppingCardShoppingCart_Customer);

            HistoryAppointment.Click += HistoryAppointment_Click;

            return dv;
        }

        private void HistoryAppointment_Click(object sender, EventArgs e)
        {
            var transaction = this.FragmentManager.BeginTransaction();
            transaction.Replace(Resource.Id.frame_container, new ShoppingCardHistoryAppointment(), "ShoppingCardHistoryAppointment");
            transaction.Commit(); //or CommitAllowingStateLoss
        }

        private async void GetListService()
        {
            myAPI = RestService.For<IMyAPI>("https://goldenspa.azurewebsites.net");
            var idCustomer = await myAPI.GetIdCustomer("0123456789");
            string cus = idCustomer.Substring(2, idCustomer.Length - 4);
            var result = await myAPI.GetCart(cus);

            

            //for (int i = 0; i < result.Count; i++)
            //{

            //}
            mAdapterService = new ShoppingCardShoppingCart_Service_Customer_Adapter(result);
            mRecyclerViewService.SetAdapter(mAdapterService);
        }
    }    
}