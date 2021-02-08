using FluentAssertions;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace CalcTest.IntegrationTest
{
    public class CalcTestIntegrationTest
    {
        [Fact]
        public async Task CalcTest_CalculaJuros_ReturnOK()
        {
            using (var client = new TestClientProvider().Client)
            {
                var response = await client.GetAsync("/api/calculajuros/100/5");

                response.EnsureSuccessStatusCode();
                response.StatusCode.Should().Be(HttpStatusCode.OK);
            }
        }
    }
}
