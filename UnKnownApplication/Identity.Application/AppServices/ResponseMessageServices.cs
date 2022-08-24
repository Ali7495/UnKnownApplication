using Identity.Application.Enums;
using Identity.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.AppServices
{
    public class ResponseMessageServices : IResponseMessageServices
    {
        public async Task<string> GetResponseMessageByStatusCode(IdentityStatus statusCode)
        {
            return await Task.Run<string>(() =>
            {
                string responseMessage = string.Empty;

                switch (statusCode)
                {
                    case IdentityStatus.RegisteredSucces:
                        responseMessage = "Registered Successfuly";
                        break;
                    case IdentityStatus.UserIsNull:
                        responseMessage = "User data is null";
                        break;
                    case IdentityStatus.LoggedIn:
                        responseMessage = "Logged in successfuly";
                        break;
                    case IdentityStatus.PasswordIsAndConfirmPasswordNotEqual:
                        responseMessage = "Password and confirm password is not matched";
                        break;
                }

                return Task.FromResult(responseMessage);
            });
        }
    }
}
