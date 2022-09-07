using Identity.Application.Interfaces.PersonInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Identity.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class Person : ControllerBase
    {
        private readonly IPersonService _personService;

        public Person(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet("")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllPersons()
        {
            return Ok(await _personService.GetAllPersons());
        }
    }
}
