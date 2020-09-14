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


namespace Customer.Fragment
{
    public class ShoppingCardHistoryAppointment : Android.Support.V4.App.Fragment
    {
        RecyclerView.LayoutManager mLayoutManagerAppointment;
        RecyclerView mRecyclerViewAppointment;
        Customer_ShoppingCardHistoryAppointment_RecentAppointment_ViewModel_List mAppointment_List;
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
            mAppointment_List = new Customer_ShoppingCardHistoryAppointment_RecentAppointment_ViewModel_List();
            mAdapterAppointment = new ShoppingCardHistoryAppointment_Appointment_Customer_Adapter(mAppointment_List);
            mRecyclerViewAppointment.SetAdapter(mAdapterAppointment);

            shoppingCart = dv.FindViewById<TextView>(Resource.Id.txtGioHang_ShoppingCardHistoryAppointment_Customer);
            shoppingCart.Click += ShoppingCart_Click;

            return dv;
        }

        private void ShoppingCart_Click(object sender, EventArgs e)
        {
            var transaction = this.FragmentManager.BeginTransaction();
            transaction.Replace(Resource.Id.frame_container, new ShoppingCardShoppingCart(), "ShoppingCardShoppingCart");
            transaction.Commit(); //or CommitAllowingStateLoss
        }
    }
}