using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Support.V7.Widget;
using System;

namespace Customer
{
    [Activity(Label = "GoldenSpa")]
    class activity_ShoppingCardHistoryAppointment_Customer : AppCompatActivity
    {

        RecyclerView.LayoutManager mLayoutManagerAppointment;
        RecyclerView mRecyclerViewAppointment;
        Customer_ShoppingCardHistoryAppointment_RecentAppointment_ViewModel_List mAppointment_List;
        ShoppingCardHistoryAppointment_Appointment_Customer_Adapter mAdapterAppointment;




        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource  
            SetContentView(Resource.Layout.ShoppingCardHistoryAppointment_Customer);


            mRecyclerViewAppointment = FindViewById<RecyclerView>(Resource.Id.recyclerViewAppointment_ShoppingCardHistoryAppointment_Customer);
            mLayoutManagerAppointment = new LinearLayoutManager(this);
            mRecyclerViewAppointment.SetLayoutManager(mLayoutManagerAppointment);
            mAppointment_List = new Customer_ShoppingCardHistoryAppointment_RecentAppointment_ViewModel_List();
            mAdapterAppointment = new ShoppingCardHistoryAppointment_Appointment_Customer_Adapter(mAppointment_List);
            mRecyclerViewAppointment.SetAdapter(mAdapterAppointment);

            

        }

       

        private void MAdapter_ItemClick(object sender, int e)
        {
            int photoNum = e + 1;
            Toast.MakeText(this, "This is photo number " + photoNum, ToastLength.Short).Show();
        }

    }
}