using EnergyFrontend.Models;
using System.Threading.Tasks;

namespace EnergyFrontend.Interfaces
{
    public interface IAuthService
    {
        Task<string> LoginAsync(Credentials credentials);
    }
}