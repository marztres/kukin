using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kukin.Exceptions
{
    public class ErrorResponse
    {
        public ushort ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public string DetailedDescription { get; set; }
    }
}
