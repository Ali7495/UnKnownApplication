using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Enums
{
    public enum IdentityStatus
    {
        RegisteredSucces = 0,
        UserIsNull = 1,
        LoggedIn = 2,
        PasswordIsAndConfirmPasswordNotEqual = 3,
        AlreadyLoggedIn = 4,
        LoggedInFailed = 5,
        LockedAccount = 6,
        NotAllowed = 7,
        TwoFactorNeeded = 8,
        SignedOut = 9
    }
}
