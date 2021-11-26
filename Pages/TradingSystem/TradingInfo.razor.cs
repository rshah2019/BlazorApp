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

namespace BlazorApp.Pages.TradingSystem
{
    public partial class TradingInfo
    {
        private bool isRealTime = false;
        private int currentCount = 0;
        private string customBps;

        [Parameter]
        public string Ticker { get; set; }

        private TradingData cheatSheet;
        private BasisPointShares CustomShares
        {
            get
            {
                return cheatSheet.BpsShares.Where(c => !STANDARD_BPS.Contains(c.BasisPoints)).FirstOrDefault();
            }
        }


        private void calculateConversion()
        {
            OnParametersSet();
        }

        protected override void OnParametersSet()
        {
            if (Ticker != null)
            {
                var task = Task.Run(async () => await RefreshData());
                cheatSheet = task.GetAwaiter().GetResult();
            }
        }

        private double[] STANDARD_BPS = new double[] { 5, 10, 25, 50 };
        private async Task<TradingData> RefreshData()
        {
            return await basisPointService.GetShares(Ticker, customBps != null ? STANDARD_BPS.Concat(new[] { Double.Parse(customBps) }) : STANDARD_BPS);
        }

        protected override async Task OnInitializedAsync()
        {
            if (Ticker != null)
            {
                cheatSheet = await RefreshData();
            }
            AutomaticRefresh();
        }

        private void AutomaticRefresh()
        {
            var timer = new Timer(new TimerCallback(_ =>
            {
                if (isRealTime) {
                    currentCount++;
                    InvokeAsync(() =>
                    {
                        OnParametersSet();
                        StateHasChanged();
                    });
                  }
                }), null, 1000 * 1, 1000 * 1);
            
        }
    }
}