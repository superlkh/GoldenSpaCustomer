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
    public class Customer_Home_Service_ViewModel
    {
        public string mTenDv { get; set; }
        public string mAnh { get; set; }
        public int mGia { get; set; }
        public int mNumberOutletApply { get; set; }
    }

    public class Customer_Home_Service_List
    {
        static Customer_Home_Service_ViewModel[] DataSample_List_Customer_Home_Service_ViewModel =
        {
            new Customer_Home_Service_ViewModel(){ mTenDv="Xong hoi1", mAnh="https://redi.vn/wp-content/uploads/2019/05/dich-vu-thiet-ke-hinh-anh-quang-cao-slider.jpg",mGia=100000,mNumberOutletApply=1 },
            new Customer_Home_Service_ViewModel(){ mTenDv="Xong hoi2", mAnh="https://redi.vn/wp-content/uploads/2019/05/dich-vu-thiet-ke-hinh-anh-quang-cao-slider.jpg",mGia=100000,mNumberOutletApply=2 },
            new Customer_Home_Service_ViewModel(){ mTenDv="Xong hoi3", mAnh="https://assets.pokemon.com/assets/cms2/img/pokedex/detail/797.png",mGia=100000,mNumberOutletApply=3 },
            new Customer_Home_Service_ViewModel(){ mTenDv="Xong hoi4", mAnh="https://assets.pokemon.com/assets/cms2/img/pokedex/detail/792.png",mGia=100000,mNumberOutletApply=4 }
        };

        private Customer_Home_Service_ViewModel[] Customer_Home_Service_ViewModels;
        Random random;

        public Customer_Home_Service_List()
        {
            this.Customer_Home_Service_ViewModels = DataSample_List_Customer_Home_Service_ViewModel;
            random = new Random();
        }

        public int Customer_Home_NumService_ViewModel
        {
            get
            {
                return Customer_Home_Service_ViewModels.Length;
            }
        }

        public Customer_Home_Service_ViewModel this[int i]
        {
            get { return Customer_Home_Service_ViewModels[i]; }
        }

    }

    public class Customer_Home_Service_ViewModel_ViewHolder : RecyclerView.ViewHolder
    {
        public ImageView ServiceImg { get; set; }
        public TextView ServiceName { get; set; }
        public TextView ServicePrice { get; set; }
        public TextView NumberOutletApply { get; set; }

        public Customer_Home_Service_ViewModel_ViewHolder(View itemview, Action<int> listener) : base(itemview)
        {
            ServiceImg = itemview.FindViewById<ImageView>(Resource.Id.imgDiscount_ItemDiscount_Home_Customer);
            ServiceName = itemview.FindViewById<TextView>(Resource.Id.txtNameServiceDiscount_ItemDiscount_Home_Customer);
            ServicePrice = itemview.FindViewById<TextView>(Resource.Id.txtPriceServiceDiscount_ItemDiscount_Home_Customer);
            NumberOutletApply = itemview.FindViewById<TextView>(Resource.Id.txtNumberOutletApply_ItemDiscount_Home_Customer);
            itemview.Click += (sender, e) => listener(base.Position);
        }
    }

}