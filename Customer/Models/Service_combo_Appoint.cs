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
    public partial class Service_combo_Appoint
    {
        public string TenDV { get; set; }
        public string AnhDV { get; set; }
        public bool? VIP { get; set; }
        public string Room { get; set; }
        public string Bed { get; set; }
        public DateTime NgayHen { get; set; }
        public DateTime? GioHen { get; set; }
    }
}