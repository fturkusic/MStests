using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProCodeGuide.ContractPact.Mock
{
    class APIClient
    {
   
        private readonly HttpClient _client;


        public APIClient(string baseUri = null)
        {
            _client = new HttpClient { BaseAddress = new Uri(baseUri ?? "https://localhost:44360") };
            //https://localhost:44360/api/Maths
        }


        public string GetString()
        {

            string reasonPhrase;

            var request = new HttpRequestMessage(HttpMethod.Get, "/api/Maths");
            request.Headers.Add("Accept", "application/json");

            var response = _client.SendAsync(request);

            var content = response.Result.Content.ReadAsStringAsync().Result;
            var status = response.Result.StatusCode;


            reasonPhrase = response.Result.ReasonPhrase;

            request.Dispose();
            response.Dispose();

            if(status == System.Net.HttpStatusCode.OK)
                return !String.IsNullOrEmpty(content) ? content : null;


            //return new Exception(reasonPhrase);
            return null;
        }





    }
}
