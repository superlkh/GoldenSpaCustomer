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

    public class Customer_ShoppingCardShoppingCart_Service_ViewModel_ViewHolder : RecyclerView.ViewHolder
    {
        public ImageView ServiceImg { get; set; }
        public TextView OutletName { get; set; }
        public TextView ServiceName { get; set; }
        public Spinner Outlet { get; set; }
        public TextView Date { get; set; }
        public ImageButton imgbtxDate { get; set; }
        public Spinner Time { get; set; }
        public RadioButton RadioTherapistYes { get; set; }
        public RadioButton RadioTherapistNo { get; set; }
        public Spinner Therapist { get; set; }
        public TextView Check { get; set; }

        public Customer_ShoppingCardShoppingCart_Service_ViewModel_ViewHolder(View itemview, Action<int> listener) : base(itemview)
        {
            ServiceImg = itemview.FindViewById<ImageView>(Resource.Id.imgService_ItemAppointment_ShoppingCardHistoryAppointment_Customer);
            OutletName = itemview.FindViewById<TextView>(Resource.Id.txtOutlet_ItemAppointment_ShoppingCardHistoryAppointment_Customer);
            ServiceName = itemview.FindViewById<TextView>(Resource.Id.txtServiceName_ItemService_ShoppingCardShoppingCart_Customer);
            Date = itemview.FindViewById<TextView>(Resource.Id.TxtDate_ItemService_ShoppingCardShoppingCart_Customer);
            Outlet = itemview.FindViewById<Spinner>(Resource.Id.spnOutlet_ItemService_ShoppingCardShoppingCart_Customer);
            Time = itemview.FindViewById<Spinner>(Resource.Id.spnTime_ItemService_ShoppingCardShoppingCart_Customer);
            Therapist = itemview.FindViewById<Spinner>(Resource.Id.spnTherapist_ItemService_ShoppingCardShoppingCart_Customer);
            imgbtxDate = itemview.FindViewById<ImageButton>(Resource.Id.imgDate_ItemService_ShoppingCardShoppingCart_Customer);
            RadioTherapistYes = itemview.FindViewById<RadioButton>(Resource.Id.RadioBtxTherapist_Yes__ItemService_ShoppingCardShoppingCart_Customer);
            RadioTherapistNo = itemview.FindViewById<RadioButton>(Resource.Id.RadioBtxTherapist_No__ItemService_ShoppingCardShoppingCart_Customer);
            Check = itemview.FindViewById<TextView>(Resource.Id.cbRoom_ItemService_ShoppingCardShoppingCart_Customer);
            itemview.Click += (sender, e) => listener(base.LayoutPosition);
        }
    }

}