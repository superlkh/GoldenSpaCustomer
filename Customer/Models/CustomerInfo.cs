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
        public string maKh { get; set; }
        [Required]
        [MinLength(2)]
        public string tenKh { get; set; }
        [Required]
        [MinLength(2)]
        public string email { get; set; }
        public string diaChi { get; set; }
        public bool gioitinh { get; set; }
        public DateTime? ngaySinh { get; set; }
        [Required]
        [MinLength(10)]
        [MaxLength(10)]
        public string sdt { get; set; }
        public int? canNang { get; set; }
        public int? chieuCao { get; set; }
        public string anhKh { get; set; }
    }
}