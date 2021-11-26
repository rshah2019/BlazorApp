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
    public partial class TabPage
    {
        [CascadingParameter]
        private TabControl? Parent { get; set; }

        [Parameter]
        public RenderFragment? ChildContent { get; set; }

        protected override void OnInitialized()
        {
            if (Parent == null)
                throw new ArgumentNullException(nameof(Parent), "TabPage must exist within a TabControl");
            base.OnInitialized();
            Parent.AddPage(this);
        }

        [Parameter]
        public string? Text { get; set; }
    }
}