using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppDomain.Concrets;

namespace AppDomain
{
    public class SIPSetting : BaseEntity
    {
        public int? UDP_PORT { get; set; }
        public int? TCP_PORT { get; set; }
        public int? TLS_PORT { get; set; }
        public int? RTP_Range_From { get; set; }
        public int? RTP_Range_TO { get; set; }
        public string? STUN_Address { get; set; }
    }
}