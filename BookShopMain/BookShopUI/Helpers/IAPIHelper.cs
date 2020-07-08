using BookShopUI.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace BookShopUI.Helpers
{
    public interface IAPIHelper
    {
        HttpClient ApiClient { get; }
        Task<AuthenticatedUser> Authenticate(string username, string password);
        Task GetAuthor(string token);
    }
}