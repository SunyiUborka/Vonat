using System.Collections.Generic;
using System.Linq;
using VonatCommon.Models;
using VonatCommon.Repository;
using VonatCommon.Models.UserHandling;
using VonatCommon.Auth;

namespace VonatAdmin.Controller
{
    public class RailwayController
    {
        VonatContext vonat = VonatContext.Instance;
        private IAuthenticator authenticator = UserAuthenticator.Instance;

        public void SubscibeToLogout(IAuthenticator.LogoutDelegate logoutDelegate)
        {
            authenticator.LogoutEvent += logoutDelegate;
        }

        public void UnsubscribeFromLogout(IAuthenticator.LogoutDelegate logoutDelegate)
        {
            authenticator.LogoutEvent -= logoutDelegate;
        }

        public void Logout()
        {
            authenticator.Logout();
        }
    }
}