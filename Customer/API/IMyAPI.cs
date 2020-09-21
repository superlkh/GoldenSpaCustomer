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
using Java.Util;

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

        //lấy danh sách dịch vụ đã sử dụng từ mã khách hàng
        [Get("/api/serviceused/service/{id}")]
        Task<List<ListPromotion>> GetListServiceUsed(string id);

        //lấy danh sách combo đã sử dụng từ mã khách hàng
        [Get("/api/serviceused/combo/{id}")]
        Task<List<ListPromotion>> GetListComboUsed(string id);

        //lấy mã khách hàng từ sđt
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

        //lấy thông tin chi nhánh từ mã chi nhánh
        [Get("/api/outlets/{outletId}")]
        Task<Outlet> GetOutletFromId(string outletId);

        //lấy lịch hẹn từ mã khách hàng
        [Get("/api/appointments/info/{customerId}")]
        Task<List<AppointmentInfo>> GetAppointment(string customerId);

        //lấy chi tiết lịch hẹn từ mã lịch hẹn
        [Get("/api/appointments/detail/{appointmentId}")]
        Task<List<AppointmentDetail>> GetAppointmentDetail(string appointmentId);

        //lấy danh sách dịch vụ trong giỏ hàng từ mã khách hàng
        [Get("/api/carts/{customerId}")]
        Task<List<CartInfo>> GetCart(string customerId);

        //lấy danh sách dịch vụ (gồm cả khuyến mãi) của lịch hẹn
        [Get("/api/appointmentService/detail/{appointmentId}")]
        Task<List<Service_combo_Appoint>> GetServiceOfAppointment(string appointmentId);

        //lấy danh sách combo của lịch hẹn
        [Get("/api/appointmentCombo/detail/{appointmentId}")]
        Task<List<Service_combo_Appoint>> GetComboOfAppointment(string appointmentId);

        //lấy danh sách bác sĩ từ chi nhánh, ngày, múi giờ
        [Get("/api/appointments/find/{outletId}/{date}/{time}")]
        Task<List<string>> GetListDoctor(string outletId, DateTime date, string time);

        //lấy danh sách thông tin bác sĩ từ mã bác sĩ
        [Get("/api/EditProfile_Therapist_/{therapistId}")]
        Task<List<Therapist>> GetTherapists(string therapistId);

        //lấy lịch sử lịch hẹn
        [Get("/api/appointments/history/{customerId}")]
        Task<List<HistoryAppointment>> GetHistoryAppointment(string customerId);

        //thêm vào giỏ hàng
        [Post("/api/carts")]
        Task<string> PostGioHang(Cart cart);

        //Sửa thông tin khách hàng--chưa test
        [Put("/api/customer/{cus}")]
        Task<string> UpdateCustomerInfo(CustomerInfo cus);


    }
}