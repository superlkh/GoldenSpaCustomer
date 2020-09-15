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

namespace Customer.R_viewmodel
{
    public class Customer_Home_Combo_ViewModel_ViewHolder : RecyclerView.ViewHolder
    {
        public ImageView ServiceImg { get; set; }
        public TextView ServiceName { get; set; }
        public TextView ServicePrice { get; set; }
        public TextView NumberOutletApply { get; set; }

        public Customer_Home_Combo_ViewModel_ViewHolder(View itemview, Action<int> listener) : base(itemview)
        {
            ServiceImg = itemview.FindViewById<ImageView>(Resource.Id.imgDiscount_ItemDiscount_Home_Customer);
            ServiceName = itemview.FindViewById<TextView>(Resource.Id.txtNameServiceDiscount_ItemDiscount_Home_Customer);
            ServicePrice = itemview.FindViewById<TextView>(Resource.Id.txtPriceServiceDiscount_ItemDiscount_Home_Customer);
            NumberOutletApply = itemview.FindViewById<TextView>(Resource.Id.txtNumberOutletApply_ItemDiscount_Home_Customer);
            itemview.Click += (sender, e) => listener(base.Position);
        }
    }
}