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
    public class Service_RelativeDiscount_Customer_Adapter : RecyclerView.Adapter
    {
        public event EventHandler<int> ItemClick;
        public List<ListPromotion> mRelativeDiscount_List;

        public Service_RelativeDiscount_Customer_Adapter(List<ListPromotion> RelativeDiscount_List)
        {
            //this.context = context;
            mRelativeDiscount_List = RelativeDiscount_List;
        }

        public override int ItemCount
        {
            get { return mRelativeDiscount_List.Count; }
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            Customer_Service_RelativeDiscount_ViewModel_ViewHolder vh = holder as Customer_Service_RelativeDiscount_ViewModel_ViewHolder;
            Picasso.Get().Load(mRelativeDiscount_List[position].Image).Into(vh.ServiceImg);
            vh.ServiceName.Text = mRelativeDiscount_List[position].NameService;
            if (mRelativeDiscount_List[position].price == null)
                vh.ServicePrice.Text = "Giảm giá " + mRelativeDiscount_List[position].Discount.ToString() + "%";
            else
                vh.ServicePrice.Text = mRelativeDiscount_List[position].price.ToString();
            vh.NumberOutletApply.Text = "Có "+mRelativeDiscount_List[position].TotalOutlets+"chi nhánh áp dụng";
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.Item_Service_RelativeDiscount_Customer, parent, false);
            Customer_Service_RelativeDiscount_ViewModel_ViewHolder vh = new Customer_Service_RelativeDiscount_ViewModel_ViewHolder(itemView, OnClick);
            return vh;
        }
        private void OnClick(int obj)
        {
            if (ItemClick != null)
                ItemClick(this, obj);
        }
    }
}