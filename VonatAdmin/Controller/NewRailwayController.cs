using VonatCommon.Models;
using VonatCommon.Repository;

namespace VonatAdmin.Controller
{
    public class NewRailwayController
    {
        private VonatContext vonat = VonatContext.Instance;
        public void AddCity(Railways railways)
        {
            vonat.Railways.Add(railways);
            vonat.SaveChanges();
        }
    }
}