using PactNet;
using PactNet.Mocks.MockHttpService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCodeGuide.ContractPact.ContractPact
{
    public class ContractPact : IDisposable
    {
        public IPactBuilder PactBuilder { get; private set; }
        public IMockProviderService MockPoviderService { get; private set; }

        public int MockServerPort { get { return 9224;  } }

        public string MockPoviderServiceBaseUri { get { return string.Format("http://localhost:{0}", MockServerPort); } }

        public ContractPact() {
            //pact configuration 
            var pactConfig = new PactConfig
            {
                SpecificationVersion = "2.0.0",
                PactDir = @"c:\contractfile\pacts",
                LogDir = @"c:\contractfile\logs"

            };

            PactBuilder = new PactBuilder(pactConfig);
            PactBuilder
                .ServiceConsumer("Service_Consumer")
                .HasPactWith("Service_Provider");


            MockPoviderService = PactBuilder.MockService(MockServerPort);

        }

        public void Dispose()
        {
            //note: will save the pact file once finished
            PactBuilder.Build();
        
        }



    }
}
