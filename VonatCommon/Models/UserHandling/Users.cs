using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VonatCommon.Models.UserHandling
{
    public class Users : AbstractBase
    {
        public string email { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public Role role { get; set; }

        public Users() { }

        public Users(string email, string username, string password, Role role)
        {
            this.email = email;
            this.username = username;
            this.password = password;
            this.role = role;
        }
    }

    
}
