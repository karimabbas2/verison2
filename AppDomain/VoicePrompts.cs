using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppDomain.Concrets;

namespace AppDomain
{
    public class VoicePrompts : BaseEntity
    {
        public string? File_Name { get; set; }
        public string? File_Format { get; set; }
        public int? ExtenstionId { get; set; }
        public Extenstion? Extenstion { get; set; }
    }
}