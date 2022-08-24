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
        public async Task<SignInRsultDto> HandleSignInResult(SignInResult result, string? returnUrl)
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
                        Status = IdentityStatus.LoggedIn
                    };
                }

                if (!result.Succeeded)
                {
                    signInRsultDto = new()
                    {
                        Message = "Problem occured during logging in",
                        Status = IdentityStatus.LoggedInFailed
                    };
                }

                if (result.IsLockedOut)
                {
                    signInRsultDto = new()
                    {
                        Message = "Your account has been locked",
                        Status = IdentityStatus.LockedAccount
                    };
                }

                if (result.IsNotAllowed)
                {
                    signInRsultDto = new()
                    {
                        Message = "Your not allowed to sign in",
                        Status = IdentityStatus.NotAllowed
                    };
                }

                if (result.RequiresTwoFactor)
                {
                    signInRsultDto = new()
                    {
                        Message = "Singning in requered two factor authentication",
                        Status = IdentityStatus.TwoFactorNeeded
                    };
                }

                return new SignInRsultDto();
            });
        }
    }
}
