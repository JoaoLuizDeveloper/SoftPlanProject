using FluentAssertions;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace CalcTest.IntegrationTest
{
    public class CodeIntegrationTest
    {
        [Fact]
        public async Task Code_GetUrlCode_ReturnOK()
        {
            using (var client = new TestClientProvider().Client)
            {
                var response = await client.GetAsync("/api/showmethecode");

                response.EnsureSuccessStatusCode();
                response.StatusCode.Should().Be(HttpStatusCode.OK);
            }
        }
    }
}
