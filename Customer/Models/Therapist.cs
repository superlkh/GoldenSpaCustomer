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
    public partial class Therapist
    {
        [Required]
        [MinLength(2)]
        public string MaNv { get; set; }
        [Required]
        [MinLength(2)]
        public string TenNv { get; set; }
        [Required]
        [MinLength(2)]
        public string MaCn { get; set; }
        [Required]
        [MinLength(2)]
        public string Email { get; set; }
        public string DiaChi { get; set; }
        public DateTime NgaySinh { get; set; }
        public string AnhNv { get; set; }
        [Required]
        [MinLength(10)]
        [MaxLength(10)]
        public string Sdt { get; set; }
        public int SoNamKinhNghiem { get; set; }
        public string ChuyenVe { get; set; }
    }
}