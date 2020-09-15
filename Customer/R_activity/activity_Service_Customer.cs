using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Support.V7.Widget;
using System;
using Microcharts.Droid;
using Microcharts;
using System.Collections.Generic;
using SkiaSharp;
using Customer.Models;
using GoldenSpa.API;
using System.Threading.Tasks;
using Refit;
using Android.Content;

namespace Customer
{
    
    [Activity(Label = "Service")]

    class activity_Service_Customer : AppCompatActivity
    {
        IMyAPI myAPI;

        ImageView back;
        TextView serviceName;
        TextView servicePrice;
        Spinner listOutlet;

        ChartView cv;
        TextView rateStar;
        int[] star = { 0, 0, 0, 0, 0 };

        TextView describe;

        RecyclerView.LayoutManager mLayoutManagerCustomerComment;
        RecyclerView mRecyclerViewCustomerComment;
        List<Comment> mCustomerComment_List;
        Service_CustomerComment_Customer_Adapter mAdapterCustomerComment;

        RecyclerView.LayoutManager mLayoutManagerRelativeDiscount;
        RecyclerView mRecyclerViewRelativeDiscount;
        List<ListPromotion> mRelativeDiscount_List;
        Service_RelativeDiscount_Customer_Adapter mAdapterRelativeDiscount;

        ImageView cart;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource  
            SetContentView(Resource.Layout.Service_Customer);

            back = FindViewById<ImageView>(Resource.Id.imgback_Service_Customer);
            back.Click += Back_Click;

            serviceName = FindViewById<TextView>(Resource.Id.txtServiceName_Service_Customer);
            if (Intent.GetStringExtra("ServiceName")==null)
                serviceName.Text = Intent.GetStringExtra("ComboName");
            else
                serviceName.Text = Intent.GetStringExtra("ServiceName");

            servicePrice = FindViewById<TextView>(Resource.Id.txtServicePrice_Service_Customer);
            servicePrice.Text = Intent.GetStringExtra("PromotionName");

            listOutlet = FindViewById<Spinner>(Resource.Id.spnOutlet_Service_Customer);
            getListOutlet();

            describe = FindViewById<TextView>(Resource.Id.txtContentDescripe_Service_Customer);
            getDescribe();

            cv = (ChartView)FindViewById(Resource.Id.chartView1);
            rateStar = FindViewById<TextView>(Resource.Id.txtRateStar_Service_Customer);
            DoAll();

            mRecyclerViewCustomerComment = FindViewById<RecyclerView>(Resource.Id.recyclerViewCustomerComment_Service_Customer);
            mLayoutManagerCustomerComment = new LinearLayoutManager(this);
            mRecyclerViewCustomerComment.SetLayoutManager(mLayoutManagerCustomerComment);
            getComment();

            

            mRecyclerViewRelativeDiscount = FindViewById<RecyclerView>(Resource.Id.recyclerViewRelativeDiscount_Service_Customer);
            mLayoutManagerRelativeDiscount = new LinearLayoutManager(this);
            mRecyclerViewRelativeDiscount.SetLayoutManager(mLayoutManagerRelativeDiscount);
            getRelativeDiscount();


            cv = (ChartView)FindViewById(Resource.Id.chartView1);
            rateStar = FindViewById<TextView>(Resource.Id.txtRateStar_Service_Customer);
            DoAll();

            cart = FindViewById<ImageView>(Resource.Id.imgcart_Service_Customer);
            cart.Click += Cart_Click1;

            

        }

        private async void Cart_Click1(object sender, EventArgs e)
        {
            myAPI = RestService.For<IMyAPI>("https://goldenspa.azurewebsites.net");
            var idCustomer = await myAPI.GetIdCustomer("0123456789");
            string cus = idCustomer.Substring(4, idCustomer.Length - 6);

            var List_Cart = await myAPI.GetCarts();
            int max = int.Parse(List_Cart[0].MaGioHang);
            for (int i=1;i<List_Cart.Count;i++)
            {
                if(max<int.Parse(List_Cart[i].MaGioHang))
                {
                    max = int.Parse(List_Cart[i].MaGioHang);
                }
                
            }
            max++;
            Cart cartt = new Cart();
            cartt.MaGioHang = max.ToString();
            cartt.MaKh = idCustomer.Substring(2, idCustomer.Length - 4);
            if (Intent.GetStringExtra("ServiceName") == null)
                cartt.MaCombo = Intent.GetStringExtra("ServiceId");
            else
                cartt.MaDv = Intent.GetStringExtra("ServiceId");
            var results = await myAPI.PostGioHang(cartt);
            Toast.MakeText(this, results, ToastLength.Short).Show();
        }

