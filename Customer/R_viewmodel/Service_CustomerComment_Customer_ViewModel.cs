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
    
    public class Customer_Service_CustomerComment_ViewModel_ViewHolder : RecyclerView.ViewHolder
    {
        public ImageView Img { get; set; }
        public TextView Name { get; set; }
        public TextView Comment { get; set; }
        public TextView Date { get; set; }


        public Customer_Service_CustomerComment_ViewModel_ViewHolder(View itemview, Action<int> listener) : base(itemview)
        {
            Img = ItemView.FindViewById<ImageView>(Resource.Id.ImgCustomer_ItemCustomerComment_Service_Customer);
            Name = ItemView.FindViewById<TextView>(Resource.Id.txtCustomerName_ItemCustomerComment_Service_Customer);
            Comment = ItemView.FindViewById<TextView>(Resource.Id.txtCustomerComment_ItemCustomerComment_Service_Customer);
            Date = ItemView.FindViewById<TextView>(Resource.Id.txtDate_ItemCustomerComment_Service_Customer);
            itemview.Click += (sender, e) => listener(base.Position);
        }
    }

}