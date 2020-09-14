using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Square.Picasso;

namespace Customer
{
    public class Appointment_RecentAppointment_Customer_Adapter : RecyclerView.Adapter
    {
        public event EventHandler<int> ItemClick;
        public Customer_Appointment_RecentAppointment_ViewModel_List mRecentAppointment_List;

        public Appointment_RecentAppointment_Customer_Adapter(Customer_Appointment_RecentAppointment_ViewModel_List RecentAppointment_List)
        {
            //this.context = context;
            mRecentAppointment_List = RecentAppointment_List;
        }

        public override int ItemCount
        {
            get { return mRecentAppointment_List.Customer_Appointment_NumRecentAppointment_ViewModel; }
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            Customer_Appointment_RecentAppointment_ViewModel_ViewHolder vh = holder as Customer_Appointment_RecentAppointment_ViewModel_ViewHolder;
            Picasso.Get().Load(mRecentAppointment_List[position].mImage).Into(vh.ServiceImg);
            vh.ServiceName.Text = mRecentAppointment_List[position].mServiceName;
            vh.OutletName.Text = mRecentAppointment_List[position].mOutlet;
            vh.Time.Text = mRecentAppointment_List[position].mTime;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.Item_Appointment_RecentAppointment_Customer, parent, false);
            Customer_Appointment_RecentAppointment_ViewModel_ViewHolder vh = new Customer_Appointment_RecentAppointment_ViewModel_ViewHolder(itemView, OnClick);
            return vh;
        }
        private void OnClick(int obj)
        {
            if (ItemClick != null)
                ItemClick(this, obj);
        }
    }
}