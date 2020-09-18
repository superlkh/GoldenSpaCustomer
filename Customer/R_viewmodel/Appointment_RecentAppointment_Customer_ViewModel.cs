using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace Customer
{
    public class Customer_Appointment_RecentAppointment_ViewModel_ViewHolder : RecyclerView.ViewHolder
    {
        public ImageView ServiceImg { get; set; }
        public TextView TotalService { get; set; }
        public TextView OutletName { get; set; }
        public TextView Time { get; set; }

        public Customer_Appointment_RecentAppointment_ViewModel_ViewHolder(View itemview, Action<int> listener) : base(itemview)
        {
            ServiceImg = ItemView.FindViewById<ImageView>(Resource.Id.imgService_ItemRecentAppointment_Appointment_Customer);
            TotalService = ItemView.FindViewById<TextView>(Resource.Id.txtTotalOutlet_ItemRecentAppointment_Appointment_Customer);
            OutletName = ItemView.FindViewById<TextView>(Resource.Id.txtOutletName_ItemRecentAppointment_Appointment_Customer);
            Time = ItemView.FindViewById<TextView>(Resource.Id.txtTime_ItemRecentAppointment_Appointment_Customer);
            itemview.Click += (sender, e) => listener(base.Position);
        }
    }

}