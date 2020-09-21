using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Support.V7.Widget;
using GoldenSpa.API;
using Customer.Models;
using Refit;
using System.Collections.Generic;
using Android.Content;

namespace Customer
{
    [Activity(Label = "RecycleView", Theme = "@style/Theme.AppCompat.Light.DarkActionBar")]
    class activity_DetailService_Customer : AppCompatActivity
    {
        IMyAPI myAPI;

        RecyclerView.LayoutManager mLayoutManagerService;
        RecyclerView mRecyclerViewService;
        List<Service_combo_Appoint> mService_List;
        DetailService_Service_Customer_Adapter mAdapterService;

        ImageView back;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.DetailService_Customer);


            mRecyclerViewService = FindViewById<RecyclerView>(Resource.Id.recyclerViewService_DetailService_Customer);
            mLayoutManagerService = new LinearLayoutManager(this);
            mRecyclerViewService.SetLayoutManager(mLayoutManagerService);
            getListServiceAndCombo();

            back = FindViewById<ImageView>(Resource.Id.imgback_DetailService_Customer);
            back.Click += Back_Click;

        }

        private void Back_Click(object sender, System.EventArgs e)
        {
            Finish();
            var intent = new Intent(this, typeof(Customer.activity_DetailAppointmentCustomer));
            intent.PutExtra("AppointmentId", Intent.GetStringExtra("MaLH"));
            StartActivity(intent);
        }

        private async void getListServiceAndCombo()
        {
            myAPI = RestService.For<IMyAPI>("https://goldenspa.azurewebsites.net");
            var resultService = await myAPI.GetServiceOfAppointment(Intent.GetStringExtra("MaLH"));
            var resultCombo = await myAPI.GetComboOfAppointment(Intent.GetStringExtra("MaLH"));
            var max = resultService.Count + resultCombo.Count;
            mService_List = new List<Service_combo_Appoint>(max);



            for (int i = 0; i < resultService.Count; i++)
            {
                var DataSample_Services_Outlet_ViewModel = new Service_combo_Appoint();
                DataSample_Services_Outlet_ViewModel.TenDV = resultService[i].TenDV;
                DataSample_Services_Outlet_ViewModel.AnhDV = resultService[i].AnhDV;
                DataSample_Services_Outlet_ViewModel.VIP = resultService[i].VIP;
                DataSample_Services_Outlet_ViewModel.Room = resultService[i].Room;
                DataSample_Services_Outlet_ViewModel.Bed = resultService[i].Bed;
                DataSample_Services_Outlet_ViewModel.NgayHen = resultService[i].NgayHen;
                DataSample_Services_Outlet_ViewModel.GioHen = resultService[i].GioHen;
                mService_List.Add(DataSample_Services_Outlet_ViewModel);
            }

            for (int i = resultService.Count; i < max; i++)
            {
                var DataSample_Services_Outlet_ViewModel = new Service_combo_Appoint();
                DataSample_Services_Outlet_ViewModel.TenDV = resultService[i - resultService.Count].TenDV;
                DataSample_Services_Outlet_ViewModel.AnhDV = resultService[i - resultService.Count].AnhDV;
                DataSample_Services_Outlet_ViewModel.VIP = resultService[i - resultService.Count].VIP;
                DataSample_Services_Outlet_ViewModel.Room = resultService[i - resultService.Count].Room;
                DataSample_Services_Outlet_ViewModel.Bed = resultService[i - resultService.Count].Bed;
                DataSample_Services_Outlet_ViewModel.NgayHen = resultService[i - resultService.Count].NgayHen;
                DataSample_Services_Outlet_ViewModel.GioHen = resultService[i - resultService.Count].GioHen;
                mService_List.Add(DataSample_Services_Outlet_ViewModel);
            }


            mAdapterService = new DetailService_Service_Customer_Adapter(mService_List);
            mRecyclerViewService.SetAdapter(mAdapterService);
        }

        private void MAdapter_ItemClick(object sender, int e)
        {
            int photoNum = e + 1;
            Toast.MakeText(this, "This is photo number " + photoNum, ToastLength.Short).Show();
        }

    }
}