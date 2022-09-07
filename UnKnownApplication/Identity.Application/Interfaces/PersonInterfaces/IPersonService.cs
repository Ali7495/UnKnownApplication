using Identity.Application.DataTransferModels.InputDtos;
using Identity.Application.DataTransferModels.OutPutDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Interfaces.PersonInterfaces
{
    public interface IPersonService
    {
        Task<List<PersonOutputDto>> GetAllPersons();
        Task<PersonOutputDto> GetPerson(Guid id);
        Task<PersonOutputDto> UpdatePerson(Guid id, PersonInputDto personInputDto);
        Task<PersonOutputDto> AddPerson(PersonInputDto personInputDto);
        Task<bool> DeletePerson(Guid id);
    }
}
