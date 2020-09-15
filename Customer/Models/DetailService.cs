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
    class DetailService
    {
        [Required]
        [MinLength(2)]
        public string MaDichVu { get; set; }
        [Required]
        [MinLength(2)]
        public string TenDv { get; set; }
        public string MoTa { get; set; }
        public string Anh { get; set; }
        [Required]
        [MinLength(2)]
        public int DoDaiDv { get; set; }
        [Required]
        [MinLength(2)]
        public int Gia { get; set; }
        public bool? DungThu { get; set; }
    }
}