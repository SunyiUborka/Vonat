using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VonatCommon.Models
{
    class Railways : AbstractBase
    {
        public string from { get; set; }
        public string to { get; set; }
        public int distance { get; set; }
    }
}
