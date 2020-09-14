using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Support.V7.Widget;
using System;

namespace Customer
{
    //[Activity(Label = "RecycleView", MainLauncher = true, Theme = "@style/Theme.AppCompat.Light.DarkActionBar")]
    class activity_DetailAppointmentCustomer : AppCompatActivity
    {

        ImageView back;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource  
            SetContentView(Resource.Layout.DetailAppointment_Customer);

            back = FindViewById<ImageView>(Resource.Id.imgback_DetailAppointment_Customer);
            back.Click += Back_Click;


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
        
    }
}