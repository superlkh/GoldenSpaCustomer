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
using GoldenSpa.API;
using Refit;
using Square.Picasso;

namespace Customer.Fragment
{
    public class Account : Android.Support.V4.App.Fragment
    {
        IMyAPI myAPI;

        ImageView avar;
        TextView customerName;
        LinearLayout changePassword;
        LinearLayout updateAccount;
        string idCustomer, imageCustomer;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View dv = inflater.Inflate(Resource.Layout.Account_Customer, container, false);

            avar = dv.FindViewById<ImageView>(Resource.Id.imgCustomer_Account_Customer);
            customerName = dv.FindViewById<TextView>(Resource.Id.txtCustomerName_Account_Customer);
            getInfoCustomer();

            changePassword = dv.FindViewById<LinearLayout>(Resource.Id.LinearLayoutChangePass_Account_Customer);
            changePassword.Click += ChangePass_CLick;
            updateAccount = dv.FindViewById<LinearLayout>(Resource.Id.LinearLayoutUpdateAccount_Account_Customer);
            updateAccount.Click += UpdateAccount_Click;

            return dv;
        }

        private async void getInfoCustomer()
        {
            myAPI = RestService.For<IMyAPI>("https://goldenspa.azurewebsites.net");
            idCustomer = await myAPI.GetIdCustomer("0123456789");
            string cus = idCustomer.Substring(2, idCustomer.Length - 4);
            var customerInfo = await myAPI.GetCustomerInfo(cus);
            idCustomer = cus;

            imageCustomer = customerInfo.anhKh;

            Picasso.Get().Load(customerInfo.anhKh).Into(avar);
            customerName.Text = customerInfo.tenKh;
        }

        private void ChangePass_CLick(object sender, EventArgs e)
        {
            StartActivity(new Android.Content.Intent(Activity, typeof(Customer.activity_ChangePassword_Customer)));
        }

        private void UpdateAccount_Click(object sender, EventArgs e)
        {
            var intent = new Intent(Activity,typeof(Customer.activity_UpdateAccount_Customer));
            intent.PutExtra("MaKH", idCustomer);
            intent.PutExtra("AnhKH", imageCustomer);
            StartActivity(intent);
        }
    }
}