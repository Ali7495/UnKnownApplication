using Dapper;
using Identity.Domain.Interfaces;
using Identity.Domain.Interfaces.PersonInterfaces;
using Identity.Domain.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Infra.Repositories.PersonRepository
{
    public class PersonRepository : IPersonRepository
    {
        private IDbConnection dbConnection;

        public PersonRepository(IConfiguration configuration)
        {
            dbConnection = new SqlConnection(configuration.GetConnectionString("IdentityConnectionString"));
        }

        public Task CreatePersonAsync(Person personInput)
        {
            return Task.Run(() =>
            {
                string query = "INSERT Person.Person(Id,Name,LastName,NationalCode,BirthDate,IsMarried,Gender,CreationDate,UpdateDate,IsDeleted) VALUES(@Id,@Name,@LastName,@NationalCode,@BirthDate,@IsMarried,@Gender,@CreationDate,@UpdateDate,@IsDeleted)";
                dbConnection.Query(query, personInput);

            });
        }

        public Task<bool> DeletePersonAsync(Guid personId)
        {
            return Task.Run<bool>(() =>
            {
                string query = "UPDATE Person.Person SET IsDeleted = 1 WHERE Id = @PersonId";
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@PersonId",personId,DbType.Guid);
                dbConnection.Query(query, dynamicParameters);
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
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@PersonId",personId,DbType.Guid);
                string query = "SELECT * FROM Person.Person WHERE Id = @PersonId";
                return dbConnection.Query<Person>(query, dynamicParameters).FirstOrDefault();
            });
        }

        public Task<Person> GetPersonByNationalCodeAsync(string nationalCode)
        {
            return Task.Run<Person>(() =>
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@NationalCode", nationalCode, DbType.String);
                string query = "SELECT * FROM Person.Person WHERE NationalCode = @NationalCode";
                return dbConnection.Query<Person>(query, dynamicParameters).FirstOrDefault();
            });
        }

        public Task<bool> IsPersonExistedByNationalCodeAsync(string nationalCode)
        {
            return Task.Run<bool>(() =>
            {
                DynamicParameters dynamicParameters = new DynamicParameters();

                dynamicParameters.Add("@NationalCode", nationalCode, DbType.String);

                string query = "SELECT * FROM Person.Person WHERE NationalCode = @NationalCode";

                Person? person = new Person();
                person = dbConnection.Query<Person>(query, dynamicParameters).FirstOrDefault();

                if (person == null)
                {
                    return false;
                }

                return true;
            });
        }

        public Task UpdatePersonAsync(Person personInput)
        {
            return Task.Run(() =>
            {
                string query = "UPDATE Person.Person SET Name = @Name, LastName = @LastName, NationalCode = @NationalCode, BirthDate = @BirthDate, IsMarried = @IsMarried, Gender = @Gender, CreationDate = @CreationDate, UpdateDate = @UpdateDate, IsDeleted = @IsDeleted WHERE Id = @PersonId";
                DynamicParameters dynamicParameters = new DynamicParameters();

                dynamicParameters.Add("@PersonId",personInput.Id,DbType.Guid);
                dynamicParameters.Add("@Name", personInput.Name,DbType.String);
                dynamicParameters.Add("@LastName", personInput.LastName,DbType.String);
                dynamicParameters.Add("@NationalCode", personInput.NationalCode,DbType.String);
                dynamicParameters.Add("@BirthDate", personInput.BirthDate, DbType.DateTime2);
                dynamicParameters.Add("@IsMarried", personInput.IsMarried, DbType.Boolean);
                dynamicParameters.Add("@Gender", personInput.Gender, DbType.String);
                dynamicParameters.Add("@CreationDate", personInput.CreationDate, DbType.DateTime2);
                dynamicParameters.Add("@UpdateDate", personInput.UpdateDate, DbType.DateTime2);
                dynamicParameters.Add("@IsDeleted", personInput.IsDeleted, DbType.Boolean);

                dbConnection.Execute(query,dynamicParameters);

            });
        }
    }
}
