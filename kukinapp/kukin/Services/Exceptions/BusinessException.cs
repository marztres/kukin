using kukin.Services.Exceptions.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace kukin.Services.Exceptions
{
    [ExcludeFromCodeCoverage]
    public class BusinessException : Exception, IKukinException
    {

        public BusinessException()
        {
        }

        public BusinessException(string message)
            : base(message)
        {
        }

        public BusinessException(string message, ushort errorCode)
            : base(message)
        {
            ErrorCode = errorCode;
        }

        public BusinessException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public ushort ErrorCode { get; set; }
    }
}
