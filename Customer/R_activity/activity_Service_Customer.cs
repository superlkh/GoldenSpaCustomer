using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Support.V7.Widget;
using System;
using Microcharts.Droid;
using Microcharts;
using System.Collections.Generic;
using SkiaSharp;

namespace Customer
{
    //[Activity(Label = "Menu", MainLauncher = true, Theme = "@style/Theme.AppCompat.Light.DarkActionBar")]
    //[Activity(Label = "Service")]
    class activity_Service_Customer : AppCompatActivity
    {

        RecyclerView.LayoutManager mLayoutManagerCustomerComment;
        RecyclerView mRecyclerViewCustomerComment;
        Customer_Service_CustomerComment_ViewModel_List mCustomerComment_List;
        Service_CustomerComment_Customer_Adapter mAdapterCustomerComment;

        RecyclerView.LayoutManager mLayoutManagerRelativeDiscount;
        RecyclerView mRecyclerViewRelativeDiscount;
        Customer_Service_RelativeDiscount_ViewModel_List mRelativeDiscount_List;
        Service_RelativeDiscount_Customer_Adapter mAdapterRelativeDiscount;

        ImageView back;

        ChartView cv;
        TextView rateStar;
        int[] star = { 0, 0, 0, 0, 0 };


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource  
            SetContentView(Resource.Layout.Service_Customer);

            mRecyclerViewCustomerComment = FindViewById<RecyclerView>(Resource.Id.recyclerViewCustomerComment_Service_Customer);
            mLayoutManagerCustomerComment = new LinearLayoutManager(this);
            mRecyclerViewCustomerComment.SetLayoutManager(mLayoutManagerCustomerComment);
            mCustomerComment_List = new Customer_Service_CustomerComment_ViewModel_List();
            mAdapterCustomerComment = new Service_CustomerComment_Customer_Adapter(mCustomerComment_List);
            mRecyclerViewCustomerComment.SetAdapter(mAdapterCustomerComment);


            mRecyclerViewRelativeDiscount = FindViewById<RecyclerView>(Resource.Id.recyclerViewRelativeDiscount_Service_Customer);
            mLayoutManagerRelativeDiscount = new LinearLayoutManager(this);
            mRecyclerViewRelativeDiscount.SetLayoutManager(mLayoutManagerRelativeDiscount);
            mRelativeDiscount_List = new Customer_Service_RelativeDiscount_ViewModel_List();
            mAdapterRelativeDiscount = new Service_RelativeDiscount_Customer_Adapter(mRelativeDiscount_List);
            mRecyclerViewRelativeDiscount.SetAdapter(mAdapterRelativeDiscount);


            cv = (ChartView)FindViewById(Resource.Id.chartView1);
            rateStar = FindViewById<TextView>(Resource.Id.txtRateStar_Service_Customer);
            DoAll();
            


            back = FindViewById<ImageView>(Resource.Id.imgback_Service_Customer);
            back.Click += Back_Click;

        }


        public async void Drawchart()
        {
            List<ChartEntry> dataList = new List<ChartEntry>();
            dataList.Add(new ChartEntry((float)star[0])
            {
                Label = "1.0",
                ValueLabel = star[0].ToString(),
                Color = SKColor.Parse("#FF0")
            });


            dataList.Add(new ChartEntry((float)star[1])
            {
                Label = "2.0",
                ValueLabel = star[1].ToString(),
                Color = SKColor.Parse("#FF0")
            });


            dataList.Add(new ChartEntry((float)star[2])
            {
                Label = "3.0",
                ValueLabel = star[2].ToString(),
                Color = SKColor.Parse("#FF0")
            });


            dataList.Add(new ChartEntry((float)star[3])
            {
                Label = "4.0",
                ValueLabel = star[3].ToString(),
                Color = SKColor.Parse("#FF0")
            });


            dataList.Add(new ChartEntry((float)star[4])
            {
                Label = "5.0",
                ValueLabel = star[4].ToString(),
                Color = SKColor.Parse("#FF0"),
                
            });


            var chart = new BarChart() { Entries = dataList, LabelTextSize = 30f, LabelOrientation = Microcharts.Orientation.Horizontal, ValueLabelOrientation = Microcharts.Orientation.Horizontal };
            cv.Chart = chart;
        }

        public async void DoAll()
        {
            //DanhGiaBacSi dgbs = await myAPI.GetDoctorRate("1");
            star[0] = 2;
            star[1] = 3;
            star[2] = 4;
            star[3] = 2;
            star[4] = 5;

            Drawchart();
            float avgStar = ((star[0] * 1 + star[1] * 2 + star[2] * 3 + star[3] * 4 + star[4] * 5) / (star[0] + star[1] + star[2] + star[3] + star[4]));
            int avg = (star[0] + star[1] + star[2] + star[3] + star[4])/5;
            rateStar.Text = (avg + "/5").ToString();
            Array.Clear(star, 0, star.Length);

        }

        private void MAdapter_ItemClick(object sender, int e)
        {
            int photoNum = e + 1;
            Toast.MakeText(this, "This is photo number " + photoNum, ToastLength.Short).Show();
        }

        private void Back_Click(object sender, EventArgs e)
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