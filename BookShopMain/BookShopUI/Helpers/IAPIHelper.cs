using BookShopUI.Models;
using System.Threading.Tasks;

namespace BookShopUI.Helpers
{
    public interface IAPIHelper
    {
        Task<AuthenticatedUser> Authenticate(string username, string password);
    }
}