        private void Back_Click(object sender, EventArgs e)
        {
            Finish();
            SetContentView(Resource.Layout.Home_Customer);
            var navBottom = FindViewById<Android.Support.Design.Widget.BottomNavigationView>(Resource.Id.bottom_navigation);
            navBottom.NavigationItemSelected += (s, b) =>
            {
                var trans = SupportFragmentManager.BeginTransaction();
                trans.Replace(Resource.Id.frame_container, new Fragment.Home()).Commit();
            };
        }

        public async void getListOutlet()
        {
            myAPI = RestService.For<IMyAPI>("https://goldenspa.azurewebsites.net");
            string id = Intent.GetStringExtra("ServiceId");
            var result = await myAPI.GetOutletFromService(Intent.GetStringExtra("ServiceId"));

            //xử lí sự kiện chọn item
            //listOutlet.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(listOutlet_ItemSelected); 


            List<KeyValuePair<string, string>> outlets_pair = new List<KeyValuePair<string, string>>(result.Count);
            List<string> outlets = new List<string>(result.Count);

            for (int i=0;i<result.Count;i++)
            {
                var item = new KeyValuePair<string, string>(result[i].MaChiNhanh, result[i].DiaChi);
                outlets_pair.Add(item);
            }
            foreach (var item in outlets_pair)
                outlets.Add(item.Value);

            var adapter = new ArrayAdapter<string>(this,Android.Resource.Layout.SimpleSpinnerItem, outlets);
            listOutlet.Adapter = adapter;
        }


        public async void getDescribe()
        {
            myAPI = RestService.For<IMyAPI>("https://goldenspa.azurewebsites.net");
            var result = await myAPI.GetService(Intent.GetStringExtra("ServiceId"));
            describe.Text = result.MoTa;
        }

        public async void Drawchart()
        {
            List<ChartEntry> dataList = new List<ChartEntry>();
            dataList.Add(new ChartEntry((float)star[0])
            {
                Label = "1.0",
                ValueLabel = star[0].ToString(),
                Color = SKColor.Parse("#FF0")
            });


            dataList.Add(new ChartEntry((float)star[1])
            {
                Label = "2.0",
                ValueLabel = star[1].ToString(),
                Color = SKColor.Parse("#FF0")
            });


            dataList.Add(new ChartEntry((float)star[2])
            {
                Label = "3.0",
                ValueLabel = star[2].ToString(),
                Color = SKColor.Parse("#FF0")
            });


            dataList.Add(new ChartEntry((float)star[3])
            {
                Label = "4.0",
                ValueLabel = star[3].ToString(),
                Color = SKColor.Parse("#FF0")
            });


            dataList.Add(new ChartEntry((float)star[4])
            {
                Label = "5.0",
                ValueLabel = star[4].ToString(),
                Color = SKColor.Parse("#FF0"),
                
            });


            var chart = new BarChart() { Entries = dataList, LabelTextSize = 30f, LabelOrientation = Microcharts.Orientation.Horizontal, ValueLabelOrientation = Microcharts.Orientation.Horizontal };
            cv.Chart = chart;
        }

        public async void DoAll()
        {
            myAPI = RestService.For<IMyAPI>("https://goldenspa.azurewebsites.net");
            var result = await myAPI.GetComment(Intent.GetStringExtra("ServiceId")); 
            for (int i = 0; i < result.Count; i++)
            {
                star[(result[i].SoSao??default(int)) - 1]++;
            }
            
            Drawchart();
            double avg;
            if (((star[0] + star[1] + star[2] + star[3] + star[4])) != 0)
                avg = ((star[0] * 1 + star[1] * 2 + star[2] * 3 + star[3] * 4 + star[4] * 5) / (star[0] + star[1] + star[2] + star[3] + star[4]));
            else
                avg = 0;
            avg = Math.Round(avg, 1);
            rateStar.Text = (avg.ToString() + "/5").ToString();
            Array.Clear(star, 0, star.Length);

        }

