using AutoMapper;
using Identity.Application.DataTransferModels.OutPutDtos;
using Identity.Application.Interfaces.PersonInterfaces;
using Identity.Domain.Interfaces;
using Identity.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.AppServices.PersonServices
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;

        public PersonService(IPersonRepository personRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }

        public async Task<List<PersonOutputDto>> GetAllPersons()
        {
            List<Person> persons = await _personRepository.GetAllPersonsAsync();

            return _mapper.Map<List<PersonOutputDto>>(persons);
        }
    }
}
