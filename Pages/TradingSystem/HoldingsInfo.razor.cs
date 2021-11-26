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
    public partial class HoldingsInfo
    {
        [Parameter]
        public string Ticker {get; set;}

        private HoldingsData holdingsData;

        private void calculateConversion()
        {
            OnParametersSet();
        }

        protected override void OnParametersSet()
        {
            if (Ticker != null)
            {
                var task = Task.Run(async () => await RefreshData());
                holdingsData = task.GetAwaiter().GetResult();
            }
        }

        private async Task<HoldingsData> RefreshData()
        {
            return await holdingService.GetPosition(Ticker);
        }

        protected override async Task OnInitializedAsync()
        {
            if (Ticker != null)
            {
                holdingsData = await RefreshData();
            }
        }
    }
}