using PactNet;
using PactNet.Infrastructure.Outputters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace ProCodeGuide.ContractPact
{
    public class ProviderPactTest
    {

        private readonly ITestOutputHelper _output;


        public ProviderPactTest(ITestOutputHelper output) {
            _output = output;
        }

        [Fact]
        public void TestProvider()
        {
            var config = new PactVerifierConfig {
                Outputters = new List<IOutput>
                {
                    new XUnitOutput(_output)
                },
                Verbose = true //output verbose verificvation logs to the test output

            };

            new PactVerifier(config)
                .ServiceProvider("Service_Provider", "http://localhost:60880/api")
                .HonoursPactWith("Service_Consumer")
                .PactUri(@"c:\contractfile\pacts\service_consumer-service_provider.json")
                .Verify();

        }

        public class XUnitOutput : IOutput
        {
            private readonly ITestOutputHelper _output;

            public XUnitOutput(ITestOutputHelper output)
            {
                _output = output;
            }

            public void WriteLine(string line)
            {
                _output.WriteLine(line);
            }
        }



    }
}
