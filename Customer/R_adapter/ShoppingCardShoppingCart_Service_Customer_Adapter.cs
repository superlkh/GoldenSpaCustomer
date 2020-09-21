using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Customer.Fragment;
using Customer.Models;
using GoldenSpa.API;
using Java.Util;
using Refit;
using Square.OkHttp3;
using Square.Picasso;


namespace Customer
{
    public class ShoppingCardShoppingCart_Service_Customer_Adapter : RecyclerView.Adapter
    {
        IMyAPI myAPI;
        public event EventHandler<int> ItemClick;
        public List<CartInfo> cart_list;

        public ShoppingCardShoppingCart_Service_Customer_Adapter(List<CartInfo> Cart_List)
        {
            cart_list = Cart_List;
        }

        public override int ItemCount
        {
            get { return cart_list.Count; }
        }

        public async override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            Customer_ShoppingCardShoppingCart_Service_ViewModel_ViewHolder vh = holder as Customer_ShoppingCardShoppingCart_Service_ViewModel_ViewHolder;

            //myAPI = RestService.For<IMyAPI>("https://goldenspa.azurewebsites.net");
            //var result = await myAPI.GetOutletFromService(cart_list[position].MaDv);

            getOutlet a = new getOutlet();
            //a.GetOutletToSpinner(vh.Outlet, result);

            if (cart_list[position].Anhdv=="")
            {
                Picasso.Get().Load(cart_list[position].Anhcb).Into(vh.ServiceImg);
            }
            else
                Picasso.Get().Load(cart_list[position].Anhdv).Into(vh.ServiceImg);
            //vh.OutletName.Text = cart_list[position].ten;
            //vh.Time.Text = cart_list[position].NgayHen.ToString();
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.Item_ShoppingCardShoppingCart_Service_Customer, parent, false);
            Customer_ShoppingCardShoppingCart_Service_ViewModel_ViewHolder vh = new Customer_ShoppingCardShoppingCart_Service_ViewModel_ViewHolder(itemView, OnClick);
            getTherapist();

            //var resultTherapist=myAPI.GetTherapists(result[0])
            return vh;
        }
        private void OnClick(int obj)
        {
            if (ItemClick != null)
                ItemClick(this, obj);
        }
        //public DateTime(int year, int day, int month);
        private async void getTherapist()
        {
            myAPI = RestService.For<IMyAPI>("https://goldenspa.azurewebsites.net");
            //DateTime date1 = new DateTime(2020, 4, 6);
            //var result = await myAPI.GetListDoctor("CN1", date1, "1");
            //int i = 0;


            var result = await myAPI.GetCart("KH1");
            int i = 1;
        }
    }

    public class getOutlet:AppCompatActivity
    {
        public void GetOutletToSpinner(Spinner spn, List<AddressOfService> result)
        {
            List<KeyValuePair<string, string>> outlets_pair = new List<KeyValuePair<string, string>>(result.Count);
            List<string> outlets = new List<string>(result.Count);

            for (int i = 0; i < result.Count; i++)
            {
                var item = new KeyValuePair<string, string>(result[i].MaChiNhanh, result[i].DiaChi);
                outlets_pair.Add(item);
            }
            foreach (var item in outlets_pair)
                outlets.Add(item.Value);

            var adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerItem, outlets);
            spn.Adapter = adapter;
        }
    }
}