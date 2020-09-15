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
    public class Home_UsedService_Customer_Adapter : RecyclerView.Adapter
    {
        public event EventHandler<int> ItemClick;
        public List<ListPromotion> mUsedService_List;

        public Home_UsedService_Customer_Adapter(List<ListPromotion> UsedService_List)
        {
            //this.context = context;
            mUsedService_List = UsedService_List;
        }

        public override int ItemCount
        {
            get { return mUsedService_List.Count; }
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            Customer_Home_UsedService_ViewModel_ViewHolder vh = holder as Customer_Home_UsedService_ViewModel_ViewHolder;
            Picasso.Get().Load(mUsedService_List[position].Image).Into(vh.ServiceImg);
            vh.ServiceName.Text = mUsedService_List[position].NameService;
            vh.ServicePrice.Text = mUsedService_List[position].price.ToString();
            vh.NumberOutletApply.Text = "Có" + mUsedService_List[position].TotalOutlets.ToString() + "chi nhánh áp dụng";
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.Item_Home_UsedService_Customer, parent, false);
            Customer_Home_UsedService_ViewModel_ViewHolder vh = new Customer_Home_UsedService_ViewModel_ViewHolder(itemView, OnClick);
            return vh;
        }
        private void OnClick(int obj)
        {
            if (ItemClick != null)
                ItemClick(this, obj);
        }
    }
}