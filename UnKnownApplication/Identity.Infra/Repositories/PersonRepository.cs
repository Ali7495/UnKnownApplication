using Dapper;
using Identity.Domain.Interfaces;
using Identity.Domain.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Infra.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private IDbConnection dbConnection;

        public PersonRepository(IConfiguration configuration)
        {
            dbConnection = new SqlConnection(configuration.GetConnectionString("IdentityConnectionString"));
        }

        public Task<Person> CreatePersonAsync(Person personInput)
        {
            return Task.Run<Person>(() =>
            {
                string query = "INSERT Person.Person(Id,Name,LastName,NationalCode,BirthDate,IsMarried,Gender,CreationDate,UpdateDate,IsDeleted) VALUES(@Id,@Name,@LastName,@NationalCode,@BirthDate,@IsMarried,@Gender,@CreationDate,@UpdateDate,@IsDeleted)";
                dbConnection.Query(query, new
                {
                    personInput.Id,
                    personInput.Name,
                    personInput.LastName,
                    personInput.NationalCode,
                    personInput.BirthDate,
                    personInput.IsMarried,
                    personInput.Gender,
                    personInput.CreationDate,
                    personInput.UpdateDate,
                    personInput.IsDeleted
                });

                return personInput;
            });
        }

        public Task<bool> DeletePersonAsync(Guid personId)
        {
            return Task.Run<bool>(() =>
            {
                string query = "UPDATE Person.Person SET IsDeleted = 1 WHERE Id = @Id";
                dbConnection.Query(query, personId);
                return true;
            });
        }

        public Task<List<Person>> GetAllPersonsAsync()
        {
            return Task.Run<List<Person>>(() =>
            {
                string query = "SELECT * FROM Person.Person WHERE IsDeleted = 0";
                List<Person> persons = dbConnection.Query<Person>(query).ToList();
                return persons;
            });
        }

        public Task<Person> GetPersonByIdAsync(Guid personId)
        {
            return Task.Run<Person>(() =>
            {
                string query = "SELECT * FROM Person.Person WHERE Id = @Id";
                return dbConnection.Query<Person>(query, personId).FirstOrDefault();
            });
        }
        public Task<Person> UpdatePersonAsync(Person personInput)
        {
            return Task.Run<Person>(() =>
            {
                string query = "UPDATE Person.Person SET Name = @Name, LastName = @LastName, NationalCode = @NationalCode, BirthDate = @BirthDate, IsMarried = @IsMarried, Gender = @Gender, CreationDate = @CreationDate, UpdateDate = @UpdateDate, IsDeleted = @IsDeleted";
                Person person = dbConnection.Query<Person>(query, new
                {
                    personInput.Id,
                    personInput.Name,
                    personInput.LastName,
                    personInput.NationalCode,
                    personInput.BirthDate,
                    personInput.IsMarried,
                    personInput.Gender,
                    personInput.CreationDate,
                    personInput.UpdateDate,
                    personInput.IsDeleted
                }).FirstOrDefault();
                return person;
            });
        }
    }
}
