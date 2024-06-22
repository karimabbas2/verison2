using System.ComponentModel.DataAnnotations;


namespace AppCore.Dtos.GlobalSetting
{
    public class GlobalSettingDto
    {
        public int Id { get; set; }
        public List<string>? CodecFrom { get; set; }
        [Required(ErrorMessage = "Must Select at least One Codec")]
        [MinLength(1, ErrorMessage = "Must Select at least One Codec")]
        public List<string>? CodecTo { get; set; }
        public int? Ext_Privilege { get; set; }
        public int? Ext_DTMF { get; set; }
        public int? JitterBuffer { get; set; }
        [RegularExpression(@"^\d+$", ErrorMessage = "Extension Ring Time must be number")]
        public int? Ext_Ring_Time { get; set; }
        [Required(ErrorMessage = "Extension Concurrent Registrations Is Requierd")]
        [Range(1, 5, ErrorMessage = "The value must be between 1 and 5.")]
        public int? Ext_CC_Registrations { get; set; }
        public bool Enable_VM { get; set; }
        public bool Sync_Contact { get; set; }
        public bool Enable_NAT { get; set; }
    }
}