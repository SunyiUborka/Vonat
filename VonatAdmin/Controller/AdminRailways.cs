using System.Collections.Generic;
using System.Linq;
using VonatCommon.Models;
using VonatCommon.Repository;

namespace VonatAdmin.Controller
{
    public class AdminRailways
    {
        VonatContext vonat = VonatContext.Instance;
        public List<Railways> GetRailways(Railways railways)
        {
            return vonat.Railways.ToList();
        }
    }
}