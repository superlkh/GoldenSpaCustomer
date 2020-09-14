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
    public class Customer_ShoppingCardHistoryAppointment_RecentAppointment_ViewModel
    {
        public string mOutlerName { get; set; }
        public string mImageService { get; set; }
        public string mTime { get; set; }
        public string mCheck { get; set; }
    }

    public class Customer_ShoppingCardHistoryAppointment_RecentAppointment_ViewModel_List
    {
        static Customer_ShoppingCardHistoryAppointment_RecentAppointment_ViewModel[] DataSample_List_Customer_ShoppingCardHistoryAppointment_RecentAppointment_ViewModel =
        {
            new Customer_ShoppingCardHistoryAppointment_RecentAppointment_ViewModel(){ mOutlerName="Chi nhánh Nguyễn Bỉnh Khiêm", mImageService="https://assets.pokemon.com/assets/cms2/img/pokedex/detail/798.png",mTime="17g 20/2/2020",mCheck="Đã thực hiện" },
            new Customer_ShoppingCardHistoryAppointment_RecentAppointment_ViewModel(){ mOutlerName="Chi nhánh Nguyễn Bỉnh Khiêm", mImageService="https://assets.pokemon.com/assets/cms2/img/pokedex/detail/789.png",mTime="7g 20/2/2020",mCheck="Đã hủy" },
            new Customer_ShoppingCardHistoryAppointment_RecentAppointment_ViewModel(){ mOutlerName="Chi nhánh Nguyễn Bỉnh Khiêm", mImageService="https://assets.pokemon.com/assets/cms2/img/pokedex/detail/797.png",mTime="7g 20/2/2020",mCheck="Đã thực hiện" },
            new Customer_ShoppingCardHistoryAppointment_RecentAppointment_ViewModel(){ mOutlerName="Chi nhánh Nguyễn Bỉnh Khiêm", mImageService="https://assets.pokemon.com/assets/cms2/img/pokedex/detail/792.png",mTime="7g 20/2/2020",mCheck="Đã hủy" }
        };

        private Customer_ShoppingCardHistoryAppointment_RecentAppointment_ViewModel[] Customer_ShoppingCardHistoryAppointment_RecentAppointment_ViewModels;
        Random random;

        public Customer_ShoppingCardHistoryAppointment_RecentAppointment_ViewModel_List()
        {
            this.Customer_ShoppingCardHistoryAppointment_RecentAppointment_ViewModels = DataSample_List_Customer_ShoppingCardHistoryAppointment_RecentAppointment_ViewModel;
            random = new Random();
        }

        public int Customer_ShoppingCardHistoryAppointment_RecentAppointment_ViewModel
        {
            get
            {
                return Customer_ShoppingCardHistoryAppointment_RecentAppointment_ViewModels.Length;
            }
        }

        public Customer_ShoppingCardHistoryAppointment_RecentAppointment_ViewModel this[int i]
        {
            get { return Customer_ShoppingCardHistoryAppointment_RecentAppointment_ViewModels[i]; }
        }

    }

    public class Customer_ShoppingCardHistoryAppointment_RecentAppointment_ViewModel_ViewHolder : RecyclerView.ViewHolder
    {
        public ImageView ServiceImg { get; set; }
        public TextView OutletName { get; set; }
        public TextView Time { get; set; }
        public TextView Check { get; set; }

        public Customer_ShoppingCardHistoryAppointment_RecentAppointment_ViewModel_ViewHolder(View itemview, Action<int> listener) : base(itemview)
        {
            ServiceImg = ItemView.FindViewById<ImageView>(Resource.Id.imgService_ItemAppointment_ShoppingCardHistoryAppointment_Customer);
            OutletName = ItemView.FindViewById<TextView>(Resource.Id.txtOutlet_ItemAppointment_ShoppingCardHistoryAppointment_Customer);
            Time = ItemView.FindViewById<TextView>(Resource.Id.txtTime_ItemAppointment_ShoppingCardHistoryAppointment_Customer);
            Check = ItemView.FindViewById<TextView>(Resource.Id.txtCheck_ItemAppointment_ShoppingCardHistoryAppointment_Customer);
            itemview.Click += (sender, e) => listener(base.Position);
        }
    }

}