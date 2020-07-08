using BookShopUI.Models;
using Newtonsoft.Json;
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
    public class APIHelper : IAPIHelper
    {
        public HttpClient apiClient;
        private IAuthor author1;

        public APIHelper(IAuthor author)
        {
            InitializeClient();
            author1 = author;
        }
        public HttpClient ApiClient
        {
            get
            {
                return apiClient;
            }
        }
        private void InitializeClient()
        {
            string webAdress = ConfigurationManager.AppSettings["webAdress"];

            apiClient = new HttpClient();
            apiClient.BaseAddress = new Uri(webAdress);
            apiClient.DefaultRequestHeaders.Accept.Clear();
            apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<AuthenticatedUser> Authenticate(string username, string password)
        {
            var data = new FormUrlEncodedContent(new[]
            {

                new KeyValuePair<string, string>("username", username),
                new KeyValuePair<string, string>("password", password),
                new KeyValuePair<string, string>("grant_type", "password")
            });

            using (HttpResponseMessage response = await apiClient.PostAsync("/Token", data))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<AuthenticatedUser>();
                    return result;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
        public async Task GetAuthor(string token)
        {
            apiClient.DefaultRequestHeaders.Clear();
            apiClient.DefaultRequestHeaders.Accept.Clear();
            apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            apiClient.DefaultRequestHeaders.Add("Authorization", $"Bearer { token }");

            using (HttpResponseMessage response = await apiClient.GetAsync("/api/Authors2"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<Author>();
                    author1.LastName = result.LastName;

                    //var autorzy = JsonConvert.DeserializeObject<List<Author>>(result);
                  

                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
        //public async Task<Author> GetAuthorAsync(string token)
        
    }
}

