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
    public class Customer_Service_CustomerComment_ViewModel
    {
        public string mImageCustomer { get; set; }
        public string mNameCustomer { get; set; }
        public int mValueStar { get; set; }
        public string mComment { get; set; }
        public string mDateTime { get; set; }
    }

    public class Customer_Service_CustomerComment_ViewModel_List
    {
        static Customer_Service_CustomerComment_ViewModel[] DataSample_Customer_Service_CustomerComment_ViewModel_List =
        {
            new Customer_Service_CustomerComment_ViewModel(){mImageCustomer="https://redi.vn/wp-content/uploads/2019/05/dich-vu-thiet-ke-hinh-anh-quang-cao-slider.jpg",mNameCustomer="Ly Thanh",mValueStar=3,mComment="Good",mDateTime="22:30 21/08/2020"},
            new Customer_Service_CustomerComment_ViewModel(){mImageCustomer="https://redi.vn/wp-content/uploads/2019/05/dich-vu-thiet-ke-hinh-anh-quang-cao-slider.jpg",mNameCustomer="Ly Thanh",mValueStar=3,mComment="Good",mDateTime="22:30 21/08/2020"},
            new Customer_Service_CustomerComment_ViewModel(){mImageCustomer="https://redi.vn/wp-content/uploads/2019/05/dich-vu-thiet-ke-hinh-anh-quang-cao-slider.jpg",mNameCustomer="Ly Thanh",mValueStar=3,mComment="Good",mDateTime="22:30 21/08/2020"},
            new Customer_Service_CustomerComment_ViewModel(){mImageCustomer="https://redi.vn/wp-content/uploads/2019/05/dich-vu-thiet-ke-hinh-anh-quang-cao-slider.jpg",mNameCustomer="Ly Thanh",mValueStar=3,mComment="Good",mDateTime="22:30 21/08/2020"},
            new Customer_Service_CustomerComment_ViewModel(){mImageCustomer="https://redi.vn/wp-content/uploads/2019/05/dich-vu-thiet-ke-hinh-anh-quang-cao-slider.jpg",mNameCustomer="Ly Thanh",mValueStar=3,mComment="Good",mDateTime="22:30 21/08/2020"},
            new Customer_Service_CustomerComment_ViewModel(){mImageCustomer="https://redi.vn/wp-content/uploads/2019/05/dich-vu-thiet-ke-hinh-anh-quang-cao-slider.jpg",mNameCustomer="Ly Thanh",mValueStar=3,mComment="Good",mDateTime="22:30 21/08/2020"},
            new Customer_Service_CustomerComment_ViewModel(){mImageCustomer="https://redi.vn/wp-content/uploads/2019/05/dich-vu-thiet-ke-hinh-anh-quang-cao-slider.jpg",mNameCustomer="Ly Thanh",mValueStar=3,mComment="Good",mDateTime="22:30 21/08/2020"},
            new Customer_Service_CustomerComment_ViewModel(){mImageCustomer="https://redi.vn/wp-content/uploads/2019/05/dich-vu-thiet-ke-hinh-anh-quang-cao-slider.jpg",mNameCustomer="Ly Thanh",mValueStar=3,mComment="Good",mDateTime="22:30 21/08/2020"},
            new Customer_Service_CustomerComment_ViewModel(){mImageCustomer="https://redi.vn/wp-content/uploads/2019/05/dich-vu-thiet-ke-hinh-anh-quang-cao-slider.jpg",mNameCustomer="Ly Thanh",mValueStar=3,mComment="Good",mDateTime="22:30 21/08/2020"},
            new Customer_Service_CustomerComment_ViewModel(){mImageCustomer="https://redi.vn/wp-content/uploads/2019/05/dich-vu-thiet-ke-hinh-anh-quang-cao-slider.jpg",mNameCustomer="Ly Thanh",mValueStar=3,mComment="Good",mDateTime="22:30 21/08/2020"},
        };

        private Customer_Service_CustomerComment_ViewModel[] Customer_Service_CustomerComment_ViewModels;
        Random random;

        public Customer_Service_CustomerComment_ViewModel_List()
        {
            this.Customer_Service_CustomerComment_ViewModels = DataSample_Customer_Service_CustomerComment_ViewModel_List;
            random = new Random();
        }

        public int Customer_Service_NumCustomerComment_ViewModel
        {
            get
            {
                return Customer_Service_CustomerComment_ViewModels.Length;
            }
        }

        public Customer_Service_CustomerComment_ViewModel this[int i]
        {
            get { return Customer_Service_CustomerComment_ViewModels[i]; }
        }

    }

    public class Customer_Service_CustomerComment_ViewModel_ViewHolder : RecyclerView.ViewHolder
    {
        public ImageView Img { get; set; }
        public TextView Name { get; set; }
        public TextView Comment { get; set; }
        public TextView Date { get; set; }


        public Customer_Service_CustomerComment_ViewModel_ViewHolder(View itemview, Action<int> listener) : base(itemview)
        {
            Img = ItemView.FindViewById<ImageView>(Resource.Id.ImgCustomer_ItemCustomerComment_Service_Customer);
            Name = ItemView.FindViewById<TextView>(Resource.Id.txtCustomerName_ItemCustomerComment_Service_Customer);
            Comment = ItemView.FindViewById<TextView>(Resource.Id.txtCustomerComment_ItemCustomerComment_Service_Customer);
            Date = ItemView.FindViewById<TextView>(Resource.Id.txtDate_ItemCustomerComment_Service_Customer);
            itemview.Click += (sender, e) => listener(base.Position);
        }
    }

}