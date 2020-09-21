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
using Customer.Models;
using GoldenSpa.API;
using Refit;

namespace Customer.Fragment
{
    public class ShoppingCardHistoryAppointment : Android.Support.V4.App.Fragment
    {
        IMyAPI myAPI;

        RecyclerView.LayoutManager mLayoutManagerAppointment;
        RecyclerView mRecyclerViewAppointment;
        List<HistoryAppointment> mAppointment_List;
        ShoppingCardHistoryAppointment_Appointment_Customer_Adapter mAdapterAppointment;

        TextView shoppingCart;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            View dv = inflater.Inflate(Resource.Layout.ShoppingCardHistoryAppointment_Customer, container, false);

            mRecyclerViewAppointment = dv.FindViewById<RecyclerView>(Resource.Id.recyclerViewAppointment_ShoppingCardHistoryAppointment_Customer);
            mLayoutManagerAppointment = new LinearLayoutManager(Context);
            mRecyclerViewAppointment.SetLayoutManager(mLayoutManagerAppointment);
            getHistoryAppointment();

            shoppingCart = dv.FindViewById<TextView>(Resource.Id.txtGioHang_ShoppingCardHistoryAppointment_Customer);
            shoppingCart.Click += ShoppingCart_Click;

            return dv;
        }

        private async void getHistoryAppointment()
        {
            myAPI = RestService.For<IMyAPI>("https://goldenspa.azurewebsites.net");
            var idCustomer = await myAPI.GetIdCustomer("0123456789");
            string cus = idCustomer.Substring(2, idCustomer.Length - 4);
            var result = await myAPI.GetHistoryAppointment(cus);
            mAdapterAppointment = new ShoppingCardHistoryAppointment_Appointment_Customer_Adapter(result);
            mRecyclerViewAppointment.SetAdapter(mAdapterAppointment);
        }

        private void ShoppingCart_Click(object sender, EventArgs e)
        {
            var transaction = this.FragmentManager.BeginTransaction();
            transaction.Replace(Resource.Id.frame_container, new ShoppingCardShoppingCart(), "ShoppingCardShoppingCart");
            transaction.Commit(); //or CommitAllowingStateLoss
        }
    }
}