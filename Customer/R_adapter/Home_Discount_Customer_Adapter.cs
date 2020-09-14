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
    public class Home_Discount_Customer_Adapter : RecyclerView.Adapter
    {
        public event EventHandler<int> ItemClick;
        public Customer_Home_Service_List mService_Image;

        public Home_Discount_Customer_Adapter(Customer_Home_Service_List Service_Image)
        {
            //this.context = context;
            mService_Image = Service_Image;
        }

        public override int ItemCount
        {
            get { return mService_Image.Customer_Home_NumService_ViewModel; }
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            Customer_Home_Service_ViewModel_ViewHolder vh = holder as Customer_Home_Service_ViewModel_ViewHolder;
            Picasso.Get().Load(mService_Image[position].mAnh).Into(vh.ServiceImg);
            vh.ServiceName.Text = mService_Image[position].mTenDv;
            vh.ServicePrice.Text = mService_Image[position].mGia.ToString();
            vh.NumberOutletApply.Text = "Có " + mService_Image[position].mNumberOutletApply.ToString() + " chi nhánh áp dụng";
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.Item_Home_Discount_Customer, parent, false);
            Customer_Home_Service_ViewModel_ViewHolder vh = new Customer_Home_Service_ViewModel_ViewHolder(itemView, OnClick);
            return vh;
        }
        private void OnClick(int obj)
        {
            if (ItemClick != null)
                ItemClick(this, obj);
        }
    }
}