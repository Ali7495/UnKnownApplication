using AutoMapper;
using Identity.Application.DataTransferModels.InputDtos;
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

        public async Task<PersonOutputDto> AddPerson(PersonInputDto personInputDto)
        {
            Person person = _mapper.Map<Person>(personInputDto);

            person.Id = Guid.NewGuid();
            person.CreationDate = DateTime.Now;
            person.IsDeleted = false;

            await _personRepository.CreatePersonAsync(person);

            return _mapper.Map<PersonOutputDto>(person);
        }

        public async Task<bool> DeletePerson(Guid id)
        {
            bool isUpdated = await _personRepository.DeletePersonAsync(id);
            return isUpdated;
        }

        public async Task<List<PersonOutputDto>> GetAllPersons()
        {
            List<Person> persons = await _personRepository.GetAllPersonsAsync();

            return _mapper.Map<List<PersonOutputDto>>(persons);
        }

        public async Task<PersonOutputDto> GetPerson(Guid id)
        {
            Person person = await _personRepository.GetPersonByIdAsync(id);
            return _mapper.Map<PersonOutputDto>(person);
        }

        public async Task<PersonOutputDto> UpdatePerson(Guid id, PersonInputDto personInputDto)
        {
            Person person = _mapper.Map<Person>(personInputDto);
            person.Id = id;
            person.UpdateDate = DateTime.Now;
            person.IsDeleted = false;

            await _personRepository.UpdatePersonAsync(person);

            return  _mapper.Map<PersonOutputDto>(person);
        }
    }
}
