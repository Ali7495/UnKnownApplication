using Identity.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Domain.Interfaces.PersonInterfaces
{
    public interface IPersonRepository
    {
        Task CreatePersonAsync(Person personInput);
        Task UpdatePersonAsync(Person personInput);
        Task<List<Person>> GetAllPersonsAsync();
        Task<Person> GetPersonByIdAsync(Guid personId);
        Task<Person> GetPersonByNationalCodeAsync(string nationalCode);
        Task<bool> DeletePersonAsync(Guid personId);
        Task<bool> IsPersonExistedByNationalCodeAsync(string nationalCode);
    }
}
