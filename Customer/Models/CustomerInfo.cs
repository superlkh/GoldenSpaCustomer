using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


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
    class CustomerInfo
    {
        [Required]
        [MinLength(2)]
        public string MaKh { get; set; }
        [Required]
        [MinLength(2)]
        public string TenKh { get; set; }
        [Required]
        [MinLength(2)]
        public string Email { get; set; }
        public string DiaChi { get; set; }
        public bool GioiTinh { get; set; }
        public DateTime? NgaySinh { get; set; }
        [Required]
        [MinLength(10)]
        [MaxLength(10)]
        public string Sdt { get; set; }
        public int? CanNang { get; set; }
        public int? ChieuCao { get; set; }
        public string AnhKh { get; set; }
    }
}