using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Customer.Models;
using Square.Picasso;

namespace Customer
{
    public class ShoppingCardHistoryAppointment_Appointment_Customer_Adapter : RecyclerView.Adapter
    {
        public event EventHandler<int> ItemClick;
        public List<HistoryAppointment> mRecentAppointment_List;

        public ShoppingCardHistoryAppointment_Appointment_Customer_Adapter(List<HistoryAppointment> RecentAppointment_List)
        {
            //this.context = context;
            mRecentAppointment_List = RecentAppointment_List;
        }

        public override int ItemCount
        {
            get { return mRecentAppointment_List.Count; }
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            if (mRecentAppointment_List[position].trangthai=="0" ||
                mRecentAppointment_List[position].trangthai == "2" ||
                mRecentAppointment_List[position].trangthai == "3" )
            {
                Customer_ShoppingCardHistoryAppointment_RecentAppointment_ViewModel_ViewHolder vh = holder as Customer_ShoppingCardHistoryAppointment_RecentAppointment_ViewModel_ViewHolder;
                Picasso.Get().Load(mRecentAppointment_List[position].AnhChiNhanh).Into(vh.ServiceImg);
                vh.OutletName.Text = mRecentAppointment_List[position].TenChiNhanh;
                string ngayhen = mRecentAppointment_List[position].NgayHen.ToString("dd/MM/yyyy");
                string giohen = mRecentAppointment_List[position].GioHen.ToString();
                string[] a = giohen.Split(' ');
                string[] b = ngayhen.Split(' ');
                string henden = a[1] + " " + b[0];
                vh.Time.Text = henden;
                string abc = mRecentAppointment_List[position].trangthai;
                if (mRecentAppointment_List[position].trangthai == "0")
                {
                    vh.Check.Text = "Đã hủy";
                    vh.Check.SetTextColor(Android.Graphics.Color.Red);
                }
                else if (mRecentAppointment_List[position].trangthai == "2")
                    vh.Check.Text = "Không đến";
                else
                    vh.Check.Text = "Đã thực hiện";
            }
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