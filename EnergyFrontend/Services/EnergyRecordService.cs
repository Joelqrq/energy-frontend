using EnergyFrontend.Interfaces;
using EnergyFrontend.Models;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace EnergyFrontend.Services
{
    public class EnergyRecordService: IEnergyRecordService
    {
        private readonly HttpClient httpClient;
        private readonly ILogger logger;
        private readonly IAuthService authService;

        public EnergyRecordService(HttpClient httpClient, ILogger<IEnumerable<EnergyRecord>> logger, IAuthService authService)
        {
            this.httpClient = httpClient;
            this.logger = logger;
            this.authService = authService;
            this.logger.LogInformation("Auth Service in Energy {0}", this.authService);
        }

        public async Task<IEnumerable<EnergyRecord>> GetEnergyRecordsAsync(string token)
        {
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var data = await httpClient.GetFromJsonAsync<IEnumerable<EnergyRecord>>("energyrecords");
            logger.LogInformation("Retrieved energy records: {0}", data);

            return data;
        }
    }
}
