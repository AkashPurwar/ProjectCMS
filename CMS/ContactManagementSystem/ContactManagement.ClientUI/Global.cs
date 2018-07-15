using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace ContentManagement.API
{
    public static class Global
    {
        public static HttpClient webClient = new HttpClient();

        static Global()
        {
            webClient.BaseAddress = new Uri("http://localhost:4289/api/ContactAPI");
            webClient.DefaultRequestHeaders.Clear();
            webClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

       
    }
}