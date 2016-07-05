using System;
using System.Runtime.Serialization;

namespace Moola.Bsa.Logic.Exceptions
{
    [Serializable]
    public class BsaInputParameterException:Exception
    {
        public BsaInputParameterException()
        {
        }

        public BsaInputParameterException(string message) : base(message)
        {
        }

        public BsaInputParameterException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected BsaInputParameterException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

    }
}
