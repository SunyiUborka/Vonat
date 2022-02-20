using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VonatCommon.Models.UserHandling
{
    class Users : AbstractBase
    {
        public string email { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public Role role { get; set; }
    }
}
