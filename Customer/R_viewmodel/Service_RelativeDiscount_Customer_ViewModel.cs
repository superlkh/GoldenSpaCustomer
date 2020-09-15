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
    public class Customer_Service_RelativeDiscount_ViewModel_ViewHolder : RecyclerView.ViewHolder
    {
        public ImageView ServiceImg { get; set; }
        public TextView ServiceName { get; set; }
        public TextView ServicePrice { get; set; }
        public TextView NumberOutletApply { get; set; }

        public Customer_Service_RelativeDiscount_ViewModel_ViewHolder(View itemview, Action<int> listener) : base(itemview)
        {
            ServiceImg = ItemView.FindViewById<ImageView>(Resource.Id.imgService_ItemRelativeDiscount_Service_Customer);
            ServiceName = ItemView.FindViewById<TextView>(Resource.Id.txtNameService_ItemRelativeDiscount_Service_Customer);
            ServicePrice = ItemView.FindViewById<TextView>(Resource.Id.txtServicePrice_ItemRelativeDiscount_Service_Customer);
            NumberOutletApply = ItemView.FindViewById<TextView>(Resource.Id.txtOutlet_ItemRelativeDiscount_Service_Customer);
            itemview.Click += (sender, e) => listener(base.Position);
        }
    }

}