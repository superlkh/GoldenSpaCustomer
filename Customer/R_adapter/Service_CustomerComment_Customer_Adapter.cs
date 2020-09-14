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
    public class Service_CustomerComment_Customer_Adapter : RecyclerView.Adapter
    {
        public event EventHandler<int> ItemClick;
        public Customer_Service_CustomerComment_ViewModel_List mCustomerComment_List;

        public Service_CustomerComment_Customer_Adapter(Customer_Service_CustomerComment_ViewModel_List CustomerComment_List)
        {
            //this.context = context;
            mCustomerComment_List = CustomerComment_List;
        }

        public override int ItemCount
        {
            get { return mCustomerComment_List.Customer_Service_NumCustomerComment_ViewModel; }
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            Customer_Service_CustomerComment_ViewModel_ViewHolder vh = holder as Customer_Service_CustomerComment_ViewModel_ViewHolder;
            Picasso.Get().Load(mCustomerComment_List[position].mImageCustomer).Into(vh.Img);
            vh.Name.Text = mCustomerComment_List[position].mNameCustomer;
            vh.Comment.Text = mCustomerComment_List[position].mComment;
            vh.Date.Text = mCustomerComment_List[position].mDateTime;
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