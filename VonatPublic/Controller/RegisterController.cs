using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VonatCommon.Repository;
using VonatCommon.Models.UserHandling;
using VonatCommon.RailwayException;

namespace VonatPublic.Controller
{
    class RegisterController
    {
        private UserContext userContext = UserContext.Instance;

        public void HandleRegister(string username, string password1, string password2, string email, string name)
        {
            if (password1 != password2)
            {
                throw new RailwayException("A megadott jelszavak nem egyeznek");
            }
            if (userContext.Users.FirstOrDefault(user => user.email == email || user.username == username) != null)
            {
                throw new RailwayException("Ilyen felhasználónévvel vagy email címmel már regisztráltak");
            }
            userContext.Users.Add(new Users(
                email,
                username,
                BCrypt.Net.BCrypt.HashPassword(password1, BCrypt.Net.BCrypt.GenerateSalt()),
                Role.USER));

            userContext.SaveChanges();
        }
    }
}
