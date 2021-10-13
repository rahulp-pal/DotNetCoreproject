using System;

namespace ProjectName.Domain.Exceptions
{
    public class DomainException : Exception
    {
        internal DomainException(string businessMessage)
            : base(businessMessage)
        {
        }

        internal DomainException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
