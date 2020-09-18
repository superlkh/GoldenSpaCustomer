using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Customer.Models;
using Refit;
using Customer;
namespace GoldenSpa.API
{
    interface IMyAPI
    {
        //http://localhost:51620/api/login

        //lấy danh sách chi nhánh
        [Get("/api/listoutlet")]
        Task<List<ListOutlet>> GetListChiNhanh();

        //lấy danh sách khuyến mãi discount
        [Get("/api/listpromotion")]
        Task<List<ListPromotion>> GetListPromotion();

        //lấy danh sách combo
        [Get("/api/combo/listcombo")]
        Task<List<ListPromotion>> GetListCombo();

        //lấy ảnh quảng cáo ở trang chủ
        [Get("/api/advertisement")]
        Task<List<ListAdvertisement>> GetListAdvertisement();

        [Get("/api/serviceused/service/{id}")]
        Task<List<ListPromotion>> GetListServiceUsed(string id);

        [Get("/api/serviceused/combo/{id}")]
        Task<List<ListPromotion>> GetListComboUsed(string id);

        [Get("/api/login/idcustomer/{id}")]
        Task<string> GetIdCustomer(string id);

        //lấy danh sách dịch vụ của chi nhánh (dịch vụ có khuyến mãi và không khuyến mãi)
        [Get("/api/ListOutlet/service/{outletId}")]
        Task<List<ListService>> GetServiceFromOutlet(string outletId);

        //lấy danh sách combo của chi nhánh
        [Get("/api/ListOutlet/combo/{outletId}")]
        Task<List<ListService>> GetComboFromOutlet(string outletId);
        
        //lấy danh sách khuyến mãi của chi nhánh
        [Get("/api/listpromotion/{outletId}")]
        Task<List<ListService>> GetPromotionFromOutlet(string outletId);

        //lấy thông tin dịch vụ từ mã 
        [Get("/api/services/{serviceId}")]
        Task<DetailService> GetService(string serviceId);

        //lấy tổng số sao
        [Get("/api/feedbacks/{serviceId}")]
        Task<List<TotalFeedback>> GetStar(string serviceId);

        //lấy danh sách chi nhánh có chứa dịch vụ
        [Get("/api/services/address/{serviceId}")]
        Task<List<AddressOfService>> GetOutletFromService(string serviceId);

        //lấy comment của 1 dịch vụ
        [Get("/api/feedbacks/comment/{serviceId}")]
        Task<List<Comment>> GetComment(string serviceId);

        //đếm số lượng trong giỏ hàng
        [Get("/api/carts")]
        Task<List<Cart>> GetCarts();

        //lấy thông tin khách hàng
        [Get("/api/customer/{customerId}")]
        Task<CustomerInfo> GetCustomerInfo(string customerId);

        //thêm vào giỏ hàng
        [Post("/api/carts")]
        Task<string> PostGioHang(Cart cart);

        //Sửa thông tin khách hàng
        [Put("/api/customer/{cus}")]
        Task<string> UpdateCustomerInfo(CustomerInfo cus);


    }
}