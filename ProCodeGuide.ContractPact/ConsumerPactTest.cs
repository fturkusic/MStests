using PactNet.Mocks.MockHttpService;
using ProCodeGuide.ContractPact.Mock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ProCodeGuide.ContractPact
{
    public class ConsumerPactTest : IClassFixture<ContractPact.ContractPact>
    {
        private IMockProviderService _mockProviderService;
        private string _mockProviderServiceBaseUri;

        public ConsumerPactTest(ContractPact.ContractPact data)
        {
            _mockProviderService = data.MockPoviderService;
            _mockProviderService.ClearInteractions(); //note: clear any previously registred interaction before ther test is run
            _mockProviderServiceBaseUri = data.MockPoviderServiceBaseUri;
        }

        [Fact]
        public void GetString_VarifyIfItReturns()
        {
            //Arange
            _mockProviderService
                    .Given("String test")
                    .UponReceiving("A Get request to retrieve string")
                    .With(new PactNet.Mocks.MockHttpService.Models.ProviderServiceRequest
                    {
                        Method = PactNet.Mocks.MockHttpService.Models.HttpVerb.Get,
                        Path = "/api/Maths",
                        Headers = new Dictionary<string, object>
                        {
                            { "Accept", "application/json"}
                        }
                    })
                    .WillRespondWith(new PactNet.Mocks.MockHttpService.Models.ProviderServiceResponse
                    {
                        Status = 200,
                        Headers = new Dictionary<string, object>
                        {
                            { "Content-Type", "application/json, charset-utf-8"}
                        },
                        Body = "Test"

                    });

            var consumer = new APIClient(_mockProviderServiceBaseUri);

            //Act
            var result = consumer.GetString();

            //Assert
            Assert.Equal("Test", result);

            _mockProviderService.VerifyInteractions();


        }


        [Fact]
        public void GetString_VarifyIfItReturns_Fall()
        {
            //Arange
            _mockProviderService
                    .Given("String test")
                    .UponReceiving("A Get request to retrieve string")
                    .With(new PactNet.Mocks.MockHttpService.Models.ProviderServiceRequest
                    {
                        Method = PactNet.Mocks.MockHttpService.Models.HttpVerb.Get,
                        Path = "/api/Maths",
                        Headers = new Dictionary<string, object>
                        {
                            { "Accept", "application/json"}
                        }
                    })
                    .WillRespondWith(new PactNet.Mocks.MockHttpService.Models.ProviderServiceResponse
                    {
                        Status = 200,
                        Headers = new Dictionary<string, object>
                        {
                            { "Content-Type", "application/json, charset-utf-8"}
                        },
                        Body = "Test"

                    });

            var consumer = new APIClient(_mockProviderServiceBaseUri);

            //Act
            var result = consumer.GetString();

            //Assert
            Assert.Equal("Test", result);

            _mockProviderService.VerifyInteractions();


        }


    }
}
