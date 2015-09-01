using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Barchart.MarketData.WebApi.Controllers;

namespace Barchart.MarketData.WebApi.Services
{
    public class ValuesService : IValuesController
    {
        public IEnumerable<string> Get()
        {
            var value = new string[] { "value1", "value2" };
            return value;
        }

        public string Get(int id)
        {
            return "value";
        }
    }
}