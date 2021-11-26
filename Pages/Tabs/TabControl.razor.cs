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

namespace BlazorApp.Pages.Tabs
{
    public partial class TabControl
    {
        // Next line is needed so we are able to add <TabPage> components inside
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        public TabPage ActivePage { get; set; }
        List<TabPage> Pages = new List<TabPage>();
        internal void AddPage(TabPage tabPage)
        {
            Pages.Add(tabPage);
            if (Pages.Count == 1)
                ActivePage = tabPage;
            StateHasChanged();
        }

        string GetButtonClass(TabPage page)
        {
            return page == ActivePage ? "btn-primary" : "btn-secondary";
        }
        void ActivatePage(TabPage page)
        {
            ActivePage = page;
        }
    }
}