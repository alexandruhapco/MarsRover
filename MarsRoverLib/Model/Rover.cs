using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace MarsRoverLib.Model {

    public class Rover {

        public Point point { get; private set; }
        public CompassPoint compassPoint { get; private set; }

        public Rover(int x, int y, char facingDirection) {
            if (x < 0) throw new ArgumentException("Coordinate x cannot be negative", nameof(x));
            if (y < 0) throw new ArgumentException("Coordinate y cannot be negative", nameof(y));

            this.point = new Point(x, y);
            this.compassPoint = new CompassPoint(facingDirection);
        }

        public char turn(char turnDirection) {
            return compassPoint.turn(turnDirection);
        }

        public Point move() {
            point += compassPoint.movePoint;
            return point;
        }

    }
}
