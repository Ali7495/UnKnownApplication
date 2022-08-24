using Identity.Application.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.DataTransferModels
{
    public class SignInRsultDto
    {
        public string ReturnUrl { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public IdentityStatus Status { get; set; }
    }
}
