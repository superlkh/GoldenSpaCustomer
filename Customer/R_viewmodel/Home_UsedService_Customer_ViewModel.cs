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
    public class Customer_Home_UsedService_ViewModel
    {
        public string mTenDv { get; set; }
        public string mAnh { get; set; }
        public int mGia { get; set; }
        public int mNumberOutletApply { get; set; }
    }

    public class Customer_Home_UsedService_List
    {
        static Customer_Home_UsedService_ViewModel[] DataSample_List_Customer_Home_UsedService_ViewModel =
        {
            new Customer_Home_UsedService_ViewModel(){ mTenDv="Xong hoi1", mAnh="https://assets.pokemon.com/assets/cms2/img/pokedex/detail/798.png",mGia=100000,mNumberOutletApply=1 },
            new Customer_Home_UsedService_ViewModel(){ mTenDv="Xong hoi2", mAnh="https://assets.pokemon.com/assets/cms2/img/pokedex/detail/789.png",mGia=100000,mNumberOutletApply=2 },
            new Customer_Home_UsedService_ViewModel(){ mTenDv="Xong hoi3", mAnh="https://assets.pokemon.com/assets/cms2/img/pokedex/detail/797.png",mGia=100000,mNumberOutletApply=3 },
            new Customer_Home_UsedService_ViewModel(){ mTenDv="Xong hoi4", mAnh="https://assets.pokemon.com/assets/cms2/img/pokedex/detail/792.png",mGia=100000,mNumberOutletApply=4 }
        };

        private Customer_Home_UsedService_ViewModel[] Customer_Home_UsedService_ViewModels;
        Random random;

        public Customer_Home_UsedService_List()
        {
            this.Customer_Home_UsedService_ViewModels = DataSample_List_Customer_Home_UsedService_ViewModel;
            random = new Random();
        }

        public int Customer_Home_NumUsedService_ViewModel
        {
            get
            {
                return Customer_Home_UsedService_ViewModels.Length;
            }
        }

        public Customer_Home_UsedService_ViewModel this[int i]
        {
            get { return Customer_Home_UsedService_ViewModels[i]; }
        }

    }

    public class Customer_Home_UsedService_ViewModel_ViewHolder : RecyclerView.ViewHolder
    {
        public ImageView ServiceImg { get; set; }
        public TextView ServiceName { get; set; }
        public TextView ServicePrice { get; set; }
        public TextView NumberOutletApply { get; set; }

        public Customer_Home_UsedService_ViewModel_ViewHolder(View itemview, Action<int> listener) : base(itemview)
        {
            ServiceImg = ItemView.FindViewById<ImageView>(Resource.Id.imgService_ItemUsedService_Home_Customer);
            ServiceName = ItemView.FindViewById<TextView>(Resource.Id.txtNameService_ItemUsedService_Home_Customer);
            ServicePrice = ItemView.FindViewById<TextView>(Resource.Id.txtPriceService_ItemUsedService_Home_Customer);
            NumberOutletApply = ItemView.FindViewById<TextView>(Resource.Id.txtNumberOutletApply_ItemUsedService_Home_Customer);
            itemview.Click += (sender, e) => listener(base.Position);
        }
    }

}