using System;
using System.Runtime.Serialization;

namespace HomeTask01
{
    [Serializable]
    internal class FileNotFounException : Exception
    {
        public FileNotFounException()
        {
        }

        public FileNotFounException(string message) : base(message)
        {
        }

        public FileNotFounException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected FileNotFounException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}