        private void MAdapter_ItemClick(object sender, int e)
        {
            int photoNum = e + 1;
            Toast.MakeText(this, "This is photo number " + photoNum, ToastLength.Short).Show();
        }

        private async void getComment()
        {
            myAPI = RestService.For<IMyAPI>("https://goldenspa.azurewebsites.net");
            var result = await myAPI.GetComment(Intent.GetStringExtra("ServiceId"));
            mCustomerComment_List = new List<Comment>(result.Count);

            for (int i = 0; i < result.Count; i++)
            {
                var DataSample_Services_Outlet_ViewModel = new Comment();
                DataSample_Services_Outlet_ViewModel.Anh = result[i].Anh;
                DataSample_Services_Outlet_ViewModel.TenKH = result[i].TenKH;
                DataSample_Services_Outlet_ViewModel.comment = result[i].comment;
                DataSample_Services_Outlet_ViewModel.Ngay = result[i].Ngay;
                DataSample_Services_Outlet_ViewModel.SoSao = result[i].SoSao;
                mCustomerComment_List.Add(DataSample_Services_Outlet_ViewModel);
            }
            mAdapterCustomerComment = new Service_CustomerComment_Customer_Adapter(mCustomerComment_List);
            mRecyclerViewCustomerComment.SetAdapter(mAdapterCustomerComment);
        }

        private async void getRelativeDiscount()
        {
            myAPI = RestService.For<IMyAPI>("https://goldenspa.azurewebsites.net");
            var result = await myAPI.GetListPromotion();
            mRelativeDiscount_List = new List<ListPromotion>(result.Count);

            int max = 5;
            if (result.Count <= max)
                for (int i = 0; i < max; i++)
                {
                    if (i != Int32.Parse(Intent.GetStringExtra("Index")))
                    {
                        var DataSample_Services_Outlet_ViewModel = new ListPromotion();
                        DataSample_Services_Outlet_ViewModel.MaDV = result[i].MaDV;
                        DataSample_Services_Outlet_ViewModel.Image = result[i].Image;
                        DataSample_Services_Outlet_ViewModel.NameService = result[i].NameService;
                        DataSample_Services_Outlet_ViewModel.price = result[i].price;
                        DataSample_Services_Outlet_ViewModel.Discount = result[i].Discount;
                        DataSample_Services_Outlet_ViewModel.TotalOutlets = result[i].TotalOutlets;
                        mRelativeDiscount_List.Add(DataSample_Services_Outlet_ViewModel);
                    }
                }
            else
            {
                for (int i = 0; i < max; i++)
                {
                    if (i != Int32.Parse(Intent.GetStringExtra("Index")))
                    {
                        var DataSample_Services_Outlet_ViewModel = new ListPromotion();
                        DataSample_Services_Outlet_ViewModel.MaDV = result[i].MaDV;
                        DataSample_Services_Outlet_ViewModel.Image = result[i].Image;
                        DataSample_Services_Outlet_ViewModel.NameService = result[i].NameService;
                        DataSample_Services_Outlet_ViewModel.price = result[i].price;
                        DataSample_Services_Outlet_ViewModel.Discount = result[i].Discount;
                        DataSample_Services_Outlet_ViewModel.TotalOutlets = result[i].TotalOutlets;
                        mRelativeDiscount_List.Add(DataSample_Services_Outlet_ViewModel);
                    }
                    else
                        max++;
                }
            }


            mAdapterRelativeDiscount = new Service_RelativeDiscount_Customer_Adapter(mRelativeDiscount_List);
            mRecyclerViewRelativeDiscount.SetAdapter(mAdapterRelativeDiscount);

            mAdapterRelativeDiscount.ItemClick += (s, e) =>
            {
                Finish();
                var intent = new Intent(this, typeof(Customer.activity_Service_Customer));
                intent.PutExtra("ServiceId", mRelativeDiscount_List[e].MaDV);
                intent.PutExtra("ServiceName", mRelativeDiscount_List[e].NameService);
                intent.PutExtra("PromotionName", mRelativeDiscount_List[e].NamePromotion);
                intent.PutExtra("Index", e.ToString());
                StartActivity(intent);
            };
        }

        
    }
}