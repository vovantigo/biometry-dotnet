using System.Collections.Generic;
using System.Threading.Tasks;
using PipServices.Telemetry.Models;

namespace PipServices.Telemetry.Logic
{
    public interface IPeopleController
    {
        Task<List<Person>> GetAllAsync(string correlationId);
        Task<Person> GetByIdAsync(string correlationId, string id);
        Task<Person> CreateAsync(string correlationId, Person item);
        Task<Person> UpdateAsync(string correlationId, Person item);
    }
}
