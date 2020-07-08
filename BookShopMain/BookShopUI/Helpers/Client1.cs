using BookShopUI.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BookShopUI.Helpers
{
    class Client1
    {
        public HttpClient apiClient;
        private void InitializeClient()
        {
            string webAdress = ConfigurationManager.AppSettings["webAdress"];

            apiClient = new HttpClient();
            apiClient.BaseAddress = new Uri(webAdress);
            apiClient.DefaultRequestHeaders.Accept.Clear();
            apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task<List<Author>>GetAuthor()
        {
            apiClient.DefaultRequestHeaders.Clear();
            apiClient.DefaultRequestHeaders.Accept.Clear();
            apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
           // apiClient.DefaultRequestHeaders.Add("Authorization", $"Bearer { token }");

            using (HttpResponseMessage response = await apiClient.GetAsync("/api/Authors"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<List<Author>>();
                    //var autorzy = JsonConvert.DeserializeObject<List<Author>>(result);
                    return result;


                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
