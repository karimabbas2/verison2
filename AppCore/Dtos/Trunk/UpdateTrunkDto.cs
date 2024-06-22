using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AppCore.CustomValidation;

namespace AppCore.Dtos.Trunk
{
    public class UpdateTrunkDto
    {
        public int Id { get; set; }
        public bool Enable_Trunk { get; set; }
        public string? Type { get; set; }
        [Required(ErrorMessage = "Name is requierd")]
        public string? Name { get; set; }

        public string? Out_Proxy_Server { get; set; }
        [RegularExpression(@"^\d+$", ErrorMessage = "Out Proxy Port must be number")]
        public int? Out_Proxy_Port { get; set; }
        public string? Transport { get; set; }
        public bool Enable_KA { get; set; }
        [IsFrequecnyRequierd(nameof(Enable_KA), true, ErrorMessage = "Keep-alive Frequency is Requierd")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Keep-alive Frequency must be number")]
        public int? KA_Freq { get; set; }

        [DisplayName("User Name")]
        [IsRegisterTrunk(nameof(Type), "Register_Trunk", ErrorMessage = "User Name is Requierd")]
        public string? User_Name { get; set; }
        [DisplayName("Password")]
        [IsRegisterTrunk(nameof(Type), "Register_Trunk", ErrorMessage = "Password is Requierd")]
        public string? Password { get; set; }
        public string? AuthID { get; set; }
        public bool Need_Registration { get; set; }

        [BoolServserAddress(nameof(Need_Registration), true, ErrorMessage = "Port Is Requierd")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Port must be number")]
        public int? Port { get; set; }

        [DisplayName("Server Address")]
        [BoolServserAddress(nameof(Need_Registration), true, ErrorMessage = "Server Address Is Requierd")]
        public string? Server_Address { get; set; }

        //Advanced
        public bool Enable_NAT { get; set; }
        public string? From_User { get; set; }
        public string? From_Domain { get; set; }
        public int? DTMF_ModeId { get; set; }
        public int? SRTP { get; set; }
        public List<string>? A_CodecFrom { get; set; }
        [Required(ErrorMessage = "Must Select at least One Codec")]
        public List<string>? A_CodecTo { get; set; }

    }
}