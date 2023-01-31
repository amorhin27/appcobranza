using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Application.Exceptions
{
    public class BadValidacionException : ApplicationException
    {
        public BadValidacionException(string message) : base(message)
        {
        }
    }
}
