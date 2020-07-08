using BookShopUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BookShopUI.Helpers
{
    public class PublishingHouseEndPoint : IPublishingHouseEndPoint
    {
        private readonly IAPIHelper aPIHelper1;
        public PublishingHouseEndPoint(IAPIHelper aPIHelper)
        {
            aPIHelper1 = aPIHelper;
            //using(HttpResponseMessage = await aPIHelper1.)
        }
        public async Task<List<PublishingHouse>> GetAll()
        {
            using (HttpResponseMessage response = await aPIHelper1.ApiClient.GetAsync("api/PublishingHouses3"))
            {
                var result = await response.Content.ReadAsAsync<List<PublishingHouse>>();
                return result;

            }
        }
    }
}
