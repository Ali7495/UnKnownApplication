using Identity.Application.DataTransferModels;
using Identity.Application.Enums;
using Identity.Application.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.AppServices
{
    public class IdentityServices : IIdentityServices
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<IdentityServices> _logger;
        private readonly IResponseMessageServices _responseMessageServices;
        private readonly ISignInResultHandler _signInResultHandler;

        public IdentityServices(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, ILogger<IdentityServices> logger, IResponseMessageServices responseMessageServices, ISignInResultHandler signInResultHandler)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _responseMessageServices = responseMessageServices;
            _signInResultHandler = signInResultHandler;
        }

        public async Task<SignInRsultDto> Login(LoginDto viewMoel, string? returnUrl)
        {
            IdentityUser user = await _userManager.FindByNameAsync(viewMoel.Username);
            if (user == null)
            {
                _logger.LogError(_responseMessageServices.GetResponseMessageByStatusCode(IdentityStatus.UserIsNull).Result);
                return new SignInRsultDto() { Message = "This user is not Exists", Status = IdentityStatus.UserIsNull };
            }

            //Create Key to validate client

            string tokenString = await SecurityTokenFactory.SercurityTokenCreator(viewMoel);

            SignInResult result = await _signInManager.PasswordSignInAsync(user, viewMoel.Password, viewMoel.RememberMe, true);

            return await _signInResultHandler.HandleSignInResult(result, returnUrl, tokenString);
        }

        public async Task<SignInRsultDto> LogOut()
        {
            await _signInManager.SignOutAsync();
            return new SignInRsultDto() { Message = "Signed out", Status = IdentityStatus.SignedOut };
        }

        public async Task<SignInRsultDto> Register(RegisterDto viewMoel, string? returnUrl)
        {
            if (!viewMoel.Password.Equals(viewMoel.ConfirmPassword))
            {
                _logger.LogError(_responseMessageServices.GetResponseMessageByStatusCode(IdentityStatus.PasswordIsAndConfirmPasswordNotEqual).Result);
                return new SignInRsultDto() { Message = "Password and confirm password are not match", Status = IdentityStatus.PasswordIsAndConfirmPasswordNotEqual };
            }

            IdentityUser user = new IdentityUser()
            {
                UserName = viewMoel.UserName,
                Email = viewMoel.EmailAddress,
                EmailConfirmed = false,
                TwoFactorEnabled = viewMoel.TwoFactor,
                PhoneNumber = viewMoel.PhoneNumber
            };

            await _userManager.CreateAsync(user, viewMoel.Password);
            _logger.LogInformation(_responseMessageServices.GetResponseMessageByStatusCode(IdentityStatus.RegisteredSucces).Result);

            return new SignInRsultDto() { Message = "Registered Successfuly", ReturnUrl = returnUrl, Status = IdentityStatus.RegisteredSucces };
        }
    }
}
