using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Support.V7.Widget;
using System;
using System.Collections.Generic;
using Square.OkHttp3;

namespace Customer
{
    //[Activity(Label = "RecycleView", MainLauncher = true, Theme = "@style/Theme.AppCompat.Light.DarkActionBar")]
    class activity_BookAppointment_Customer : AppCompatActivity
    {

        RecyclerView.LayoutManager mLayoutManagerTime;
        RecyclerView mRecyclerViewTime;
        Customer_BookAppointment_Time_ViewModel_List mTime_List;
        BookAppointment_Time_Customer_Adapter mAdapterTime;

        RecyclerView.LayoutManager mLayoutManagerTherapist;
        RecyclerView mRecyclerViewTherapist;
        Customer_BookAppointment_Therapist_ViewModel_List mTherapist_List;
        BookAppointment_Therapist_Customer_Adapter mAdapterTherapist;

        ImageView back;
        Button finish;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource  
            SetContentView(Resource.Layout.BookAppointment_Customer);


            mRecyclerViewTime = FindViewById<RecyclerView>(Resource.Id.recyclerViewTime_BookAppointment_Customer);
            mLayoutManagerTime = new LinearLayoutManager(this, LinearLayoutManager.Horizontal, false);
            mRecyclerViewTime.SetLayoutManager(mLayoutManagerTime);
            mTime_List = new Customer_BookAppointment_Time_ViewModel_List();
            mAdapterTime = new BookAppointment_Time_Customer_Adapter(mTime_List);
            mRecyclerViewTime.SetAdapter(mAdapterTime);



            mRecyclerViewTherapist = FindViewById<RecyclerView>(Resource.Id.recyclerViewTherapist_BookAppointment_Customer);
            mLayoutManagerTherapist = new LinearLayoutManager(this, LinearLayoutManager.Horizontal, false);
            mRecyclerViewTherapist.SetLayoutManager(mLayoutManagerTherapist);
            mTherapist_List = new Customer_BookAppointment_Therapist_ViewModel_List();
            mAdapterTherapist = new BookAppointment_Therapist_Customer_Adapter(mTherapist_List);
            mRecyclerViewTherapist.SetAdapter(mAdapterTherapist);

            Spinner spinner = FindViewById<Spinner>(Resource.Id.spnOutlet_BookAppointment_Customer);

            var adapter = ArrayAdapter.CreateFromResource(
                    this, Resource.Array.planets_array, Resource.Layout.item_Spinner);

            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinner.Adapter = adapter;

            back = FindViewById<ImageView>(Resource.Id.imgback_BookAppointment_Customer);
            finish = FindViewById<Button>(Resource.Id.BtxSendConfirm_BookAppointment_Customer);
            back.Click += Back_Click;
            finish.Click += Finish_Click;

        }

        private void Back_Click(object sender, EventArgs e)
        {
            Finish();
            StartActivity(new Android.Content.Intent(this, typeof(Customer.activity_Service_Customer)));
        }

        private void Finish_Click(object sender, EventArgs e)
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