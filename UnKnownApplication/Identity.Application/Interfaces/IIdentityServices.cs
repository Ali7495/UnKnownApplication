using Identity.Application.DataTransferModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Interfaces
{
    public interface IIdentityServices
    {
        Task<SignInRsultDto> Register(RegisterDto registerDto, string? returnUrl);
        Task<SignInRsultDto> Login(LoginDto loginDto, string? returnUrl);
        Task<SignInRsultDto> LogOut();
    }
}
