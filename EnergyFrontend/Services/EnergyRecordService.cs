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
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6InRlc3QxIiwibmFtZWlkIjoiN2VlOGIyZmUtZDJmNC00ZTZkLWI5MjUtNTQyNjQ0ZDA3ZTRhIiwibmJmIjoxNjM2NDQxNTYwLCJleHAiOjE2MzY0NDUxNjAsImlhdCI6MTYzNjQ0MTU2MCwiaXNzIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6NTAwMS8iLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjQyMDAvIn0.BZsr1Wd39nq6z0e_n0Wa6e9l_YNVNJIJ28Xa98hjxDM");
            var response = await httpClient.GetStringAsync("energyrecords");
            var data = JsonSerializer.Deserialize<IEnumerable<EnergyRecord>>(response);
            logger.LogInformation("Retrieved energy records: {0}", data);
            return data;
        }
    }
}
