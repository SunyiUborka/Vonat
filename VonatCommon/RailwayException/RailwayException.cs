using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VonatCommon.RailwayException
{
    public class RailwayException : Exception
    {
        public RailwayException(string message) : base(message)
        {

        }
    }
}
