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
using Customer.Models;
using Square.Picasso;

namespace Customer
{
    public class Outlet_Service_Customer_Adapter : RecyclerView.Adapter
    {
        public event EventHandler<int> ItemClick;
        public List<ListService> mService_List;

        public Outlet_Service_Customer_Adapter(List<ListService> Service_List)
        {
            //this.context = context;
            mService_List = Service_List;
        }

        public override int ItemCount
        {
            get { return mService_List.Count; }
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            Customer_Outlet_Service_ViewModel_ViewHolder vh = holder as Customer_Outlet_Service_ViewModel_ViewHolder;
            Picasso.Get().Load(mService_List[position].Image).Into(vh.ServiceImg);
            vh.ServiceName.Text = mService_List[position].NameService;
            if (mService_List[position].NamePromotion == null)
                vh.ServicePrice.Text = mService_List[position].price.ToString();
            else
                vh.ServicePrice.Text = mService_List[position].Discount.ToString(); ;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.Item_Outlet_Service_Customer, parent, false);
            Customer_Outlet_Service_ViewModel_ViewHolder vh = new Customer_Outlet_Service_ViewModel_ViewHolder(itemView, OnClick);
            return vh;
        }
        private void OnClick(int obj)
        {
            if (ItemClick != null)
                ItemClick(this, obj);
        }
    }
}