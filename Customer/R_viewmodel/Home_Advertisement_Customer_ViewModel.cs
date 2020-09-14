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
    public class Customer_Home_Advertisement_ViewModel
    {
        public string mAnh { get; set; }
    }

    public class Customer_Home_Advertisement_ViewModel_List
    {
        static Customer_Home_Advertisement_ViewModel[] DataSample_Customer_Home_Advertisement_ViewModel =
        {
            new Customer_Home_Advertisement_ViewModel(){mAnh="https://redi.vn/wp-content/uploads/2019/05/dich-vu-thiet-ke-hinh-anh-quang-cao-slider.jpg"},
            new Customer_Home_Advertisement_ViewModel(){mAnh="https://redi.vn/wp-content/uploads/2019/05/dich-vu-thiet-ke-hinh-anh-quang-cao-slider.jpg"}
        };

        private Customer_Home_Advertisement_ViewModel[] Customer_Home_Advertisement_ViewModels;
        Random random;

        public Customer_Home_Advertisement_ViewModel_List()
        {
            this.Customer_Home_Advertisement_ViewModels = DataSample_Customer_Home_Advertisement_ViewModel;
            random = new Random();
        }

        public int Customer_Home_NumAdvertisement_ViewModel
        {
            get
            {
                return Customer_Home_Advertisement_ViewModels.Length;
            }
        }

        public Customer_Home_Advertisement_ViewModel this[int i]
        {
            get { return Customer_Home_Advertisement_ViewModels[i]; }
        }

    }

    public class Customer_Home_Advertisement_ViewModel_ViewHolder : RecyclerView.ViewHolder
    {
        public ImageView AdvertisementImg { get; set; }


        public Customer_Home_Advertisement_ViewModel_ViewHolder(View itemview, Action<int> listener) : base(itemview)
        {
            AdvertisementImg = itemview.FindViewById<ImageView>(Resource.Id.imgAdvertisement_ItemAdvertisement_Home_Customer);
            itemview.Click += (sender, e) => listener(base.Position);
        }
    }

}