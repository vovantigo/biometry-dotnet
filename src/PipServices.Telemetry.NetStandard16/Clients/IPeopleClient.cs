using System.Threading.Tasks;
using PipServices.Telemetry.Models;

namespace PipServices.Telemetry.Clients
{
    public interface IPeopleClient
    {
        Task<Person[]> GetAllAsync(string correlationId);
        Task<Person> GetByIdAsync(string correlationId, string id);
        Task<Person> CreateAsync(string correlationId, Person item);
        Task<Person> UpdateAsync(string correlationId, Person item);
    }
}
