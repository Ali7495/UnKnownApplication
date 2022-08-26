using Identity.Application.DataTransferModels;
using Identity.Application.Enums;
using Identity.Application.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.AppServices
{
    public class SignInResultHandler : ISignInResultHandler
    {
        public async Task<SignInRsultDto> HandleSignInResult(SignInResult result, string? returnUrl, string? token)
        {

            return await Task.Run(() =>
            {
                SignInRsultDto signInRsultDto;

                if (result.Succeeded)
                {
                    signInRsultDto = new()
                    {
                        Message = "Successfuly logged in",
                        ReturnUrl = returnUrl,
                        Status = IdentityStatus.LoggedIn,
                        Token = token
                    };

                    return signInRsultDto;
                }

                if (!result.Succeeded)
                {
                    signInRsultDto = new()
                    {
                        Message = "Problem occured during logging in",
                        Status = IdentityStatus.LoggedInFailed
                    };

                    return signInRsultDto;
                }

                if (result.IsLockedOut)
                {
                    signInRsultDto = new()
                    {
                        Message = "Your account has been locked",
                        Status = IdentityStatus.LockedAccount
                    };

                    return signInRsultDto;
                }

                if (result.IsNotAllowed)
                {
                    signInRsultDto = new()
                    {
                        Message = "Your not allowed to sign in",
                        Status = IdentityStatus.NotAllowed
                    };

                    return signInRsultDto;
                }

                if (result.RequiresTwoFactor)
                {
                    signInRsultDto = new()
                    {
                        Message = "Singning in requered two factor authentication",
                        Status = IdentityStatus.TwoFactorNeeded
                    };

                    return signInRsultDto;
                }

                return new SignInRsultDto();
            });
        }
    }
}
