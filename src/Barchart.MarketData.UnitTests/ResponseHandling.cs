using System;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Barchart.MarketData.Service;
using NUnit.Framework;

namespace Barchart.MarketData.UnitTests
{
    [TestFixture]
    public class ResponseHandling
    {
        
        [Test]
        public async Task CheckOkResponseHandling()
        {
            const string expectedResponse = "response";

       

            var mockHttpMessageHandler = new MockHttpMessageHandler
            {
                Response =
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(expectedResponse)
                }
            };

            var client = new Client(new HttpClient(mockHttpMessageHandler));
            var uri = new Uri("http://unittest");
            var response = await client.HttpGetAsync(uri);

            Assert.IsNotNullOrEmpty(response);
            Assert.AreEqual(expectedResponse, response);
        }

        [Test]
        [ExpectedException(typeof(HttpRequestException))]
        public async Task CheckBadRequestResponseHandling()
        {
            var mockHttpMessageHandler = new MockHttpMessageHandler
            {
                Response = { StatusCode = HttpStatusCode.BadRequest }
            };

            var client = new Client(new HttpClient(mockHttpMessageHandler));
            var uri = new Uri("http://unittest");

            try
            {
                await client.HttpGetAsync(uri);
            }
            catch (HttpRequestException httpRequestException)
            {
                Assert.AreEqual(httpRequestException.Message, "Response status code does not indicate success: 400 (Bad Request).");

                throw;
            }
        }

        [Test]
        [ExpectedException(typeof(HttpRequestException))]
        public async Task CheckInternalServerErrorResponseHandling()
        {
            var mockHttpMessageHandler = new MockHttpMessageHandler
            {
                Response = { StatusCode = HttpStatusCode.InternalServerError }
            };

            var client = new Client(new HttpClient(mockHttpMessageHandler));
            var uri = new Uri("http://unittest");

            try
            {
                await client.HttpGetAsync(uri);
            }
            catch (HttpRequestException httpRequestException)
            {
                Assert.AreEqual(httpRequestException.Message, "Response status code does not indicate success: 500 (Internal Server Error).");

                throw;
            }
        }
    }
}
