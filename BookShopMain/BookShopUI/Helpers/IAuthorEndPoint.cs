using BookShopUI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookShopUI.Helpers
{
    public interface IAuthorEndPoint
    {
        Task<List<Author>> GetAll();
    }
}