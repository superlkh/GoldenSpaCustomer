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
    public partial class AppointmentInfo
    {
        [Required]
        [MinLength(2)]
        public string MaLichHen { get; set; }
        [Required]
        [MinLength(2)]
        public string TenChiNhanh { get; set; }
        public string? AnhChiNhanh { get; set; }

        public int TongDv { get; set; }

        public DateTime NgayHen { get; set; }
        public DateTime? GioHen { get; set; }
    }
}