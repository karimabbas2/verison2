using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppDomain.Enums;

namespace AppDomain
{
    public partial class Extenstion
    {
        public bool Enable_NAT { get; set; }
        public bool Enable_DM { get; set; }
        public int? DTMF_ModeId {get;set;}
        public DTMF? DTMF_Mode { get; set; }
        public int? JitterBufferId {get;set;}
        public JitterBuffer? JitterBuffer { get; set; }
        public string? A_CodecFrom { get; set; }
        public string? A_CodecTo { get; set; }
        public SRTP? SRTP { get; set; }
        
    }
}