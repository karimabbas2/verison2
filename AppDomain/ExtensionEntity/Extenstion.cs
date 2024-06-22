using AppDomain.Concrets;
using AppDomain.Enums;

namespace AppDomain
{
    public partial class Extenstion : BaseEntity
    {
        public bool Enable_Ext { get; set; }
        public int Ext_Number { get; set; }
        public int? CallerId_Number { get; set; }
        public int? Call_PrivilegeId { get; set; }
        public Privilege? Call_Privilege { get; set; }
        public string? SIP_Password { get; set; }
        public string? AuthId { get; set; }
        public bool Enable_VM { get; set; }
        public string? VM_Password { get; set; }
        public bool Enable_KA { get; set; }
        public int? KA_Freq { get; set; }
        public bool Sync_Contact { get; set; }
        public string? F_Name { get; set; }
        public string? L_Name { get; set; }
        public string? Mobile { get; set; }
        public string? Email { get; set; }
        public string? Ext_User_pswd { get; set; }
        public string? Ext_CC_Registrations { get; set; }
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }
        public string? Job_Title { get; set; }
        public int? Extension_Ring_Time { get; set; }
        public Language? Language { get; set; }

    }
}