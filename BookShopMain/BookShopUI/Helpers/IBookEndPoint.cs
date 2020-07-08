using BookShopUI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookShopUI.Helpers
{
    public interface IBookEndPoint
    {
        Task<List<Book>> GetAll();
    }
}