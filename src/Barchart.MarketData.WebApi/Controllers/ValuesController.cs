﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Messaging;
using System.Web.Http;

namespace Barchart.MarketData.WebApi.Controllers
{
    public class ValuesController : ApiController, IValuesController
    {
        private IValuesController _repository;

        public ValuesController(IValuesController repository)
        {
            _repository = repository;
        }

        // GET api/values
        public IEnumerable<string> Get()
        {
            //var value = new string[] { "value1", "value2" };
            return _repository.Get();
        }

        // GET api/values/5
        public string Get(int id)
        {
            //return "value";

            return _repository.Get(id);
        }

    }
}