﻿// <auto-generated />
using System;
using System.Net.Http;
using System.Collections.Generic;
using Customer.RefitInternalGenerated;

/* ******** Hey You! *********
 *
 * This is a generated file, and gets rewritten every time you build the
 * project. If you want to edit it, you need to edit the mustache template
 * in the Refit package */

#pragma warning disable
namespace Customer.RefitInternalGenerated
{
    [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    [AttributeUsage (AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Event | AttributeTargets.Interface | AttributeTargets.Delegate)]
    sealed class PreserveAttribute : Attribute
    {

        //
        // Fields
        //
        public bool AllMembers;

        public bool Conditional;
    }
}
#pragma warning restore

#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
#pragma warning disable CS8669 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context. Auto-generated code requires an explicit '#nullable' directive in source.
namespace GoldenSpa.API
{
    using global::System;
    using global::System.Collections.Generic;
    using global::System.Linq;
    using global::System.Text;
    using global::System.Threading.Tasks;
    using global::Android.App;
    using global::Android.Content;
    using global::Android.OS;
    using global::Android.Runtime;
    using global::Android.Views;
    using global::Android.Widget;
    using global::Customer.Models;
    using global::Refit;
    using global::Customer;

    /// <inheritdoc />
    [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    [global::System.Diagnostics.DebuggerNonUserCode]
    [Preserve]
    [global::System.Reflection.Obfuscation(Exclude=true)]
    partial class AutoGeneratedIMyAPI : IMyAPI
    {
        /// <inheritdoc />
        public HttpClient Client { get; protected set; }
        readonly IRequestBuilder requestBuilder;

        /// <inheritdoc />
        public AutoGeneratedIMyAPI(HttpClient client, IRequestBuilder requestBuilder)
        {
            Client = client;
            this.requestBuilder = requestBuilder;
        }

        /// <inheritdoc />
        Task<List<ListOutlet>> IMyAPI.GetListChiNhanh()
        {
            var arguments = new object[] {  };
            var func = requestBuilder.BuildRestResultFuncForMethod("GetListChiNhanh", new Type[] {  });
            return (Task<List<ListOutlet>>)func(Client, arguments);
        }

        /// <inheritdoc />
        Task<List<ListPromotion>> IMyAPI.GetListPromotion()
        {
            var arguments = new object[] {  };
            var func = requestBuilder.BuildRestResultFuncForMethod("GetListPromotion", new Type[] {  });
            return (Task<List<ListPromotion>>)func(Client, arguments);
        }

        /// <inheritdoc />
        Task<List<ListPromotion>> IMyAPI.GetListCombo()
        {
            var arguments = new object[] {  };
            var func = requestBuilder.BuildRestResultFuncForMethod("GetListCombo", new Type[] {  });
            return (Task<List<ListPromotion>>)func(Client, arguments);
        }

        /// <inheritdoc />
        Task<List<ListAdvertisement>> IMyAPI.GetListAdvertisement()
        {
            var arguments = new object[] {  };
            var func = requestBuilder.BuildRestResultFuncForMethod("GetListAdvertisement", new Type[] {  });
            return (Task<List<ListAdvertisement>>)func(Client, arguments);
        }

        /// <inheritdoc />
        Task<List<ListPromotion>> IMyAPI.GetListServiceUsed(string id)
        {
            var arguments = new object[] { id };
            var func = requestBuilder.BuildRestResultFuncForMethod("GetListServiceUsed", new Type[] { typeof(string) });
            return (Task<List<ListPromotion>>)func(Client, arguments);
        }

        /// <inheritdoc />
        Task<List<ListPromotion>> IMyAPI.GetListComboUsed(string id)
        {
            var arguments = new object[] { id };
            var func = requestBuilder.BuildRestResultFuncForMethod("GetListComboUsed", new Type[] { typeof(string) });
            return (Task<List<ListPromotion>>)func(Client, arguments);
        }

        /// <inheritdoc />
        Task<string> IMyAPI.GetIdCustomer(string id)
        {
            var arguments = new object[] { id };
            var func = requestBuilder.BuildRestResultFuncForMethod("GetIdCustomer", new Type[] { typeof(string) });
            return (Task<string>)func(Client, arguments);
        }

        /// <inheritdoc />
        Task<List<ListService>> IMyAPI.GetServiceFromOutlet(string outletId)
        {
            var arguments = new object[] { outletId };
            var func = requestBuilder.BuildRestResultFuncForMethod("GetServiceFromOutlet", new Type[] { typeof(string) });
            return (Task<List<ListService>>)func(Client, arguments);
        }

        /// <inheritdoc />
        Task<List<ListService>> IMyAPI.GetComboFromOutlet(string outletId)
        {
            var arguments = new object[] { outletId };
            var func = requestBuilder.BuildRestResultFuncForMethod("GetComboFromOutlet", new Type[] { typeof(string) });
            return (Task<List<ListService>>)func(Client, arguments);
        }

        /// <inheritdoc />
        Task<List<ListService>> IMyAPI.GetPromotionFromOutlet(string outletId)
        {
            var arguments = new object[] { outletId };
            var func = requestBuilder.BuildRestResultFuncForMethod("GetPromotionFromOutlet", new Type[] { typeof(string) });
            return (Task<List<ListService>>)func(Client, arguments);
        }

        /// <inheritdoc />
        Task<DetailService> IMyAPI.GetService(string serviceId)
        {
            var arguments = new object[] { serviceId };
            var func = requestBuilder.BuildRestResultFuncForMethod("GetService", new Type[] { typeof(string) });
            return (Task<DetailService>)func(Client, arguments);
        }

        /// <inheritdoc />
        Task<List<TotalFeedback>> IMyAPI.GetStar(string serviceId)
        {
            var arguments = new object[] { serviceId };
            var func = requestBuilder.BuildRestResultFuncForMethod("GetStar", new Type[] { typeof(string) });
            return (Task<List<TotalFeedback>>)func(Client, arguments);
        }

        /// <inheritdoc />
        Task<List<AddressOfService>> IMyAPI.GetOutletFromService(string serviceId)
        {
            var arguments = new object[] { serviceId };
            var func = requestBuilder.BuildRestResultFuncForMethod("GetOutletFromService", new Type[] { typeof(string) });
            return (Task<List<AddressOfService>>)func(Client, arguments);
        }

        /// <inheritdoc />
        Task<List<Comment>> IMyAPI.GetComment(string serviceId)
        {
            var arguments = new object[] { serviceId };
            var func = requestBuilder.BuildRestResultFuncForMethod("GetComment", new Type[] { typeof(string) });
            return (Task<List<Comment>>)func(Client, arguments);
        }

        /// <inheritdoc />
        Task<List<Cart>> IMyAPI.GetCarts()
        {
            var arguments = new object[] {  };
            var func = requestBuilder.BuildRestResultFuncForMethod("GetCarts", new Type[] {  });
            return (Task<List<Cart>>)func(Client, arguments);
        }

        /// <inheritdoc />
        Task<CustomerInfo> IMyAPI.GetCustomerInfo(string customerId)
        {
            var arguments = new object[] { customerId };
            var func = requestBuilder.BuildRestResultFuncForMethod("GetCustomerInfo", new Type[] { typeof(string) });
            return (Task<CustomerInfo>)func(Client, arguments);
        }

        /// <inheritdoc />
        Task<string> IMyAPI.PostGioHang(Cart cart)
        {
            var arguments = new object[] { cart };
            var func = requestBuilder.BuildRestResultFuncForMethod("PostGioHang", new Type[] { typeof(Cart) });
            return (Task<string>)func(Client, arguments);
        }

        /// <inheritdoc />
        Task<string> IMyAPI.UpdateCustomerInfo(CustomerInfo cus)
        {
            var arguments = new object[] { cus };
            var func = requestBuilder.BuildRestResultFuncForMethod("UpdateCustomerInfo", new Type[] { typeof(CustomerInfo) });
            return (Task<string>)func(Client, arguments);
        }
    }
}

#pragma warning restore CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
#pragma warning restore CS8669 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context. Auto-generated code requires an explicit '#nullable' directive in source.
