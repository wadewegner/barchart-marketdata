﻿using System.Collections.Generic;
using System.Web.Http;
using Barchart.MarketData.WebApi.Services;

namespace Barchart.MarketData.WebApi.Controllers
{
    public class ValuesController : ApiController, IValuesController
    {
        private readonly IValuesService _repository;

        public ValuesController(IValuesService repository)
        {
            _repository = repository;
        }

        // GET api/values
        public IEnumerable<string> Get()
        {
            return _repository.Get();
        }

        // GET api/values/5
        public string Get(int id)
        {
            return _repository.Get(id);
        }
    }
}
