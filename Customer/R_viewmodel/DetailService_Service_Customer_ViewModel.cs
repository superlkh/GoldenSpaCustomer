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
    
    
    public class Customer_DetailService_Service_ViewModel_ViewHolder : RecyclerView.ViewHolder
    {
        public ImageView ServiceImg { get; set; }
        public TextView ServiceName { get; set; }
        public TextView Time { get; set; }
        public TextView Room { get; set; }
        public TextView Bed { get; set; }
        public CheckBox Vip { get; set; }


        public Customer_DetailService_Service_ViewModel_ViewHolder(View itemview, Action<int> listener) : base(itemview)
        {
            ServiceImg = itemview.FindViewById<ImageView>(Resource.Id.imgService_ItemService_DetailService_Customer);
            ServiceName = itemview.FindViewById<TextView>(Resource.Id.txtServiceName_ItemService_DetailService_Customer);
            Time = itemview.FindViewById<TextView>(Resource.Id.txtTime_ItemService_DetailService_Customer);
            Room = itemview.FindViewById<TextView>(Resource.Id.txtRoomNumber_ItemService_DetailService_Customer); 
            Bed = itemview.FindViewById<TextView>(Resource.Id.txtNumberBed_ItemService_DetailService_Customer);
            Vip = itemview.FindViewById<CheckBox>(Resource.Id.cbVIP_ItemService_DetailService_Customer);
            itemview.Click += (sender, e) => listener(base.Position);
        }
    }

}