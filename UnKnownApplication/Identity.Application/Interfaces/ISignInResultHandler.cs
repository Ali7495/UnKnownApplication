using Identity.Application.DataTransferModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Interfaces
{
    public interface ISignInResultHandler
    {
        Task<SignInRsultDto> HandleSignInResult(SignInResult result, string? returnUrl);
    }
}
