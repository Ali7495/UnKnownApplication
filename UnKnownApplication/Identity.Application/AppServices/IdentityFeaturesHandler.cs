using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.AppServices
{
    internal class IdentityFeaturesHandler
    {
        internal static void ReturnUrlValidator(string? returnUrl)
        {
            if (returnUrl != null && !returnUrl.Contains("localhost"))
            {
                throw new UnauthorizedAccessException("Final address is blocked");
            }
        }
    }
}
