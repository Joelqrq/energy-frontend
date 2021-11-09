using EnergyFrontend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EnergyFrontend.Interfaces
{
    public interface IEnergyRecordService
    {
        Task<IEnumerable<EnergyRecord>> GetEnergyRecordsAsync(string token);
    }
}