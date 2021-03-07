using MarsRoverBlazor.Shared;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MarsRoverLib.Service.Tests {
    [TestClass]
    public class HoustonServiceTests {

        [TestMethod]
        public void sendDirectiveWhenAllGoodTest() {
            var houstonService = new HoustonService();
            var result = houstonService.sendDirective("1 2 N|LMLMLMLMM");

            var expected = new List<Directive>() {
                new Directive() {x = 1, y = 2, direction = 'N'},
                new Directive() {x = 1, y = 2, direction = 'W'}, //L
                new Directive() {x = 0, y = 2, direction = 'W'}, //M
                new Directive() {x = 0, y = 2, direction = 'S'}, //L
                new Directive() {x = 0, y = 1, direction = 'S'}, //M
                new Directive() {x = 0, y = 1, direction = 'E'}, //L
                new Directive() {x = 1, y = 1, direction = 'E'}, //M
                new Directive() {x = 1, y = 1, direction = 'N'}, //L
                new Directive() {x = 1, y = 2, direction = 'N'}, //M
                new Directive() {x = 1, y = 3, direction = 'N'}, //M             
            };

            CollectionAssert.AreEqual(expected, result.ToList());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Incorrect directive pattern")]
        [DataRow("1 2 N|LMLWMLMLMM")]
        [DataRow("Q")]
        [DataRow("12 N|LMLWMLMLMM")]
        [DataRow("1 2 N| LMLWMLMLMM")]
        [DataRow("1 2 H|LMLWMLMLMM")]
        [DataRow("")]
        public void sendDirectiveWhenIncorrectDirectiveTest(string directive) {
            var houstonService = new HoustonService();
            _ = houstonService.sendDirective(directive).First();
        }
    }
}