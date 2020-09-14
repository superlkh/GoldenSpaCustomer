using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Util;
using Android.Views;
using Android.Widget;


namespace Customer.Fragment
{
    public class Appointment : Android.Support.V4.App.Fragment
    {
        RecyclerView.LayoutManager mLayoutManagerRecentAppointment;
        RecyclerView mRecyclerViewRecentAppointment;
        Customer_Appointment_RecentAppointment_ViewModel_List mRecentAppointment_List;
        Appointment_RecentAppointment_Customer_Adapter mAdapterRecentAppointment;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            View dv = inflater.Inflate(Resource.Layout.Appointment_Customer, container, false);

            mRecyclerViewRecentAppointment = dv.FindViewById<RecyclerView>(Resource.Id.recyclerViewRecentAppointment_Appointment_Customer);
            mLayoutManagerRecentAppointment = new LinearLayoutManager(Context);
            mRecyclerViewRecentAppointment.SetLayoutManager(mLayoutManagerRecentAppointment);
            mRecentAppointment_List = new Customer_Appointment_RecentAppointment_ViewModel_List();
            mAdapterRecentAppointment = new Appointment_RecentAppointment_Customer_Adapter(mRecentAppointment_List);
            mRecyclerViewRecentAppointment.SetAdapter(mAdapterRecentAppointment);

            return dv;
        }
    }
}