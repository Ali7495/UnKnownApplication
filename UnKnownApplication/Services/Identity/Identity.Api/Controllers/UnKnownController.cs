using Identity.Application.DataTransferModels;
using Identity.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Identity.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UnKnownController : ControllerBase
    {
        private readonly IIdentityServices _identityServices;

        public UnKnownController(IIdentityServices identityServices)
        {
            _identityServices = identityServices;
        }



        [HttpPost("RegisterUser")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> RegisterUser(RegisterDto registerViewModel, string? returnUrl)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(await _identityServices.Register(registerViewModel, returnUrl));
        }

        [HttpPost("LoginUser")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> LoginUser(LoginDto loginViewModel, string? returnUrl)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (User == null && User.Identity.IsAuthenticated)
            {
                return Ok();
            }

            return Ok(await _identityServices.Login(loginViewModel, returnUrl));
        }

        [HttpPost("LogOutUser")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> LoginUser()
        {
            return Ok(new { Message = await _identityServices.LogOut(), Url = "returned url" });
        }
    }
}
