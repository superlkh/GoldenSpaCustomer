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
    public class Home_Advertisement_Customer_Adapter : RecyclerView.Adapter
    {
        public event EventHandler<int> ItemClick;
        public Customer_Home_Advertisement_ViewModel_List mdAdvertisement_List;

        public Home_Advertisement_Customer_Adapter(Customer_Home_Advertisement_ViewModel_List advertisement_List)
        {
            //this.context = context;
            mdAdvertisement_List = advertisement_List;
        }

        public override int ItemCount
        {
            get { return mdAdvertisement_List.Customer_Home_NumAdvertisement_ViewModel; }
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            Customer_Home_Advertisement_ViewModel_ViewHolder vh = holder as Customer_Home_Advertisement_ViewModel_ViewHolder;
            Picasso.Get().Load(mdAdvertisement_List[position].mAnh).Into(vh.AdvertisementImg);
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.Item_Home_Advertisement_Customer, parent, false);
            Customer_Home_Advertisement_ViewModel_ViewHolder vh = new Customer_Home_Advertisement_ViewModel_ViewHolder(itemView, OnClick);
            return vh;
        }
        private void OnClick(int obj)
        {
            if (ItemClick != null)
                ItemClick(this, obj);
        }
    }
}