using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarsRoverBlazor.Server.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Microsoft.Extensions.Logging;
using MarsRoverLib.Service;
using MarsRoverBlazor.Shared;
using Microsoft.AspNetCore.Mvc;

namespace MarsRoverBlazor.Server.Controllers.Tests {
    [TestClass]
    public class HomeControllerTests {

        [TestMethod]
        public void getDirectivesTestWhenAllGoodTest() {
            var logger = new Mock<ILogger<HomeController>>();
            var houstonService = new Mock<IHoustonService>();            
            houstonService
                .Setup(x => x.sendDirective(It.IsAny<string>()))
                .Returns(new List<Directive>() { 
                    new Directive() {direction = 'N', x = 1, y = 1 } 
                });

            var controller = new HomeController(logger.Object, houstonService.Object);
            var output = controller.Get("some directives") as OkObjectResult;

            Assert.IsNotNull(output);
            Assert.IsInstanceOfType(output.Value, typeof(IEnumerable<Directive>));

        }

        [TestMethod]
        public void getDirectivesTestWhenEmptyResponseOnError() {
            var logger = new Mock<ILogger<HomeController>>();
            var houstonService = new Mock<IHoustonService>();
            houstonService
                .Setup(x => x.sendDirective(It.IsAny<string>()))
                .Throws(new ArgumentException());

            var controller = new HomeController(logger.Object, houstonService.Object);
            var output = controller.Get("some directives") as OkObjectResult;

            Assert.IsNull(output);
        }
    }
}