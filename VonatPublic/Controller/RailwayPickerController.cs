using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VonatCommon.Models.UserHandling;
using VonatCommon.Auth;
using VonatCommon.Repository;
using VonatCommon.Models;

namespace VonatPublic.Controller
{
    public class RailwayPickerController
    {
        private IAuthenticator authenticator = UserAuthenticator.Instance;
        private VonatContext vonat = VonatContext.Instance;

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

        public List<Cities> GetCities()
        {
            var list = vonat.Cities.ToList();
            return list;
        }
        public void AddCity(Cities city)
        {
            vonat.Cities.Add(city);
            vonat.SaveChanges();
        }
    }
}
