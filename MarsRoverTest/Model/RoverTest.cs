using MarsRoverLib.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;

namespace MarsRoverTest {
    [TestClass]
    public class RoverTest {

        [TestMethod]
        public void roverConstructorWhenAllGoodTest() {
            new Rover(1, 1, 'N');
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Coordinate x cannot be negative")]
        public void roverConstructorWhenXNegativeTest() {
            new Rover(-1, 1, 'N');
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Coordinate y cannot be negative")]
        public void roverConstructorWhenYNegativeTest() {
            new Rover(1, -1, 'N');
        }

        [TestMethod]
        public void roverTurnWhenAllGoodTest() {
            var rover = new Rover(1, 1, 'E');
            rover.turn('L');
            rover.turn('R');
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Incorrect turn direction")]
        public void roverTurnWhenIncorrectTurnDirectionTest() {
            var rover = new Rover(1, 1, 'E');
            rover.turn('Q');
        }

        [TestMethod]
        public void roverMoveWhenAllGoodTest() {
            var rover = new Rover(1, 1, 'E');
            rover.move();
            Assert.AreEqual(new Point(2, 1), rover.point);
            rover.move();
            Assert.AreEqual(new Point(3, 1), rover.point);
            rover.turn('L');
            rover.move();
            Assert.AreEqual(new Point(3, 2), rover.point);
        }

    }
}
