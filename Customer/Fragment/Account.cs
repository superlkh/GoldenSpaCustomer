using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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


namespace Customer.Fragment
{
    public class Account : Android.Support.V4.App.Fragment
    {
        LinearLayout changePassword;
        LinearLayout updateAccount;
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            View dv = inflater.Inflate(Resource.Layout.Account_Customer, container, false);

            changePassword = dv.FindViewById<LinearLayout>(Resource.Id.LinearLayoutChangePass_Account_Customer);
            changePassword.Click += ChangePass_CLick;
            updateAccount = dv.FindViewById<LinearLayout>(Resource.Id.LinearLayoutUpdateAccount_Account_Customer);
            updateAccount.Click += UpdateAccount_Click;

            return dv;
        }

        private void ChangePass_CLick(object sender, EventArgs e)
        {
            StartActivity(new Android.Content.Intent(Activity, typeof(Customer.activity_ChangePassword_Customer)));
        }

        private void UpdateAccount_Click(object sender, EventArgs e)
        {
            StartActivity(new Android.Content.Intent(Activity, typeof(Customer.activity_UpdateAccount_Customer)));
        }
    }
}