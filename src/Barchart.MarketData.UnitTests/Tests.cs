using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Barchart.MarketData.WebApi.Controllers;
using Moq;
using NUnit.Framework;

namespace Barchart.MarketData.UnitTests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void Values_Get_StringEnumeration()
        {
            var expectedResults = new[] { "value1", "value2" };
            var repositoryMock = new Mock<IValuesController>();
            repositoryMock.Setup((m) => m.Get()).Returns(expectedResults);
            var valuesController = new ValuesController(repositoryMock.Object);

            var returnValues = valuesController.Get();

            Assert.AreEqual(expectedResults, returnValues);
        }
    }
}
