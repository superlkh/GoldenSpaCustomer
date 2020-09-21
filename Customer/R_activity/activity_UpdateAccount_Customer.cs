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
using Customer.Models;
using GoldenSpa.API;
using Java.Sql;
using Microsoft.Extensions.DependencyModel;
using Refit;

namespace Customer
{
    [Activity(Label = "GoldenSpa")]
    public class activity_UpdateAccount_Customer:AppCompatActivity,Android.App.DatePickerDialog.IOnDateSetListener
    {
        IMyAPI myAPI;

        ImageView back;
        ImageButton birth, map2;
        EditText name, email, heigh, weight;
        TextView birthday, address, phone;
        RadioButton male, female;
        Button sendConfrim;
        int cday, cmonth, cyear, flag = 0;

        private int yearNum, monthNum, dayNum;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.UpdateAccount_Customer);

            back = FindViewById<ImageView>(Resource.Id.imgback_UpdateAccount_Customer);
            name = FindViewById<EditText>(Resource.Id.EdtName_UpdateAccount_Customer);
            email = FindViewById<EditText>(Resource.Id.EdtEmail_UpdateAccount_Customer);
            address = FindViewById<TextView>(Resource.Id.txtAdress_UpdateAccount_Customer);
            map2 = FindViewById<ImageButton>(Resource.Id.imgbtxMap_Account_Customer);
            male = FindViewById<RadioButton>(Resource.Id.RadioBtxSex_male_UpdateAccount_Customer);
            female = FindViewById<RadioButton>(Resource.Id.RadioBtxSex_female_UpdateAccount_Customer);
            phone = FindViewById<TextView>(Resource.Id.EdtPhoneNumber_UpdateAccount_Customer);
            birthday = FindViewById<TextView>(Resource.Id.TxtChosenBirthday_UpdateAccount_Customer);
            birth = FindViewById<ImageButton>(Resource.Id.imgBirthday_UpdateAccount_Customer);
            heigh = FindViewById<EditText>(Resource.Id.edtHeight_UpdateAccount_Customer);
            weight = FindViewById<EditText>(Resource.Id.edtWeight_UpdateAccount_Customer);
            sendConfrim = FindViewById<Button>(Resource.Id.BtxSendConfirm_UpdateAccount_Customer);

            GetInfo();

            back.Click += Back_Click;
            birth.Click += Birth_Click;
            map2.Click += Map2_Click;







            sendConfrim.Click += SendConfirm_Click;
        }

        private void Map2_Click(object sender, EventArgs e)
        {
            Finish();
            StartActivity(new Intent(this, typeof(Customer.Activity_Map_Customer)));
        }

        private async void GetInfo()
        {
            myAPI = RestService.For<IMyAPI>("https://goldenspa.azurewebsites.net");
            var customerId = await myAPI.GetIdCustomer("0123456789");
            customerId = customerId.Substring(2, customerId.Length - 4);
            var result = await myAPI.GetCustomerInfo(customerId);
            name.Text = result.tenKh;
            email.Text = result.email;
            if (Intent.GetStringExtra("tt") == "1")
                address.Text = Intent.GetStringExtra("addrData");
            else
                address.Text = result.diaChi;
            phone.Text = result.sdt;
            if (result.gioitinh == true)
                male.Checked = true;
            else
                female.Checked = true;
            birthday.Text = (result.ngaySinh ?? default(DateTime)).ToString("dd-MM-yyyy");
            cday = Int32.Parse(((result.ngaySinh ?? default(DateTime)).ToString("dd-MM-yyyy")).Substring(0, 2));
            cmonth = Int32.Parse(((result.ngaySinh ?? default(DateTime)).ToString("dd-MM-yyyy")).Substring(3, 2));
            cyear = Int32.Parse(((result.ngaySinh ?? default(DateTime)).ToString("dd-MM-yyyy")).Substring(6, 4));
            //Toast.MakeText(this, result.NgaySinh.ToString(), ToastLength.Short).Show();
            heigh.Text = result.chieuCao.ToString();
            weight.Text = result.canNang.ToString();
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

        private void Birth_Click(object sender, EventArgs e)
        {
            int id = 1;
            ShowDialog(id);
        }

        public void OnDateSet(DatePicker view, int year, int month, int dayOfMonth)
        {
            this.yearNum = year;    
            this.monthNum = month + 1;
            this.dayNum = dayOfMonth;
            cday = dayOfMonth;
            cmonth = month + 1;
            cyear = year;
            birthday.Text = dayNum + "-" + monthNum + "-" + yearNum;
            flag = 1;
        }

        protected override Dialog OnCreateDialog(int id)
        {
            if (id == 1)
            {
                return new Android.App.DatePickerDialog(this, this, yearNum, monthNum, dayNum);
            }
            return null;
        }

        private async void SendConfirm_Click(object sender, EventArgs e)
        {
            myAPI = RestService.For<IMyAPI>("https://goldenspa.azurewebsites.net");
            CustomerInfo customer = new CustomerInfo();
            customer.maKh = Intent.GetStringExtra("MaKH");
            customer.tenKh = name.Text;
            customer.email = email.Text;
            customer.diaChi = address.Text;
            if (male.Checked == true)
                customer.gioitinh = true;
            else
                customer.gioitinh = false;
            customer.sdt = phone.Text;
            DateTime ngaysinh;
            ngaysinh = new DateTime(cyear, cmonth, cday);
            customer.ngaySinh = ngaysinh;
            if (heigh.Text.ToString() == "")
                customer.chieuCao = null;
            else
                customer.chieuCao = Int32.Parse(heigh.Text);
            if (weight.Text.ToString() == "")
                customer.canNang = null;
            else
                customer.canNang = Int32.Parse(weight.Text);
            customer.anhKh = Intent.GetStringExtra("AnhKH");
            var notice = await myAPI.UpdateCustomerInfo(customer.maKh,customer);
            Toast.MakeText(this, notice.ToString(), ToastLength.Short).Show();

        }
    }
}