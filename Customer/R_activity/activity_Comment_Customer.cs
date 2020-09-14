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
using Square.OkHttp3;

namespace Customer
{
    //[Activity(Label = "RecycleView", MainLauncher = true, Theme = "@style/Theme.AppCompat.Light.DarkActionBar")]
    class activity_Comment_Customer:AppCompatActivity
    {
        ImageView close;
        Button sendComment;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource  
            SetContentView(Resource.Layout.Comment_Customer);

            close = FindViewById<ImageView>(Resource.Id.imgclose_Comment_Customer);
            sendComment = FindViewById<Button>(Resource.Id.BtxSendComment_Comment_Customer);
            close.Click += Close_Click;
            sendComment.Click += SendComment_Click;
        }

        private void Close_Click(object sender, EventArgs e)
        {
            Finish();
            SetContentView(Resource.Layout.Home_Customer);
            var navBottom = FindViewById<Android.Support.Design.Widget.BottomNavigationView>(Resource.Id.bottom_navigation);
            navBottom.NavigationItemSelected += (s, b) =>
            {
                var trans = SupportFragmentManager.BeginTransaction();
                trans.Replace(Resource.Id.frame_container, new Fragment.Home()).Commit();
            };
        }

        private void SendComment_Click(object sender, EventArgs e)
        {
            Finish();
            SetContentView(Resource.Layout.Home_Customer);
            var navBottom = FindViewById<Android.Support.Design.Widget.BottomNavigationView>(Resource.Id.bottom_navigation);
            navBottom.NavigationItemSelected += (s, b) =>
            {
                var trans = SupportFragmentManager.BeginTransaction();
                trans.Replace(Resource.Id.frame_container, new Fragment.Home()).Commit();
            };
        }
    }
}