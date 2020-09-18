using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Net.Wifi.Aware;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Customer.Models
{
    public class AppointmentInfo
    {
        [Required]
        [MinLength(2)]
        public string MaLichHen { get; set; }
        [Required]
        [MinLength(2)]
        public string MaKh { get; set; }
        [Required]
        [MinLength(2)]
        public string TenChiNhanh { get; set; }
        public string AnhChiNhanh { get; set; }
        [Required]
        [MinLength(2)]
        public int TongDv { get; set; }
        
        [Required]
        [MinLength(2)]
        public DateTime NgayGioHen { get; set; }

    }
}