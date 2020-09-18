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
using Customer.Fragment;
using Customer.Models;
using Square.Picasso;


namespace Customer
{
    public class Appointment_RecentAppointment_Customer_Adapter : RecyclerView.Adapter
    {
        public event EventHandler<int> ItemClick;
        public List<AppointmentInfo> appointment_list;

        public Appointment_RecentAppointment_Customer_Adapter(List<AppointmentInfo> RecentAppointment_List)
        {
            //this.context = context;
            appointment_list = RecentAppointment_List;
        }

        public override int ItemCount
        {
            get { return appointment_list.Count; }
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            Customer_Appointment_RecentAppointment_ViewModel_ViewHolder vh = holder as Customer_Appointment_RecentAppointment_ViewModel_ViewHolder;
            Picasso.Get().Load(appointment_list[position].AnhChiNhanh).Into(vh.ServiceImg);
            vh.TotalService.Text = appointment_list[position].TongDv.ToString();
            vh.OutletName.Text = appointment_list[position].TenChiNhanh;
            vh.Time.Text = appointment_list[position].NgayGioHen.ToString();
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