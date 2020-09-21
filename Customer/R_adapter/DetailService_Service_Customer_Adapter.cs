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
using Customer.Models;

namespace Customer
{
    public class DetailService_Service_Customer_Adapter : RecyclerView.Adapter
    {
        public event EventHandler<int> ItemClick;
        public List<Service_combo_Appoint> mServiceCombo_List;

        public DetailService_Service_Customer_Adapter(List<Service_combo_Appoint> Service_List)
        {
            mServiceCombo_List = Service_List;
        }

        public override int ItemCount
        {
            get { return mServiceCombo_List.Count; }
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            Customer_DetailService_Service_ViewModel_ViewHolder vh = holder as Customer_DetailService_Service_ViewModel_ViewHolder;
            Picasso.Get().Load(mServiceCombo_List[position].AnhDV).Into(vh.ServiceImg);
            vh.ServiceName.Text = mServiceCombo_List[position].TenDV;
            string ngayhen = mServiceCombo_List[position].NgayHen.ToString("dd/MM/yyyy");
            string giohen = mServiceCombo_List[position].GioHen.ToString();
            string[] a = giohen.Split(' ');
            string[] b = ngayhen.Split(' ');
            string henden = a[1] + " " + b[0];
            vh.Time.Text = henden;
            vh.Room.Text = mServiceCombo_List[position].Room.ToString();
            vh.Bed.Text = mServiceCombo_List[position].Bed.ToString();
            if (mServiceCombo_List[position].VIP == true)
                vh.Vip.Checked = true;
            else
                vh.Vip.Checked = false ;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.Item_DetailService_Service_Customer, parent, false);
            Customer_DetailService_Service_ViewModel_ViewHolder vh = new Customer_DetailService_Service_ViewModel_ViewHolder(itemView, OnClick);
            return vh;
        }
        private void OnClick(int obj)
        {
            if (ItemClick != null)
                ItemClick(this, obj);
        }
    }
}