using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorFabricReact
{
    public class ButtonProps
    {
        public string ariaDescription { get; set; }
        public bool ariaHidden { get; set; }
        public string ariaLabel { get; set; }
        [JsonProperty(PropertyName = "checked")]
        public bool Checked { get; set; }
        public bool disabled { get; set; }
        public string text { get; set; }
        public bool toggle { get; set; }
    }
}
