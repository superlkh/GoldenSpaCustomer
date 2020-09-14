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
    class activity_UpdateInfo_Customer:AppCompatActivity
    {
        Button skip, continuee;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource  
            SetContentView(Resource.Layout.UpdateInfo_Customer);
            skip = FindViewById<Button>(Resource.Id.BtxSkip_UpdateIno_Customer);
            continuee = FindViewById<Button>(Resource.Id.BtxContinue_UpdateIno_Customer);
            skip.Click += Skip_Click;
            continuee.Click += Continue_Click;
        }

        private void Skip_Click(object sender, EventArgs e)
        {
            Finish();
            SetContentView(Resource.Layout.Home_Customer);
            var navBottom = FindViewById<Android.Support.Design.Widget.BottomNavigationView>(Resource.Id.bottom_navigation);
            navBottom.NavigationItemSelected += (s, c) =>
            {
                var trans = SupportFragmentManager.BeginTransaction();
                trans.Replace(Resource.Id.frame_container, new Fragment.Home()).Commit();
            };
        }

        private void Continue_Click(object sender, EventArgs e)
        {
            Finish();
            SetContentView(Resource.Layout.Home_Customer);
            var navBottom = FindViewById<Android.Support.Design.Widget.BottomNavigationView>(Resource.Id.bottom_navigation);
            navBottom.NavigationItemSelected += (s, c) =>
            {
                var trans = SupportFragmentManager.BeginTransaction();
                trans.Replace(Resource.Id.frame_container, new Fragment.Home()).Commit();
            };
        }
    }
}