using System.Runtime.Serialization;

namespace EventManagementProject.Services
{
    [Serializable]
    internal class EmailAlreadyExistException : Exception
    {
        public EmailAlreadyExistException()
        {
        }

        public EmailAlreadyExistException(string? message) : base(message)
        {
        }

        public EmailAlreadyExistException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected EmailAlreadyExistException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}