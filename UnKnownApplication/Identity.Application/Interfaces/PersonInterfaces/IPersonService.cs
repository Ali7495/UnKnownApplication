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
    }
}
