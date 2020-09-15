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
    public partial class AddressOfService
    {
        public string MaChiNhanh { get; set; }
        public string DiaChi { get; set; }
    }
}