using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCore.Dtos.Extension
{
    public class ExtensionDataTable
    {
        public bool Enable_Ext { get; set; }
        public int? Ext_Number { get; set; }
        public int? CallerId_Number { get; set; }
        public string? DTMF_Mode { get; set; }
        public string? F_Name { get; set; }
        public string? Mobile { get; set; }
    }
}