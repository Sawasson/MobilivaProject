using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobiliva.Common
{
    interface IApiResponse
    {
        Status Status { get; set; } 
        string ResultMessage { get; set; }
        string ErrorCode { get; set; }
    }
}
