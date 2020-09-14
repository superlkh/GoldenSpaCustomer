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
using Customer.Model;
using Square.Picasso;

namespace Customer
{
    public class Home_Outlet_Customer_Adapter : RecyclerView.Adapter
    {
        public event EventHandler<int> ItemClick;

        public List<ListOutlet> mOutlet_List;

      
        public Home_Outlet_Customer_Adapter(List<ListOutlet> outlet_List)
        {
            mOutlet_List = outlet_List;
        }

        public override int ItemCount
        {
            get { return mOutlet_List.Count(); }
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            Customer_Home_Outlet_ViewModel_ViewHolder vh = holder as Customer_Home_Outlet_ViewModel_ViewHolder;
            Picasso.Get().Load(mOutlet_List[position].Image).Into(vh.OutletImg);
            vh.OutletName.Text = mOutlet_List[position].name;
            vh.OutletAdress.Text = mOutlet_List[position].address;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.Item_Home_Outlet_Customer, parent, false);
            Customer_Home_Outlet_ViewModel_ViewHolder vh = new Customer_Home_Outlet_ViewModel_ViewHolder(itemView, OnClick);
            return vh;
        }
        private void OnClick(int obj)
        {
            if (ItemClick != null)
                ItemClick(this, obj);
        }
    }
}