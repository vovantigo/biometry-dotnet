using System.Threading.Tasks;
using Biometry.Common.Models;

namespace Biometry.Client.Clients
{
    public interface IBiometryClient
    {
        Task<PersonBiometry[]> GetAllAsync(string correlationId);
        Task<PersonBiometry> GetByIdAsync(string correlationId, string id);
        Task<PersonBiometry> CreateAsync(string correlationId, PersonBiometry item);
    }
}
