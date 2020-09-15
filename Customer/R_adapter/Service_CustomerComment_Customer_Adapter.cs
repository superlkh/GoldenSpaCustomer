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
    public class Service_CustomerComment_Customer_Adapter : RecyclerView.Adapter
    {
        public event EventHandler<int> ItemClick;
        public List<Comment> mCustomerComment_List;

        public Service_CustomerComment_Customer_Adapter(List<Comment> CustomerComment_List)
        {
            mCustomerComment_List = CustomerComment_List;
        }

        public override int ItemCount
        {
            get { return mCustomerComment_List.Count; }
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            Customer_Service_CustomerComment_ViewModel_ViewHolder vh = holder as Customer_Service_CustomerComment_ViewModel_ViewHolder;
            Picasso.Get().Load(mCustomerComment_List[position].Anh).Into(vh.Img);
            vh.Name.Text = mCustomerComment_List[position].TenKH;
            vh.Comment.Text = mCustomerComment_List[position].comment;
            vh.Date.Text = mCustomerComment_List[position].Ngay.ToString();
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.Item_Service_CustomerComment_Customer, parent, false);
            Customer_Service_CustomerComment_ViewModel_ViewHolder vh = new Customer_Service_CustomerComment_ViewModel_ViewHolder(itemView, OnClick);
            return vh;
        }
        private void OnClick(int obj)
        {
            if (ItemClick != null)
                ItemClick(this, obj);
        }
    }
}