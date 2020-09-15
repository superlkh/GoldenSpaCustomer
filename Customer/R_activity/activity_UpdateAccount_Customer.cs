using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Microsoft.Extensions.DependencyModel;

namespace Customer
{
    [Activity(Label = "GoldenSpa")]
    class activity_UpdateAccount_Customer:AppCompatActivity,Android.App.DatePickerDialog.IOnDateSetListener
    {
        ImageView back;
        Button sendConfrim;
        ImageButton birth;
        EditText name, city, address, sex, phone, heigh, weight;
        TextView birthday;
        private int yearNum, monthNum, dayNum;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.UpdateAccount_Customer);

            birth = FindViewById<ImageButton>(Resource.Id.imgBirthday_UpdateAccount_Customer);
            name = FindViewById<EditText>(Resource.Id.EdtFName_UpdateAccount_Customer);
            city = FindViewById<EditText>(Resource.Id.EdtCity_UpdateAccount_Customer);
            address = FindViewById<EditText>(Resource.Id.EdtAdress_UpdateAccount_Customer);
            sex = FindViewById<EditText>(Resource.Id.EdtAdress_UpdateAccount_Customer);
            phone = FindViewById<EditText>(Resource.Id.EdtPhoneNumber_UpdateAccount_Customer);
            birthday = FindViewById<TextView>(Resource.Id.TxtChosenBirthday_UpdateAccount_Customer);
            heigh = FindViewById<EditText>(Resource.Id.edtHeight_UpdateAccount_Customer);
            weight = FindViewById<EditText>(Resource.Id.edtWeight_UpdateAccount_Customer);

            birth.Click += Birth_Click;

            GetInfo();

            back = FindViewById<ImageView>(Resource.Id.imgback_UpdateAccount_Customer);
            back.Click += Back_Click;
            sendConfrim = FindViewById<Button>(Resource.Id.BtxSendConfirm_UpdateAccount_Customer);
            sendConfrim.Click += SendConfirm_Click;
        }

        private void Birth_Click(object sender, EventArgs e)
        {
            int id = 1;
            ShowDialog(id);
        }

        private async void GetInfo()
        {
            
        }

        private void Back_Click(object sender, EventArgs e)
        {
            Finish();
            SetContentView(Resource.Layout.Account_Customer);
            var navBottom = FindViewById<Android.Support.Design.Widget.BottomNavigationView>(Resource.Id.bottom_navigation);
            navBottom.NavigationItemSelected += (s, b) =>
            {
                var trans = SupportFragmentManager.BeginTransaction();
                trans.Replace(Resource.Id.frame_container, new Fragment.Account()).Commit();
            };
        }

        private void SendConfirm_Click(object sender, EventArgs e)
        {
            Finish();
            SetContentView(Resource.Layout.Account_Customer);
            var navBottom = FindViewById<Android.Support.Design.Widget.BottomNavigationView>(Resource.Id.bottom_navigation);
            navBottom.NavigationItemSelected += (s, b) =>
            {
                var trans = SupportFragmentManager.BeginTransaction();
                trans.Replace(Resource.Id.frame_container, new Fragment.Account()).Commit();
            };
        }

        public void OnDateSet(DatePicker view, int year, int month, int dayOfMonth)
        {
            this.yearNum = year;
            this.monthNum = month + 1;
            this.dayNum = dayOfMonth;
            birthday.Text = dayNum + "/" + monthNum + "/" + yearNum;
        }

        protected override Dialog OnCreateDialog(int id)
        {
            if (id == 1)
            {
                return new Android.App.DatePickerDialog(this, this, yearNum, monthNum, dayNum);
            }
            return null;
        }
    }
}