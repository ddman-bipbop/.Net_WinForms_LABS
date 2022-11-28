using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;


namespace ClassLibraryEmployees.Exception
{

    [Serializable]
    public class InvalidEmployeesException : System.Exception
    {
        public InvalidEmployeesException()
        {
        }

        public InvalidEmployeesException(string message) : base(message)
        {
        }

        public InvalidEmployeesException(string message, System.Exception inner) : base(message, inner)
        {
        }

        protected InvalidEmployeesException(
            SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
