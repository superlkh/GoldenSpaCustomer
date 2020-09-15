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
    public class Home_Discount_Customer_Adapter : RecyclerView.Adapter
    {
        public event EventHandler<int> ItemClick;
        public List<ListPromotion> listPromotion;

        public Home_Discount_Customer_Adapter(List<ListPromotion> listDiscount)
        {
            listPromotion = listDiscount;
        }

        public override int ItemCount
        {
            get { return listPromotion.Count; }
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            Customer_Home_Service_ViewModel_ViewHolder vh = holder as Customer_Home_Service_ViewModel_ViewHolder;
            Picasso.Get().Load(listPromotion[position].Image).Into(vh.ServiceImg);
            vh.ServiceName.Text = listPromotion[position].NameService;
            if (listPromotion[position].price == null)
                vh.ServicePrice.Text = "Giảm giá " + listPromotion[position].Discount.ToString()+"%";
            else
                vh.ServicePrice.Text = listPromotion[position].price.ToString();
            vh.NumberOutletApply.Text = "Có " + listPromotion[position].TotalOutlets.ToString() + " chi nhánh áp dụng";
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