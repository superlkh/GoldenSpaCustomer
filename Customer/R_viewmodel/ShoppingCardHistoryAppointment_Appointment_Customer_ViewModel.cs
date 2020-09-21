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

    public class Customer_ShoppingCardHistoryAppointment_RecentAppointment_ViewModel_ViewHolder : RecyclerView.ViewHolder
    {
        public ImageView ServiceImg { get; set; }
        public TextView OutletName { get; set; }
        public TextView Time { get; set; }
        public TextView Check { get; set; }

        public Customer_ShoppingCardHistoryAppointment_RecentAppointment_ViewModel_ViewHolder(View itemview, Action<int> listener) : base(itemview)
        {
            ServiceImg = itemview.FindViewById<ImageView>(Resource.Id.imgService_ItemAppointment_ShoppingCardHistoryAppointment_Customer);
            OutletName = itemview.FindViewById<TextView>(Resource.Id.txtOutlet_ItemAppointment_ShoppingCardHistoryAppointment_Customer);
            Time = itemview.FindViewById<TextView>(Resource.Id.txtTime_ItemAppointment_ShoppingCardHistoryAppointment_Customer);
            Check = itemview.FindViewById<TextView>(Resource.Id.txtCheck_ItemAppointment_ShoppingCardHistoryAppointment_Customer);
            itemview.Click += (sender, e) => listener(base.Position);
        }
    }

}