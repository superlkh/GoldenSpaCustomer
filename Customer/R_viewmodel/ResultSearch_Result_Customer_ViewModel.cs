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
    public class Customer_ResultSearch_Result_ViewModel
    {
        public string mImageService { get; set; }
        public string mNameService { get; set; }
        public int mPriceService { get; set; }
        public string mNumOutletApply { get; set; }
    }

    public class Customer_ResultSearch_Result_ViewModel_List
    {
        static Customer_ResultSearch_Result_ViewModel[] DataSample_Customer_ResultSearch_Result_ViewModel_List =
        {
            new Customer_ResultSearch_Result_ViewModel(){mImageService="https://redi.vn/wp-content/uploads/2019/05/dich-vu-thiet-ke-hinh-anh-quang-cao-slider.jpg",mNameService="Combo tắm nắng 700k", mPriceService=200000, mNumOutletApply="1"},
            new Customer_ResultSearch_Result_ViewModel(){mImageService="https://redi.vn/wp-content/uploads/2019/05/dich-vu-thiet-ke-hinh-anh-quang-cao-slider.jpg",mNameService="Xông hơi", mPriceService=200000, mNumOutletApply="2"},
            new Customer_ResultSearch_Result_ViewModel(){mImageService="https://redi.vn/wp-content/uploads/2019/05/dich-vu-thiet-ke-hinh-anh-quang-cao-slider.jpg",mNameService="Xông hơi", mPriceService=200000, mNumOutletApply="3"},
        };

        private Customer_ResultSearch_Result_ViewModel[] Customer_ResultSearch_Result_ViewModels;
        Random random;

        public Customer_ResultSearch_Result_ViewModel_List()
        {
            this.Customer_ResultSearch_Result_ViewModels = DataSample_Customer_ResultSearch_Result_ViewModel_List;
            random = new Random();
        }

        public int Customer_ResultSearch_NumService_ViewModel
        {
            get
            {
                return Customer_ResultSearch_Result_ViewModels.Length;
            }
        }

        public Customer_ResultSearch_Result_ViewModel this[int i]
        {
            get { return Customer_ResultSearch_Result_ViewModels[i]; }
        }

    }

    public class Customer_ResultSearch_Result_ViewModel_ViewHolder : RecyclerView.ViewHolder
    {
        public ImageView ServiceImg { get; set; }
        public TextView ServiceName { get; set; }
        public TextView PriceName { get; set; }
        public TextView NumOutletApply { get; set; }


        public Customer_ResultSearch_Result_ViewModel_ViewHolder(View itemview, Action<int> listener) : base(itemview)
        {
            ServiceImg = ItemView.FindViewById<ImageView>(Resource.Id.imgService_ItemResultSearch_ResultSearch_Customer);
            ServiceName = ItemView.FindViewById<TextView>(Resource.Id.txtNameService_ItemResultSearch_ResultSearch_Customer);
            PriceName = ItemView.FindViewById<TextView>(Resource.Id.txtPriceService_ItemResultSearch_ResultSearch_Customer);
            NumOutletApply = ItemView.FindViewById<TextView>(Resource.Id.txtNumberOutletApply_ItemResultSearch_ResultSearch_Customer);
            itemview.Click += (sender, e) => listener(base.Position);
        }
    }

}