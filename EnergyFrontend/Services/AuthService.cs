using EnergyFrontend.Interfaces;
using EnergyFrontend.Models;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace EnergyFrontend.Services
{
    public class AuthService: IAuthService
    {
        private readonly HttpClient httpClient;
        private readonly ILogger<string> logger;

        public AuthService(HttpClient httpClient, ILogger<string> logger)
        {
            this.httpClient = httpClient;
            this.logger = logger;
        }

        public async Task<string> LoginAsync(Credentials credentials)
        {
            var response = await httpClient.PostAsJsonAsync("login", credentials);
            var data = await response.Content.ReadFromJsonAsync<AuthResponse>();
            logger.LogInformation("Retrieved token: {0}", data.Token);

            return data.Token;
        }
    }
}
