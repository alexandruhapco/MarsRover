using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarsRoverLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverTest.Model {
    [TestClass]
    public class CompassPointTests {

        [TestMethod]
        public void compassPointWhenAllGoodTest() {
            var compassPoint = new CompassPoint('N');
            Assert.AreEqual(0, compassPoint.index);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Incorrect cardinal compass point")]
        public void compassPointWhenIncorrectCardinalPointTest() {
            new CompassPoint('Q');
        }

        private static readonly IReadOnlyList<char> compassList = new List<char>() { 'N', 'E', 'S', 'W' };

        [TestMethod]
        public void compassPointWhenTurnSimpleTest() {
            var compassPoint = new CompassPoint('N');

            for (int i = 0; i < 3; i++) {
                compassPoint.turn('R');
                Assert.AreEqual(compassList[i + 1], compassPoint.facingDirection);
                Assert.AreEqual(i + 1, compassPoint.index);
            }

            for (int i = 2; i < -1; i--) {
                compassPoint.turn('L');
                Assert.AreEqual(compassList[i + 1], compassPoint.facingDirection);
                Assert.AreEqual(i + 1, compassPoint.index);
            }

        }

        [TestMethod]
        public void compassPointWhenTurnAroundTest() {
            var compassPoint = new CompassPoint('N');
            compassPoint.turn('L');
            Assert.AreEqual('W', compassPoint.facingDirection);
            Assert.AreEqual(3, compassPoint.index);
            compassPoint.turn('R');
            Assert.AreEqual('N', compassPoint.facingDirection);
            Assert.AreEqual(0, compassPoint.index);
        }

    }
}