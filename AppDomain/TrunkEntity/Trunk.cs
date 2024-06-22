using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AppDomain.Concrets;

namespace AppDomain.TrunkEntity
{
    public partial class Trunk : BaseEntity
    {
        public bool Enable_Trunk { get; set; }
        public string? Type { get; set; }
        public string? Name { get; set; }
        public bool Need_Registration { get; set; }
        public int? Port { get; set; }
        public string? Server_Address { get; set; }
        public string? Out_Proxy_Server { get; set; }
        public int? Out_Proxy_Port { get; set; }
        public string? Transport { get; set; }
        public bool Enable_KA { get; set; }
        public int? KA_Freq { get; set; }

    }
}