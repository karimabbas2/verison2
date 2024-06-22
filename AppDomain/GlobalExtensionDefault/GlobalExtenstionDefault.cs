using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AppDomain.Concrets;

namespace AppDomain
{
    public class GlobalExtenstionDefault : BaseEntity
    {
        public string? CodecFrom { get; set; }
        public string? CodecTo { get; set; }
        public int? Ext_Privilege { get; set; }
        public int? Ext_DTMF { get; set; }
        public int? JitterBuffer { get; set; }
        public int? Ext_Ring_Time { get; set; }
        public int? Ext_CC_Registrations { get; set; }
        public bool Enable_VM { get; set; }
        public bool Sync_Contact { get; set; }
        public bool Enable_NAT { get; set; }

    }
}