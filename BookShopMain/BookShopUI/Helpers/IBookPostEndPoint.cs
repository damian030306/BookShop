using BookShopUI.Models;
using System.Threading.Tasks;

namespace BookShopUI.Helpers
{
    public interface IBookPostEndPoint
    {
        Task PostBook(Book book);
    }
}