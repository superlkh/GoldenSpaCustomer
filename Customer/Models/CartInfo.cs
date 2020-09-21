using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Customer.Models
{
    public partial class CartInfo
    {
        public string MaGioHang { get; set; }
        public string MaKh { get; set; }
        public string? Anhdv { get; set; }
        public string? Anhcb { get; set; }
        public string? TenKhuyenMai { get; set; }
        public string? MaDv { get; set; }
        public string? MaCombo { get; set; }
    }
}