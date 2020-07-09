using BookShopUI.Models;
using System.Threading.Tasks;

namespace BookShopUI.Helpers
{
    public interface IPublishingHousePostEndPoint
    {
        Task PostAuthor(PublishingHouse publishingHouse);
    }
}