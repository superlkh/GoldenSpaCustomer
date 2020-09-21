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
using Customer.Models;
using GoldenSpa.API;
using Refit;

namespace Customer.Fragment
{
    public class Appointment : Android.Support.V4.App.Fragment
    {
        IMyAPI myAPI;

        RecyclerView.LayoutManager mLayoutManagerRecentAppointment;
        RecyclerView mRecyclerViewRecentAppointment;
        Appointment_RecentAppointment_Customer_Adapter mAdapterRecentAppointment;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View dv = inflater.Inflate(Resource.Layout.Appointment_Customer, container, false);

            mRecyclerViewRecentAppointment = dv.FindViewById<RecyclerView>(Resource.Id.recyclerViewRecentAppointment_Appointment_Customer);
            mLayoutManagerRecentAppointment = new LinearLayoutManager(Context);
            mRecyclerViewRecentAppointment.SetLayoutManager(mLayoutManagerRecentAppointment);
            getAppointmentList();

            return dv;
        }

        public async void getAppointmentList()
        {
            myAPI = RestService.For<IMyAPI>("https://goldenspa.azurewebsites.net");
            var idCustomer = await myAPI.GetIdCustomer("0123456789");
            string cus = idCustomer.Substring(2, idCustomer.Length - 4);
            var result = await myAPI.GetAppointment(cus);
            mAdapterRecentAppointment = new Appointment_RecentAppointment_Customer_Adapter(result);
            mRecyclerViewRecentAppointment.SetAdapter(mAdapterRecentAppointment);

            //mAdapterRecentAppointment.NotifyItemRemoved

            mAdapterRecentAppointment.ItemClick += (s, e) =>
            {
                var intent = new Intent(Activity, typeof(Customer.activity_DetailAppointmentCustomer));
                intent.PutExtra("AppointmentId", result[e].MaLichHen);
                StartActivity(intent);
            };
        }
    }
}