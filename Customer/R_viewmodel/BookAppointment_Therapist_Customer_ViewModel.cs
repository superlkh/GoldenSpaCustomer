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

namespace Customer
{
    public class Customer_BookAppointment_Therapist_ViewModel
    {
        public string mTxtTherapist { get; set; }
    }

    public class Customer_BookAppointment_Therapist_ViewModel_List
    {
        static Customer_BookAppointment_Therapist_ViewModel[] DataSample_Customer_BookAppointment_Therapist_ViewModel_List =
        {
            new Customer_BookAppointment_Therapist_ViewModel(){mTxtTherapist="Lu Khanh Hoang"},
            new Customer_BookAppointment_Therapist_ViewModel(){mTxtTherapist="Phan Tuong Thien Doan"},
            new Customer_BookAppointment_Therapist_ViewModel(){mTxtTherapist="Nguyen Quoc Duy"},
        };

        private Customer_BookAppointment_Therapist_ViewModel[] Customer_BookAppointment_Therapist_ViewModels;
        Random random;

        public Customer_BookAppointment_Therapist_ViewModel_List()
        {
            this.Customer_BookAppointment_Therapist_ViewModels = DataSample_Customer_BookAppointment_Therapist_ViewModel_List;
            random = new Random();
        }

        public int Customer_BookAppointment_NumTherapist_ViewModel
        {
            get
            {
                return Customer_BookAppointment_Therapist_ViewModels.Length;
            }
        }

        public Customer_BookAppointment_Therapist_ViewModel this[int i]
        {
            get { return Customer_BookAppointment_Therapist_ViewModels[i]; }
        }

    }

    public class Customer_BookAppointment_Therapist_ViewModel_ViewHolder : RecyclerView.ViewHolder
    {
        public Button txtTherapist { get; set; }


        public Customer_BookAppointment_Therapist_ViewModel_ViewHolder(View itemview, Action<int> listener) : base(itemview)
        {
            txtTherapist = ItemView.FindViewById<Button>(Resource.Id.BtxTherapist_ItemTherapist_BookAppointment_Customer);
            itemview.Click += (sender, e) => listener(base.Position);
        }
    }

}