using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppDomain
{
    public partial class Extenstion
    {
        public int? Call_Forward_AlwaysId {get;set;}
        public DestRoute? Call_Forward_Always { get; set; }
        public int? Call_Forward_No_AnswerId {get;set;}
        public DestRoute? Call_Forward_No_Answer { get; set; }
        public int? Call_Forworad_BusyId {get;set;}
        public DestRoute? Call_Forworad_Busy { get; set; }
        public int? CFU_Time_CondtionId {get;set;}
        public TimeGroups? CFU_Time_Condtion { get; set; }
        public int? CFN_Time_CondtionId {get;set;}
        public TimeGroups? CFN_Time_Condtion { get; set; }
        public int? CFB_Time_CondtionId {get;set;}
        public TimeGroups? CFB_Time_Condtion { get; set; }
        public int? DND_Time_CondtionId {get;set;}
        public TimeGroups? DND_Time_Condtion { get; set; }
        public string? DND_WhiteList { get; set; }
        public bool Do_Not_Disturb { get; set; }


    }
}