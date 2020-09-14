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
    public class Customer_BookAppointment_Time_ViewModel
    {
        public string mTxtTime { get; set; }
    }

    public class Customer_BookAppointment_Time_ViewModel_List
    {
        static Customer_BookAppointment_Time_ViewModel[] DataSample_Customer_BookAppointment_Time_ViewModel_List =
        {
            new Customer_BookAppointment_Time_ViewModel(){mTxtTime="8"},
            new Customer_BookAppointment_Time_ViewModel(){mTxtTime="7h15"},
            new Customer_BookAppointment_Time_ViewModel(){mTxtTime="7h30"}
        };

        private Customer_BookAppointment_Time_ViewModel[] Customer_BookAppointment_Time_ViewModels;
        Random random;

        public Customer_BookAppointment_Time_ViewModel_List()
        {
            this.Customer_BookAppointment_Time_ViewModels = DataSample_Customer_BookAppointment_Time_ViewModel_List;
            random = new Random();
        }

        public int Customer_BookAppointment_NumTime_ViewModel
        {
            get
            {
                return Customer_BookAppointment_Time_ViewModels.Length;
            }
        }

        public Customer_BookAppointment_Time_ViewModel this[int i]
        {
            get { return Customer_BookAppointment_Time_ViewModels[i]; }
        }

    }

    public class Customer_BookAppointment_Time_ViewModel_ViewHolder : RecyclerView.ViewHolder
    {
        public Button txtTime { get; set; }


        public Customer_BookAppointment_Time_ViewModel_ViewHolder(View itemview, Action<int> listener) : base(itemview)
        {
            txtTime = ItemView.FindViewById<Button>(Resource.Id.BtxTime_ItemTime_BookAppointment_Customer);
            itemview.Click += (sender, e) => listener(base.Position);
        }
    }

}