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
    public partial class ListOutlet
    {
        [Required]
        [MinLength(2)]
        public string? MaCN { get; set; }
        public string? Image { get; set; }
        public string? name { get; set; }
        public string? address { get; set; }
    }
}