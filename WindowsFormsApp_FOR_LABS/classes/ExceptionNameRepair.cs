using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace WindowsFormsApp_FOR_LABS
{
    [Serializable]
    public class InvalidNameRepairException : System.Exception
    {
        public InvalidNameRepairException()
        {
        }

        public InvalidNameRepairException(string message) : base(message)
        {
        }

        public InvalidNameRepairException(string message, System.Exception inner) : base(message, inner)
        {
        }

        protected InvalidNameRepairException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}
