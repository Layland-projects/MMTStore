using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Exceptions
{
    public class NotFoundException : Exception
    {
        static string message(Type type, object value) => $"Unable to find object of type: {type.Name} by value: {value}";
        public NotFoundException(Type type, object value) : base(message(type, value))
        {
        }

        public NotFoundException(Type type, object value, Exception innerException) : base(message(type, value), innerException)
        {
        }

        protected NotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
