using BookShopUI.Models;
using System.Threading.Tasks;

namespace BookShopUI.Helpers
{
    public interface IAuthorPostEndPoint
    {
        Task PostAuthor(Author author);
    }
}