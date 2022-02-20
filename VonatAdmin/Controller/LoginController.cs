using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VonatCommon.Models.UserHandling;
using VonatCommon.Auth;


namespace VonatAdmin.Controller
{
    public class LoginController
    {
        private IAuthenticator authenticator = UserAuthenticator.Instance;
        public Users HandleLoginAttempt(string username, string password)
        {
            return authenticator.Authenticate(username, password);
        }
    }
}
