using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;
using System.Net.Http;
using ProCodeGuide.GettingStarted.xUnit;
using System.Net;

namespace ProCodeGuide.GettingStarted.IntegrationTest
{
    public class IntegrationTest
    {
        private readonly HttpClient _client;

        public IntegrationTest()
        {
            var server = new TestServer(new WebHostBuilder()
                .UseEnvironment("Development")
                .UseStartup<Startup>());
            _client = server.CreateClient();


        }

        [Theory]
        [InlineData("GET")]
        public async Task GetAllTestAsync(string method)
        {

            //Arange
            var request = new HttpRequestMessage(new HttpMethod(method), "/api/Maths");


            //Act
            var responce = await _client.SendAsync(request);

            //Assert

            responce.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, responce.StatusCode);
        }

        [Theory]
        [InlineData("GET")]
        public async Task GetAllTestAsyncFall(string method)
        {

            //Arange
            var request = new HttpRequestMessage(new HttpMethod(method), "/api/Maths");


            //Act
            var responce = await _client.SendAsync(request);

            //Assert

            responce.EnsureSuccessStatusCode();
            Assert.NotEqual(HttpStatusCode.InternalServerError, responce.StatusCode);
        }
    }
}
