using BookShopUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BookShopUI.Helpers
{
    public class AuthorPostEndPoint : IAuthorPostEndPoint
    {
        private readonly IAPIHelper aPIHelper1;
        public AuthorPostEndPoint(IAPIHelper aPIHelper)
        {
            aPIHelper1 = aPIHelper;
            //using(HttpResponseMessage = await aPIHelper1.)
        }
        public async Task PostAuthor(Author author)
        {
            using (HttpResponseMessage response = await aPIHelper1.ApiClient.PostAsJsonAsync("/api/Authors", author))
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
