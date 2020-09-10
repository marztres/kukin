using kukin.Services.Exceptions.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace kukin.Services.Exceptions
{
    [ExcludeFromCodeCoverage]
    public class ForbiddenException : Exception, IKukinException
    {
        public ForbiddenException()
        {
        }

        public ForbiddenException(string message)
            : base(message)
        {
        }

        public ForbiddenException(string message, ushort errorCode)
           : base(message)
        {
            ErrorCode = errorCode;
        }

        public ForbiddenException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public ushort ErrorCode { get; set; }
    }
}
