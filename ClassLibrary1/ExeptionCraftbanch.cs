using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace WindowsFormsApp_FOR_LABS
{
    [Serializable]
    public class InvalidCraftbanchException : System.Exception
    {
        public InvalidCraftbanchException()
        {
        }

        public InvalidCraftbanchException(string message) : base(message)
        {
        }

        public InvalidCraftbanchException(string message, System.Exception inner) : base(message, inner)
        {
        }

        protected InvalidCraftbanchException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }

}
