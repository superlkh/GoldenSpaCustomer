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
    public partial class Comment
    {
        public string? Anh { get; set; }
        public string TenKH { get; set; }
        public string? comment { get; set; }
        public DateTime? Ngay { get; set; }
        public int? SoSao { get; set; }
    }
}