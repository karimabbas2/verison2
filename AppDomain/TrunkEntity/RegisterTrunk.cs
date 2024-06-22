using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AppDomain.TrunkEntity
{
    public partial class Trunk
    {
        public string? User_Name { get; set; }
        public string? Password { get; set; }
        public string? AuthID { get; set; }

    }
}