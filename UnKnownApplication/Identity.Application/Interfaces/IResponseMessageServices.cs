using Identity.Application.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Interfaces
{
    public interface IResponseMessageServices
    {
        Task<string> GetResponseMessageByStatusCode(IdentityStatus statusCode);
    }
}
