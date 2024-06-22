using AppDomain.Enums;

namespace AppDomain.TrunkEntity
{
    public partial class Trunk
    {
        public bool Enable_NAT { get; set; }
        public string? From_User { get; set; }
        public string? From_Domain { get; set; }
        public int? DTMF_ModeId { get; set; }
        public DTMF? DTMF_Mode { get; set; }
        public SRTP? SRTP { get; set; }
        public string? A_CodecFrom { get; set; }
        public string? A_CodecTo { get; set; }

    }
}