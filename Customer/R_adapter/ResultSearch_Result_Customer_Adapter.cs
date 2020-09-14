
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
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
    class ResultSearch_Result_Customer_Adapter : RecyclerView.Adapter 
    {
        public event EventHandler<int> ItemClick;
        public Customer_ResultSearch_Result_ViewModel_List mService_List;

        public ResultSearch_Result_Customer_Adapter(Customer_ResultSearch_Result_ViewModel_List Service_List)
        {
            //this.context = context;
            mService_List = Service_List;
        }

        public override int ItemCount
        {
            get { return mService_List.Customer_ResultSearch_NumService_ViewModel; }
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            Customer_ResultSearch_Result_ViewModel_ViewHolder vh = holder as Customer_ResultSearch_Result_ViewModel_ViewHolder;
            Picasso.Get().Load(mService_List[position].mImageService).Into(vh.ServiceImg);
            vh.ServiceName.Text = mService_List[position].mNameService;
            vh.PriceName.Text = mService_List[position].mPriceService.ToString();
            vh.NumOutletApply.Text = mService_List[position].mNumOutletApply;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.Item_ResultSearch_Search_Customer, parent, false);
            Customer_ResultSearch_Result_ViewModel_ViewHolder vh = new Customer_ResultSearch_Result_ViewModel_ViewHolder(itemView, OnClick);
            return vh;
        }
        private void OnClick(int obj)
        {
            if (ItemClick != null)
                ItemClick(this, obj);
        }
    }
}