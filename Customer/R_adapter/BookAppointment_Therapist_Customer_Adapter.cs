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
    public class BookAppointment_Therapist_Customer_Adapter : RecyclerView.Adapter
    {
        public event EventHandler<int> ItemClick;
        public Customer_BookAppointment_Therapist_ViewModel_List mTherapist_List;

        public BookAppointment_Therapist_Customer_Adapter(Customer_BookAppointment_Therapist_ViewModel_List Therapist_List)
        {
            //this.context = context;
            mTherapist_List = Therapist_List;
        }

        public override int ItemCount
        {
            get { return mTherapist_List.Customer_BookAppointment_NumTherapist_ViewModel; }
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            Customer_BookAppointment_Therapist_ViewModel_ViewHolder vh = holder as Customer_BookAppointment_Therapist_ViewModel_ViewHolder;
            vh.txtTherapist.Text = mTherapist_List[position].mTxtTherapist;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.Item_BookAppointment_Therapist_Customer, parent, false);
            Customer_BookAppointment_Therapist_ViewModel_ViewHolder vh = new Customer_BookAppointment_Therapist_ViewModel_ViewHolder(itemView, OnClick);
            return vh;
        }
        private void OnClick(int obj)
        {
            if (ItemClick != null)
                ItemClick(this, obj);
        }
    }
}