using Identity.Application.DataTransferModels.InputDtos;
using Identity.Application.Interfaces.PersonInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Identity.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet("")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllPersons()
        {
            return Ok(await _personService.GetAllPersons());
        }

        [HttpPost("")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreatePerson([FromBody] PersonInputDto personInput)
        {
            return Ok(await _personService.AddPerson(personInput));
        }

        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetPerson(Guid id)
        {
            return Ok(await _personService.GetPerson(id));
        }

        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreatePerson(Guid id, [FromBody] PersonInputDto personInput)
        {
            return Ok(await _personService.UpdatePerson(id,personInput));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> RemovePerson(Guid id)
        {
            return Ok(await _personService.DeletePerson(id));
        }
    }
}
