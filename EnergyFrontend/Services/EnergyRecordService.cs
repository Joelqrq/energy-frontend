using EnergyFrontend.Models;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace EnergyFrontend.Services
{
    public class EnergyRecordService
    {
        private readonly HttpClient httpClient;
        private readonly ILogger logger;

        public EnergyRecordService(HttpClient httpClient, ILogger<IEnumerable<EnergyRecord>> logger)
        {
            this.httpClient = httpClient;
            this.logger = logger;
        }

        public async Task<IEnumerable<EnergyRecord>> GetEnergyRecordsAsync()
        {
            var response = await httpClient.GetAsync("/api/energyrecords");
            var data = await response.Content.ReadAsStringAsync();
            logger.LogInformation("Retrieved energy records: ", data);
            return null;
        }
    }
}
