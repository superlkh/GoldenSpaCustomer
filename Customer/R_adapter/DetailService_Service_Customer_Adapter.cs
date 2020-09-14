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
    public class DetailService_Service_Customer_Adapter : RecyclerView.Adapter
    {
        public event EventHandler<int> ItemClick;
        public Customer_DetailService_Service_ViewModel_List mService_List;

        public DetailService_Service_Customer_Adapter(Customer_DetailService_Service_ViewModel_List Service_List)
        {
            //this.context = context;
            mService_List = Service_List;
        }

        public override int ItemCount
        {
            get { return mService_List.Customer_DetailService_NumService_ViewModel; }
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            Customer_DetailService_Service_ViewModel_ViewHolder vh = holder as Customer_DetailService_Service_ViewModel_ViewHolder;
            Picasso.Get().Load(mService_List[position].mImageService).Into(vh.ServiceImg);
            vh.ServiceName.Text = mService_List[position].mServiceName;
            vh.Time.Text = mService_List[position].mTime;
            vh.Room.Text = mService_List[position].mRoom.ToString();
            vh.Bed.Text = mService_List[position].mBed.ToString();
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