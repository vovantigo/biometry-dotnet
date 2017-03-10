using System.Collections.Generic;
using System.Threading.Tasks;
using Biometry.Common.Models;

namespace Biometry.Logic.Logic
{
    public interface IBiometryController
    {
        Task<List<PersonBiometry>> GetAllAsync(string correlationId);
        Task<PersonBiometry> GetByIdAsync(string correlationId, string id);
        Task<PersonBiometry> CreateAsync(string correlationId, PersonBiometry item);
    }
}
