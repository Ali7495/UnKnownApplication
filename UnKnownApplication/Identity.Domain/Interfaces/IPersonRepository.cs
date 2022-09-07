using Identity.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Domain.Interfaces
{
    public interface IPersonRepository
    {
        Task CreatePersonAsync(Person personInput);
        Task UpdatePersonAsync(Person personInput);
        Task<List<Person>> GetAllPersonsAsync();
        Task<Person> GetPersonByIdAsync(Guid personId);
        Task<bool> DeletePersonAsync(Guid personId);
    }
}
