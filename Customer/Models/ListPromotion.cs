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
using System.ComponentModel.DataAnnotations;

namespace Customer.Models
{
    public partial class ListPromotion
    {
        [Required]
        [MinLength(2)]
        public string MaDV { get; set; }
        public string? Image { get; set; }
        public string? NameService { get; set; }
        public string? NamePromotion { get; set; }
        public int? price { get; set; }
        public double? Discount { get; set; }
        public int TotalOutlets { get; set; }
    }
}