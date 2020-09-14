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
    public class Customer_Home_Outlet_ViewModel
    {
        public string mImage { get; set; }
        public string mName { get; set; }
        public string mAdress { get; set; }
    }

    public class Customer_Home_Outlet_ViewModel_List
    {
        //static Customer_Home_Outlet_ViewModel[] DataSample_Customer_Home_Outlet_ViewModel_List =
        //{
        //    new Customer_Home_Outlet_ViewModel(){mImage="https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcRAaeUNhCKAbGjfoJ9WPiJVd7D6HL_k0Zu7vQ&usqp=CAU",mName="Nguyễn Bỉnh Khiêm",mAdress="123 Nguyễn Bỉnh Khiêm tphcm"},
        //    new Customer_Home_Outlet_ViewModel(){mImage="https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcRAaeUNhCKAbGjfoJ9WPiJVd7D6HL_k0Zu7vQ&usqp=CAU",mName="Nguyễn Bỉnh Khiêm",mAdress="123 Nguyễn Bỉnh Khiêm tphcm"},
        //    new Customer_Home_Outlet_ViewModel(){mImage="https://redi.vn/wp-content/uploads/2019/05/dich-vu-thiet-ke-hinh-anh-quang-cao-slider.jpg",mName="Nguyễn Bỉnh Khiêm",mAdress="123 Nguyễn Bỉnh Khiêm tphcm"}
        //};

        private List<Customer_Home_Outlet_ViewModel> Customer_Home_Outlet_ViewModels;
        Random random;

        public Customer_Home_Outlet_ViewModel_List(List<Customer_Home_Outlet_ViewModel> list)
        {
            this.Customer_Home_Outlet_ViewModels = list;
            random = new Random();
        }

        public int Customer_Home_NumOutlet_ViewModel
        {
            get
            {
                return Customer_Home_Outlet_ViewModels.Count;
            }
        }

        public Customer_Home_Outlet_ViewModel this[int i]
        {
            get { return Customer_Home_Outlet_ViewModels[i]; }
        }

    }

    public class Customer_Home_Outlet_ViewModel_ViewHolder : RecyclerView.ViewHolder
    {
        public ImageView OutletImg { get; set; }
        public TextView OutletName { get; set; }
        public TextView OutletAdress { get; set; }


        public Customer_Home_Outlet_ViewModel_ViewHolder(View itemview, Action<int> listener) : base(itemview)
        {
            //OutletImg = itemview.FindViewById<ImageView>(Resource.Id.imgOutlet_ItemOutlet_Home_Customer);
            //OutletName = itemview.FindViewById<TextView>(Resource.Id.txtOutletName_ItemOutlet_Home_Customer);
            //OutletAdress = itemview.FindViewById<TextView>(Resource.Id.txtAdress_ItemOutlet_Home_Customer);
            //itemview.Click += (sender, e) => listener(base.Position);
        }
    }

}