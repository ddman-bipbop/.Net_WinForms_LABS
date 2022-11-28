using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace ClassLibraryEmployees.Exception
{

    [Serializable]
    public class InvalidWorkException : System.Exception
    {
        public InvalidWorkException()
        {
        }

        public InvalidWorkException(string message) : base(message)
        {
        }

        public InvalidWorkException(string message, System.Exception inner) : base(message, inner)
        {
        }

        protected InvalidWorkException(
            SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
