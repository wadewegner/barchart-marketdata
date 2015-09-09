using System.Collections.Generic;

namespace Barchart.MarketData.WebApi.Services
{
    public interface IValuesService
    {
        IEnumerable<string> Get();
        string Get(int id);
    }
}