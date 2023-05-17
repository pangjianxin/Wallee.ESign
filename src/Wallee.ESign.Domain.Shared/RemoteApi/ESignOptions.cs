using System;
using System.Collections.Generic;
using System.Text;

namespace Wallee.ESign.RemoteApi
{
    public class ESignOptions
    {
        public string AppId { get; set; } = null!;
        public string AppSecret { get; set; } = null!;
        public string BaseUrl { get; set; } = null!;
    }
}
