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
    public class Customer_DetailService_Service_ViewModel
    {
        public string mImageService { get; set; }
        public string mServiceName { get; set; }
        public string mTime { get; set; }
        public int mRoom { get; set; }
        public int mBed { get; set; }
    }

    public class Customer_DetailService_Service_ViewModel_List
    {
        static Customer_DetailService_Service_ViewModel[] DataSample_Customer_DetailService_Service_ViewModel_List =
        {
            new Customer_DetailService_Service_ViewModel(){mImageService="https://redi.vn/wp-content/uploads/2019/05/dich-vu-thiet-ke-hinh-anh-quang-cao-slider.jpg",mServiceName="Combo tắm nắng 700k",mTime="Hẹn đến 16g30 23/2/2020",mRoom=102,mBed=01},
            new Customer_DetailService_Service_ViewModel(){mImageService="https://redi.vn/wp-content/uploads/2019/05/dich-vu-thiet-ke-hinh-anh-quang-cao-slider.jpg",mServiceName="Xông hơi",mTime="Hẹn đến 16g30 23/2/2020",mRoom=103,mBed=01},
            new Customer_DetailService_Service_ViewModel(){mImageService="https://redi.vn/wp-content/uploads/2019/05/dich-vu-thiet-ke-hinh-anh-quang-cao-slider.jpg",mServiceName="Xông hơi",mTime="Hẹn đến 16g30 23/2/2020",mRoom=104,mBed=03},
        };

        private Customer_DetailService_Service_ViewModel[] Customer_DetailService_Service_ViewModels;
        Random random;

        public Customer_DetailService_Service_ViewModel_List()
        {
            this.Customer_DetailService_Service_ViewModels = DataSample_Customer_DetailService_Service_ViewModel_List;
            random = new Random();
        }

        public int Customer_DetailService_NumService_ViewModel
        {
            get
            {
                return Customer_DetailService_Service_ViewModels.Length;
            }
        }

        public Customer_DetailService_Service_ViewModel this[int i]
        {
            get { return Customer_DetailService_Service_ViewModels[i]; }
        }

    }

    public class Customer_DetailService_Service_ViewModel_ViewHolder : RecyclerView.ViewHolder
    {
        public ImageView ServiceImg { get; set; }
        public TextView ServiceName { get; set; }
        public TextView Time { get; set; }
        public TextView Room { get; set; }
        public TextView Bed { get; set; }


        public Customer_DetailService_Service_ViewModel_ViewHolder(View itemview, Action<int> listener) : base(itemview)
        {
            ServiceImg = ItemView.FindViewById<ImageView>(Resource.Id.imgService_ItemService_DetailService_Customer);
            ServiceName = ItemView.FindViewById<TextView>(Resource.Id.txtServiceName_ItemService_DetailService_Customer);
            Time = ItemView.FindViewById<TextView>(Resource.Id.txtTime_ItemService_DetailService_Customer);
            Room = ItemView.FindViewById<TextView>(Resource.Id.txtRoomNumber_ItemService_DetailService_Customer); 
            Bed = ItemView.FindViewById<TextView>(Resource.Id.txtNumberBed_ItemService_DetailService_Customer);
            itemview.Click += (sender, e) => listener(base.Position);
        }
    }

}