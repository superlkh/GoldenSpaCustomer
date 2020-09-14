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
    public class ShoppingCardHistoryAppointment_Appointment_Customer_Adapter : RecyclerView.Adapter
    {
        public event EventHandler<int> ItemClick;
        public Customer_ShoppingCardHistoryAppointment_RecentAppointment_ViewModel_List mRecentAppointment_List;

        public ShoppingCardHistoryAppointment_Appointment_Customer_Adapter(Customer_ShoppingCardHistoryAppointment_RecentAppointment_ViewModel_List RecentAppointment_List)
        {
            //this.context = context;
            mRecentAppointment_List = RecentAppointment_List;
        }

        public override int ItemCount
        {
            get { return mRecentAppointment_List.Customer_ShoppingCardHistoryAppointment_RecentAppointment_ViewModel; }
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            Customer_ShoppingCardHistoryAppointment_RecentAppointment_ViewModel_ViewHolder vh = holder as Customer_ShoppingCardHistoryAppointment_RecentAppointment_ViewModel_ViewHolder;
            Picasso.Get().Load(mRecentAppointment_List[position].mImageService).Into(vh.ServiceImg);
            vh.OutletName.Text = mRecentAppointment_List[position].mOutlerName;
            vh.Time.Text = mRecentAppointment_List[position].mTime;
            vh.Check.Text = mRecentAppointment_List[position].mCheck;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.Item_ShoppingCardHistoryAppointment_Appointment_Customer, parent, false);
            Customer_ShoppingCardHistoryAppointment_RecentAppointment_ViewModel_ViewHolder vh = new Customer_ShoppingCardHistoryAppointment_RecentAppointment_ViewModel_ViewHolder(itemView, OnClick);
            return vh;
        }
        private void OnClick(int obj)
        {
            if (ItemClick != null)
                ItemClick(this, obj);
        }
    }
}