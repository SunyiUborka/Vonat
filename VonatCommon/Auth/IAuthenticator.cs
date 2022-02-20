using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VonatCommon.Models.UserHandling;

namespace VonatCommon.Auth
{
    public interface IAuthenticator
    {
        public delegate void LogoutDelegate();
        public event LogoutDelegate LogoutEvent;
        public Users Authenticate(string username, string password);
        public void Logout();
    }
}
