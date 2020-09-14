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

namespace Customer
{
    [Activity(Label = "GoldenSpa")]
    class activity_ChangePassword_Customer : AppCompatActivity
    {
        ImageView back;
        Button sendConfirm;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource  
            SetContentView(Resource.Layout.ChangePassword_Customer);

            back = FindViewById<ImageView>(Resource.Id.imgback_ChangePassword_Customer);
            back.Click += Back_Click;
            sendConfirm = FindViewById<Button>(Resource.Id.BtxSendConfirm_ChangePassword_Customer);
            sendConfirm.Click += SendConfirm_Click;
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
    }
}