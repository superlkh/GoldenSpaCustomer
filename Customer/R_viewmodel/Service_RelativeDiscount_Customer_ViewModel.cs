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
    public class Customer_Service_RelativeDiscount_ViewModel
    {
        public string mImageRelativeDiscount { get; set; }
        public string mNameRelativeDiscount { get; set; }
        public string mOutletRelativeDiscount { get; set; }
    }

    public class Customer_Service_RelativeDiscount_ViewModel_List
    {
        static Customer_Service_RelativeDiscount_ViewModel[] DataSample_Customer_Service_RelativeDiscount_ViewModel_List =
        {
            new Customer_Service_RelativeDiscount_ViewModel(){mImageRelativeDiscount="https://redi.vn/wp-content/uploads/2019/05/dich-vu-thiet-ke-hinh-anh-quang-cao-slider.jpg",mNameRelativeDiscount="Combo tắm nắng 700k",mOutletRelativeDiscount="Chi nhánh Cộng Hòa1"},
            new Customer_Service_RelativeDiscount_ViewModel(){mImageRelativeDiscount="https://redi.vn/wp-content/uploads/2019/05/dich-vu-thiet-ke-hinh-anh-quang-cao-slider.jpg",mNameRelativeDiscount="Xông hơi",mOutletRelativeDiscount="Chi nhánh Cộng Hòa2"},
            new Customer_Service_RelativeDiscount_ViewModel(){mImageRelativeDiscount="https://redi.vn/wp-content/uploads/2019/05/dich-vu-thiet-ke-hinh-anh-quang-cao-slider.jpg",mNameRelativeDiscount="Xông hơi",mOutletRelativeDiscount="Chi nhánh Cộng Hòa3"},
        };

        private Customer_Service_RelativeDiscount_ViewModel[] Customer_Service_RelativeDiscount_ViewModels;
        Random random;

        public Customer_Service_RelativeDiscount_ViewModel_List()
        {
            this.Customer_Service_RelativeDiscount_ViewModels = DataSample_Customer_Service_RelativeDiscount_ViewModel_List;
            random = new Random();
        }

        public int Customer_Service_NumRelativeDiscount_ViewModel
        {
            get
            {
                return Customer_Service_RelativeDiscount_ViewModels.Length;
            }
        }

        public Customer_Service_RelativeDiscount_ViewModel this[int i]
        {
            get { return Customer_Service_RelativeDiscount_ViewModels[i]; }
        }

    }

    public class Customer_Service_RelativeDiscount_ViewModel_ViewHolder : RecyclerView.ViewHolder
    {
        public ImageView ServiceImg { get; set; }
        public TextView ServiceName { get; set; }
        public TextView Outlet { get; set; }


        public Customer_Service_RelativeDiscount_ViewModel_ViewHolder(View itemview, Action<int> listener) : base(itemview)
        {
            ServiceImg = ItemView.FindViewById<ImageView>(Resource.Id.imgService_ItemRelativeDiscount_Service_Customer);
            ServiceName = ItemView.FindViewById<TextView>(Resource.Id.txtNameService_ItemRelativeDiscount_Service_Customer);
            Outlet = ItemView.FindViewById<TextView>(Resource.Id.txtOutlet_ItemRelativeDiscount_Service_Customer);
            itemview.Click += (sender, e) => listener(base.Position);
        }
    }

}