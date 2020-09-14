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
    
    public class Customer_Home_Outlet_ViewModel_ViewHolder : RecyclerView.ViewHolder
    {
        public ImageView OutletImg { get; set; }
        public TextView OutletName { get; set; }
        public TextView OutletAdress { get; set; }


        public Customer_Home_Outlet_ViewModel_ViewHolder(View itemview, Action<int> listener) : base(itemview)
        {
            OutletImg = itemview.FindViewById<ImageView>(Resource.Id.imgOutlet_ItemOutlet_Home_Customer);
            OutletName = itemview.FindViewById<TextView>(Resource.Id.txtOutletName_ItemOutlet_Home_Customer);
            OutletAdress = itemview.FindViewById<TextView>(Resource.Id.txtAdress_ItemOutlet_Home_Customer);
            itemview.Click += (sender, e) => listener(base.Position);
        }
    }

}