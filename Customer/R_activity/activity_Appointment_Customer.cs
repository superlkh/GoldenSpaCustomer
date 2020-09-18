using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Support.V7.Widget;
using Customer.Models;
using System.Collections.Generic;

namespace Customer
{
    //[Activity(Label = "RecycleView", MainLauncher = true, Theme = "@style/Theme.AppCompat.Light.DarkActionBar")]
    class activity_Appointment_Customer : Activity
    {
        RecyclerView.LayoutManager mLayoutManagerRecentAppointment;
        RecyclerView mRecyclerViewRecentAppointment;
        List<AppointmentInfo> mRecentAppointment_List;
        Appointment_RecentAppointment_Customer_Adapter mAdapterRecentAppointment;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource  
            SetContentView(Resource.Layout.Appointment_Customer);


            mRecyclerViewRecentAppointment = FindViewById<RecyclerView>(Resource.Id.recyclerViewRecentAppointment_Appointment_Customer);
            mLayoutManagerRecentAppointment = new LinearLayoutManager(this);
            mRecyclerViewRecentAppointment.SetLayoutManager(mLayoutManagerRecentAppointment);
            mRecentAppointment_List = new List<AppointmentInfo>();
            mAdapterRecentAppointment = new Appointment_RecentAppointment_Customer_Adapter(mRecentAppointment_List);
            mRecyclerViewRecentAppointment.SetAdapter(mAdapterRecentAppointment);



        }

        private void MAdapter_ItemClick(object sender, int e)
        {
            int photoNum = e + 1;
            Toast.MakeText(this, "This is photo number " + photoNum, ToastLength.Short).Show();
        }

    }
}