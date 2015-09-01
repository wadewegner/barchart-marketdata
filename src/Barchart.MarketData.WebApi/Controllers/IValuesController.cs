using System.Collections.Generic;
using System.Web.Http;

namespace Barchart.MarketData.WebApi.Controllers
{
    public interface IValuesController
    {
        IEnumerable<string> Get();
        string Get(int id);
    }
}