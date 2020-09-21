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
    public class Cart
    {
        public string MaGioHang { get; set; }
        public string MaKh { get; set; }
        public string MaDv { get; set; }
        public string MaCombo { get; set; }
        public string? MaKhuyenMai { get; set; }
    }
}