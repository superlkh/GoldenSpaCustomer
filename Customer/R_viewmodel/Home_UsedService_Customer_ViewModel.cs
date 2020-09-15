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
using System.ComponentModel.DataAnnotations;

namespace Customer
{
    public class Customer_Home_UsedService_ViewModel_ViewHolder : RecyclerView.ViewHolder
    {
        public ImageView ServiceImg { get; set; }
        public TextView ServiceName { get; set; }
        public TextView ServicePrice { get; set; }
        public TextView NumberOutletApply { get; set; }

        public Customer_Home_UsedService_ViewModel_ViewHolder(View itemview, Action<int> listener) : base(itemview)
        {
            ServiceImg = ItemView.FindViewById<ImageView>(Resource.Id.imgService_ItemUsedService_Home_Customer);
            ServiceName = ItemView.FindViewById<TextView>(Resource.Id.txtNameService_ItemUsedService_Home_Customer);
            ServicePrice = ItemView.FindViewById<TextView>(Resource.Id.txtPriceService_ItemUsedService_Home_Customer);
            NumberOutletApply = ItemView.FindViewById<TextView>(Resource.Id.txtNumberOutletApply_ItemUsedService_Home_Customer);
            itemview.Click += (sender, e) => listener(base.Position);
        }
    }

}