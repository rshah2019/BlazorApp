using System.Net.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;
using BlazorApp;
using BlazorApp.Shared;
using BlazorApp.Data;
using BlazorApp.Model;

namespace BlazorApp.Pages.TradingSystem
{
    public partial class SecurityInfo
    {
        public string BorrowRate
        {
            get
            {
                return securityData.BorrowRate != null ?
                        String.Format("{0:P4}", -1 * securityData.BorrowRate) :
                        "N/A";
            }
        }

        [Parameter]
        public string Ticker { get; set; }

        private SecurityData securityData;

        private void calculateConversion()
        {
            OnParametersSet();
        }

        protected override void OnParametersSet()
        {
            if (Ticker != null)
            {
                var task = Task.Run(async () => await RefreshData());
                securityData = task.GetAwaiter().GetResult();
            }
        }

        private async Task<SecurityData> RefreshData()
        {
            return await securityService.GetSecurityData(Ticker);
        }

        protected override async Task OnInitializedAsync()
        {
            if (Ticker != null)
            {
                securityData = await RefreshData();
            }
        }
    }
}