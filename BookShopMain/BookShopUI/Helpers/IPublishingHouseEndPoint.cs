using BookShopUI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookShopUI.Helpers
{
    public interface IPublishingHouseEndPoint
    {
        Task<List<PublishingHouse>> GetAll();
    }
}