using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Support.V7.Widget;
using System;
using GoldenSpa.API;
using Refit;
using Square.Picasso;
using Android.Content;

namespace Customer
{
    [Activity(Label = "RecycleView", Theme = "@style/Theme.AppCompat.Light.DarkActionBar")]
    class activity_DetailAppointmentCustomer : AppCompatActivity
    {
        IMyAPI myAPI;

        ImageView back, image;
        TextView outletName, address, customerName, phone, time, date, totalPrice, totalService, detail;
        string maLH;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource  
            SetContentView(Resource.Layout.DetailAppointment_Customer);

            back = FindViewById<ImageView>(Resource.Id.imgback_DetailAppointment_Customer);
            image = FindViewById<ImageView>(Resource.Id.imgOutlet_DetailAppointment_Customer);
            outletName = FindViewById<TextView>(Resource.Id.txtOutletName_DetailAppointment_Customer);
            address = FindViewById<TextView>(Resource.Id.txtAdress_DetailAppointment_Customer);
            customerName = FindViewById<TextView>(Resource.Id.txtCustomerName_DetailAppointment_Customer);
            phone = FindViewById<TextView>(Resource.Id.txtPhone_DetailAppointment_Customer);
            time = FindViewById<TextView>(Resource.Id.txtTime_DetailAppointment_Customer);
            date = FindViewById<TextView>(Resource.Id.txtDate_DetailAppointment_Customer);
            totalPrice = FindViewById<TextView>(Resource.Id.txtTotalPrice_DetailAppointment_Customer);
            totalService = FindViewById<TextView>(Resource.Id.txtTotalService_DetailAppointment_Customer);
            detail = FindViewById<TextView>(Resource.Id.txtXemchitiet_DetailAppointment_Customer);

            back.Click += Back_Click;
            getAppointmentDetail();
            detail.Click += Detail_Click;
        }

        
        private void Back_Click(object sender, EventArgs e)
        {
            Finish();
            SetContentView(Resource.Layout.Appointment_Customer);
            var navBottom = FindViewById<Android.Support.Design.Widget.BottomNavigationView>(Resource.Id.bottom_navigation);
            navBottom.NavigationItemSelected += (s, b) =>
            {
                var trans = SupportFragmentManager.BeginTransaction();
                trans.Replace(Resource.Id.frame_container, new Fragment.Appointment()).Commit();
            };
        }
        
        private async void getAppointmentDetail()
        {
            myAPI = RestService.For<IMyAPI>("https://goldenspa.azurewebsites.net");
            string id = Intent.GetStringExtra("AppointmentId");
            var result = await myAPI.GetAppointmentDetail(id);

            maLH = result[0].MaLichHen;
            Picasso.Get().Load(result[0].AnhChiNhanh).Into(image);
            outletName.Text = result[0].TenChiNhanh;
            address.Text = result[0].DiaChi;
            customerName.Text = result[0].TenKH;
            phone.Text = result[0].sdt;
            time.Text = result[0].GioHen.ToString();
            date.Text = result[0].NgayHen.ToString();
            totalPrice.Text = result[0].Gia.ToString();
            totalService.Text = result[0].TongDv.ToString();
        }

        private void Detail_Click(object sender, EventArgs e)
        {
            Finish();
            var intent = new Intent(this, typeof(Customer.activity_DetailService_Customer));
            intent.PutExtra("MaLH", maLH);
            StartActivity(intent);
        }

    }
}