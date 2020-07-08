using BookShopUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BookShopUI.Helpers
{
    public class AuthorEndPoint : IAuthorEndPoint
    {
        private readonly IAPIHelper aPIHelper1;
        public AuthorEndPoint(IAPIHelper aPIHelper)
        {
            aPIHelper1 = aPIHelper;
            //using(HttpResponseMessage = await aPIHelper1.)
        }
        public async Task<List<Author>> GetAll()
        {
            using (HttpResponseMessage response = await aPIHelper1.ApiClient.GetAsync("api/Authors3"))
            {
                var result = await response.Content.ReadAsAsync<List<Author>>();
                return result;

            }
        }
        // public async Task<>
    }
}
