using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AppCore.CustomValidation;

namespace AppCore.Dtos.SipSetting
{
    public class SipSettingDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "UDP Port Is Requierd")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Port must be number")]
        public int? UDP_PORT { get; set; }
        [Required(ErrorMessage = "TCP Port Is Requierd")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Port must be number")]
        public int? TCP_PORT { get; set; }
        [Required(ErrorMessage = "TLS Port Is Requierd")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Port must be number")]
        public int? TLS_PORT { get; set; }

        [Required(ErrorMessage = "RTP Range From Is Requierd")]
        [RegularExpression(@"^\d+$", ErrorMessage = "RTP Range From must be number")]
        public int? RTP_Range_From { get; set; }
        [Display(Name = "RTP Range To")]
        [Required(ErrorMessage = "RTP Range To Is Requierd")]
        [RegularExpression(@"^\d+$", ErrorMessage = "RTP Range To must be number")]
        [SRTPRange(nameof(RTP_Range_From))]
        public int? RTP_Range_TO { get; set; }
        public string? STUN_Address { get; set; }

    }
}