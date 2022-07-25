using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobiliva.Common
{
    public class ApiResponse<T> : IApiResponse
    {
        public T Data { get; set; }
        public Status Status { get; set; } = Status.Failed;
        public string ResultMessage { get; set; }
        public string ErrorCode { get; set; }

        
        public ApiResponse(Status status, string resultMessage)
            : this(status, resultMessage, default(T))
        {

        }

        public ApiResponse(Status status, string resultMessage, T data)
           : this(status, resultMessage, data,null)
        {

        }

        public ApiResponse(Status status, string resultMessage, T data, string errorCode)
        {
            Status = status;
            ResultMessage = resultMessage;
            Data = data;
            ErrorCode = errorCode;
        }
    }
}
