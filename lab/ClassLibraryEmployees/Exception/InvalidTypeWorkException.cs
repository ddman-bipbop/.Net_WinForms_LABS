using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace ClassLibraryEmployees.Exception
{

    [Serializable]
    public class InvalidTypeWorkException : System.Exception
    {
        public InvalidTypeWorkException()
        {
        }

        public InvalidTypeWorkException(string message) : base(message)
        {
        }

        public InvalidTypeWorkException(string message, System.Exception inner) : base(message, inner)
        {
        }

        protected InvalidTypeWorkException(
            SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
