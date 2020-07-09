using BookShopUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BookShopUI.Helpers
{
    public class BookPostEndPoint : IBookPostEndPoint
    {
        private readonly IAPIHelper aPIHelper1;
        public BookPostEndPoint(IAPIHelper aPIHelper)
        {
            aPIHelper1 = aPIHelper;
            //using(HttpResponseMessage = await aPIHelper1.)
        }
        public async Task PostBook(Book book)
        {
            using (HttpResponseMessage response = await aPIHelper1.ApiClient.PostAsJsonAsync("/api/Books", book))
            {
                if (response.IsSuccessStatusCode)
                {

                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
