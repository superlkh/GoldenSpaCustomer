using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;


using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.V7.App;

namespace Customer.Fragment
{
    public class ShoppingCardShoppingCart : Android.Support.V4.App.Fragment
    {

        TextView HistoryAppointment;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            View dv = inflater.Inflate(Resource.Layout.ShoppingCardShoppingCart_Customer, container, false);

            HistoryAppointment = dv.FindViewById<TextView>(Resource.Id.txtAppointment_ShoppingCardHistoryAppointment_Customer);
            HistoryAppointment.Click += HistoryAppointment_Click;

            return dv;
        }

        private void HistoryAppointment_Click(object sender, EventArgs e)
        {
            var transaction = this.FragmentManager.BeginTransaction();
            transaction.Replace(Resource.Id.frame_container, new ShoppingCardHistoryAppointment(), "ShoppingCardHistoryAppointment");
            transaction.Commit(); //or CommitAllowingStateLoss
        }
    }    
}