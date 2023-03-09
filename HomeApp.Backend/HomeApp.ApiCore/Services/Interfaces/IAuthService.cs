using HomeApp.ApiCore.Entities.Domain;
using System.Threading.Tasks;

namespace HomeApp.ApiCore.Services.Interfaces
{
    public interface IAuthService
    {
        Task<string> Register(User User, string password);
        Task<string> Login(string UserName, string password);
        Task<bool> UserExists(string UserName, string UserEmail);
    }
}
