using kukin.Services.Exceptions.Interfaces;
using System;
using System.Diagnostics.CodeAnalysis;

namespace kukin.Services.Exceptions
{
    [ExcludeFromCodeCoverage]
    public class NotFoundException : Exception, IKukinException
    {
        public NotFoundException()
        {
        }

        public NotFoundException(string message)
            : base(message)
        {
        }

        public NotFoundException(string message, ushort errorCode)
            : base(message)
        {
            ErrorCode = errorCode;
        }

        public NotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public ushort ErrorCode { get; set; }
    }
}
