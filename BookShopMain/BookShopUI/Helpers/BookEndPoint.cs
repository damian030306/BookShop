using BookShopUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BookShopUI.Helpers
{
    public class BookEndPoint : IBookEndPoint
    {
        private readonly IAPIHelper aPIHelper1;
        public BookEndPoint(IAPIHelper aPIHelper)
        {
            aPIHelper1 = aPIHelper;
            //using(HttpResponseMessage = await aPIHelper1.)
        }
        public async Task<List<Book>> GetAll()
        {
            using (HttpResponseMessage response = await aPIHelper1.ApiClient.GetAsync("api/Books3"))
            {
                var result = await response.Content.ReadAsAsync<List<Book>>();
                return result;

            }
        }
    }
}
