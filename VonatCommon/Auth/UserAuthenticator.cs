using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VonatCommon.Models.UserHandling;
using VonatCommon.Repository;
using VonatCommon.RailwayException;

namespace VonatCommon.Auth
{
    public sealed class UserAuthenticator : IAuthenticator
    {
        public event IAuthenticator.LogoutDelegate LogoutEvent;

        private static UserContext userContext = UserContext.Instance;
        public Users? LoggedInUser { get; set; }

        private static UserAuthenticator? userAuthenticator;

        public static UserAuthenticator Instance
        {
            get
            {
                if (userAuthenticator == null)
                {
                    userAuthenticator = new UserAuthenticator();
                }
                return userAuthenticator;
            }
        }

        private UserAuthenticator() 
        {
        }

        public Users Authenticate(string username, string password)
        {
            Users? user = userContext.Users.FirstOrDefault(user => user.username == username);
            if (user == null)
            {
                throw new RailwayException.RailwayException("Hibás felhasználónév");
            }
            
            if (!BCrypt.Net.BCrypt.Verify(password, user.password))
            {
                throw new RailwayException.RailwayException("Hibás jelszó");
            }
            if (user.role != Role.ADMIN)
            {
                throw new RailwayException.RailwayException("Nincs jogosultságod!");
            }
            LoggedInUser = user;
            return user;
        }

        public void Logout()
        {
            LoggedInUser = null;
            LogoutEvent?.Invoke();
        }
    }
}
