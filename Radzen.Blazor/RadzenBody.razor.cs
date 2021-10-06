﻿using Microsoft.AspNetCore.Components;
using System.Linq;

namespace Radzen.Blazor
{
    public partial class RadzenBody : RadzenComponentWithChildren
    {
        [Parameter]
        public override string Style { get; set; } = "margin-top: 51px; margin-bottom: 57px; margin-left:250px;";

        protected override string GetComponentCssClass()
        {
            return "body";
        }

        public void Toggle()
        {
            Expanded = !Expanded;

            StateHasChanged();
        }

        protected string GetStyle()
        {
            var marginLeft = 250;

            if (!string.IsNullOrEmpty(Style))
            {
                var marginLeftStyle = Style.Split(';').Where(i => i.Split(':')[0].Contains("margin-left")).FirstOrDefault();
                if (!string.IsNullOrEmpty(marginLeftStyle) && marginLeftStyle.Contains("px"))
                {
                    marginLeft = int.Parse(marginLeftStyle.Split(':')[1].Trim().Replace("px", "").Split('.')[0].Trim());
                }
            }

            return $"{Style}; margin-left: {(Expanded ? 0 : marginLeft)}px";
        }

        [Parameter]
        public bool Expanded { get; set; } = false;

        [Parameter]
        public EventCallback<bool> ExpandedChanged { get; set; }
    }
}
