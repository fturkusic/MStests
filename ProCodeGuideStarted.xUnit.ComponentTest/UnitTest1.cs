using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;


namespace ProCodeGuideStarted.xUnit.ComponentTest
{
    public class UnitTest1
    {


        private ComponentTestConfig TestConfig { get; set; } = new ComponentTestConfig();


        UnitTest1 unitTest1;

        public UnitTest1()
        {
            unitTest1 = new UnitTest1();
            TestConfig = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", false, false)
                .AddEnvironmentVariables()
                .Build()
                .GetSection("ComponentTests")
                .Get<ComponentTestConfig>();
       }


        [Fact]
        public async Task ShouldReturnGetRequest()
        {
            var httpClient = new HttpClient { BaseAddress = new Uri(TestConfig.ServiceUri) };

            var responce = await httpClient.GetAsync("/api/Maths");
            var responceJson = await responce.EnsureSuccessStatusCode().Content.ReadAsStringAsync();


            Assert.Equal("Test",responceJson);

        }
    }
}
