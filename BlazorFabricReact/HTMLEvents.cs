using Microsoft.JSInterop;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorFabricReact
{
    public class HTMLEvents
    {
        public Action ClickAction { get; set; }
        [JSInvokable] public void OnClick()
        {
            ClickAction?.Invoke();
        }


    }
}
