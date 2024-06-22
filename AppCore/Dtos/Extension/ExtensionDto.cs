using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AppCore.CustomValidation;
using AppDomain;
using AppDomain.Enums;

namespace AppCore.Dtos.Extension
{
    public class ExtensionDto
    {
        //Basic
        public bool Enable_Ext { get; set; }
        [Required(ErrorMessage = "Extesntion Number is Requierd")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Extension must be number")]
        [ExtensionNumber(ErrorMessage = "This Extension is Already exist")]
        public int? Ext_Number { get; set; }
        [RegularExpression(@"^\d+$", ErrorMessage = "CallerId must be number")]
        public int? CallerId_Number { get; set; }
        [Required(ErrorMessage = "Call_Privilege is Requierd")]
        public int Call_PrivilegeId { get; set; }
        [Required(ErrorMessage = "SIP Password is Requierd")]
        [MinLength(8, ErrorMessage = "SIP Password must be at least 8 Digits")]
        [ValidSIPPassword]
        public string? SIP_Password { get; set; }
        public string? AuthId { get; set; }
        public bool Enable_VM { get; set; }
        public string? VM_Password { get; set; }
        public bool Enable_KA { get; set; }
        [IsFrequecnyRequierd(nameof(Enable_KA), true, ErrorMessage = "Keep-alive Frequency is Requierd")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Keep-alive Frequency must be number")]
        public int? KA_Freq { get; set; }
        public bool Sync_Contact { get; set; }
        public string? F_Name { get; set; }
        public string? L_Name { get; set; }
        public string? Mobile { get; set; }
        public string? Email { get; set; }
        [Required(ErrorMessage = "Extension User Password is Requierd")]
        [MinLength(6, ErrorMessage = "Extension User Password must be at least 6 Digits")]
        public string? Ext_User_pswd { get; set; }
        [Required(ErrorMessage = "Ext_CC_Registrations is Requierd")]
        [Range(1, 5, ErrorMessage = "The value must be between 1 and 5.")]

        public string? Ext_CC_Registrations { get; set; }
        public int DepartmentId { get; set; }
        public int? LanguageId { get; set; }

        public string? Job_Title { get; set; }
        [RegularExpression(@"^\d+$", ErrorMessage = "Extension Ring Time must be number")]
        public int? Extension_Ring_Time { get; set; }
        public int? Language { get; set; }

        // //Media
        public bool Enable_NAT { get; set; }
        public bool Enable_DM { get; set; }
        public int? DTMF_ModeId { get; set; }
        public int? JitterBufferId { get; set; }
        public List<string>? A_CodecFrom { get; set; }
        [Required(ErrorMessage = "Must Select at least One Codec")]
        public List<string>? A_CodecTo { get; set; }
        public int? SRTP { get; set; }
    }
}