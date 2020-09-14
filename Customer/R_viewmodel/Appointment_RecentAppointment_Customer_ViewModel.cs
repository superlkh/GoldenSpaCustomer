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
    public class Customer_Appointment_RecentAppointment_ViewModel
    {
        public string mServiceName { get; set; }
        public string mImage { get; set; }
        public string mOutlet { get; set; }
        public string mTime { get; set; }
    }

    public class Customer_Appointment_RecentAppointment_ViewModel_List
    {
        static Customer_Appointment_RecentAppointment_ViewModel[] DataSample_List_Customer_Appointment_RecentAppointment_ViewModel =
        {
            new Customer_Appointment_RecentAppointment_ViewModel(){ mServiceName="Xong hoi1", mImage="https://assets.pokemon.com/assets/cms2/img/pokedex/detail/798.png",mOutlet="Chi nhánh Nguyễn Bỉnh Khiêm",mTime="Hẹn đến 23g00 20/7/2020" },
            new Customer_Appointment_RecentAppointment_ViewModel(){ mServiceName="Xong hoi2", mImage="https://assets.pokemon.com/assets/cms2/img/pokedex/detail/789.png",mOutlet="Chi nhánh Nguyễn Bỉnh Khiêm",mTime="Hẹn đến 23g00 20/7/2020" },
            new Customer_Appointment_RecentAppointment_ViewModel(){ mServiceName="Xong hoi3", mImage="https://assets.pokemon.com/assets/cms2/img/pokedex/detail/797.png",mOutlet="Chi nhánh Nguyễn Bỉnh Khiêm",mTime="Hẹn đến 23g00 20/7/2020" },
            new Customer_Appointment_RecentAppointment_ViewModel(){ mServiceName="Xong hoi4", mImage="https://assets.pokemon.com/assets/cms2/img/pokedex/detail/792.png",mOutlet="Chi nhánh Nguyễn Bỉnh Khiêm",mTime="Hẹn đến 23g00 20/7/2020" }
        };

        private Customer_Appointment_RecentAppointment_ViewModel[] Customer_Appointment_RecentAppointment_ViewModels;
        Random random;

        public Customer_Appointment_RecentAppointment_ViewModel_List()
        {
            this.Customer_Appointment_RecentAppointment_ViewModels = DataSample_List_Customer_Appointment_RecentAppointment_ViewModel;
            random = new Random();
        }

        public int Customer_Appointment_NumRecentAppointment_ViewModel
        {
            get
            {
                return Customer_Appointment_RecentAppointment_ViewModels.Length;
            }
        }

        public Customer_Appointment_RecentAppointment_ViewModel this[int i]
        {
            get { return Customer_Appointment_RecentAppointment_ViewModels[i]; }
        }

    }

    public class Customer_Appointment_RecentAppointment_ViewModel_ViewHolder : RecyclerView.ViewHolder
    {
        public ImageView ServiceImg { get; set; }
        public TextView ServiceName { get; set; }
        public TextView OutletName { get; set; }
        public TextView Time { get; set; }

        public Customer_Appointment_RecentAppointment_ViewModel_ViewHolder(View itemview, Action<int> listener) : base(itemview)
        {
            ServiceImg = ItemView.FindViewById<ImageView>(Resource.Id.imgService_ItemRecentAppointment_Appointment_Customer);
            ServiceName = ItemView.FindViewById<TextView>(Resource.Id.txtServiceName_ItemRecentAppointment_Appointment_Customer);
            OutletName = ItemView.FindViewById<TextView>(Resource.Id.txtOutletName_ItemRecentAppointment_Appointment_Customer);
            Time = ItemView.FindViewById<TextView>(Resource.Id.txtTime_ItemRecentAppointment_Appointment_Customer);
            itemview.Click += (sender, e) => listener(base.Position);
        }
    }

}