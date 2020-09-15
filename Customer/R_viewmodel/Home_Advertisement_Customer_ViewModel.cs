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
    public class Customer_Home_Advertisement_ViewModel_ViewHolder : RecyclerView.ViewHolder
    {
        public ImageView AdvertisementImg { get; set; }


        public Customer_Home_Advertisement_ViewModel_ViewHolder(View itemview, Action<int> listener) : base(itemview)
        {
            AdvertisementImg = itemview.FindViewById<ImageView>(Resource.Id.imgAdvertisement_ItemAdvertisement_Home_Customer);
            itemview.Click += (sender, e) => listener(base.Position);
        }
    }

}