using System;
using System.Configuration;
using System.Threading.Tasks;
using Barchart.MarketData.Models;
using Barchart.MarketData.Service;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Barchart.MarketData.UnitTests
{
    [TestFixture]
    public class History
    {
        private static string _key = ConfigurationManager.AppSettings["Key"];

        [TestFixtureSetUp]
        public void Init()
        {
            if (!string.IsNullOrEmpty(Environment.GetEnvironmentVariable("ConsumerKey")))
            {
                _key = Environment.GetEnvironmentVariable("ConsumerKey");
            }
        }

        [Test]
        public async Task Unauthorized()
        {
            using (var client = new Client())
            {
                const string symbol = "MSFT";
                const string type = "daily";
                const string startDate = "20140831000000";

                var urlSuffix = string.Format("?key=badkey&symbol={1}&type={2}&startDate={3}", _key, symbol, type, startDate);
                var history = await client.GetHistory(urlSuffix);

                Assert.IsNotNull(history);
                Assert.IsNotNull(history.Results);
                Assert.IsNotNull(history.Status);
            }
        }

        [Test]
        public async Task GetHistory()
        {
            using (var client = new Client())
            {
                const string symbol = "MSFT";
                const string type = "daily";
                const string startDate = "20140831000000";

                var urlSuffix = string.Format("?key={0}&symbol={1}&type={2}&startDate={3}", _key, symbol, type, startDate);
                var history = await client.GetHistory(urlSuffix);

                Assert.IsNotNull(history);
                Assert.IsNotNull(history.Results);
                Assert.IsNotNull(history.Status);
            }
        }

    }
}
