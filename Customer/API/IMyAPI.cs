using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Customer.Model;
using Refit;

namespace GoldenSpa.API
{
    interface IMyAPI
    {
        //http://localhost:51620/api/login

        [Get("/api/listoutlet")]
        Task<List<ListOutlet>> GetListChiNhanh();





    }
}