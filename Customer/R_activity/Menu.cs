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

namespace Customer.R_activity
{
    [Activity(Label = "Menu", MainLauncher = true, Theme = "@style/Theme.AppCompat.Light.DarkActionBar")]
    public class Menu : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.menublank);

            var navBottom = FindViewById<Android.Support.Design.Widget.BottomNavigationView>(Resource.Id.bottom_navigation);

            navBottom.NavigationItemSelected += (s, e) =>
            {
                var trans = SupportFragmentManager.BeginTransaction();
                //e.Item.IsChecked(Resource.Id.dichvuBtn);
                switch (e.Item.ItemId)
                {
                    case Resource.Id.navigation_home_customer:
                        trans.Replace(Resource.Id.frame_container, new Fragment.Home()).Commit();
                        break;
                    case Resource.Id.navigation_appointment_customer:
                        trans.Replace(Resource.Id.frame_container, new Fragment.Appointment()).AddToBackStack(null).Commit();
                        break;
                    case Resource.Id.navigation_shoppingcart_customer:
                        trans.Replace(Resource.Id.frame_container, new Fragment.ShoppingCardShoppingCart()).AddToBackStack(null).Commit();
                        break;
                    case Resource.Id.navigation_account_customer:
                        trans.Replace(Resource.Id.frame_container, new Fragment.Account()).AddToBackStack(null).Commit();
                        break;
                }
            };

            navBottom.SelectedItemId = Resource.Id.navigation_home_customer;
        }
    }
}