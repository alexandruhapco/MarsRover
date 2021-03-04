using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace MarsRoverLib.Model {

    public class Rover {

        public Point point { get; private set; }
        public CompassPoint compassPoint { get; private set; }

        public Rover(int x, int y, string facingDirection) {
            if (x < 0) throw new ArgumentException("Coordinate x cannot be negative", nameof(x));
            if (y < 0) throw new ArgumentException("Coordinate y cannot be negative", nameof(y));
            if (facingDirection is null) throw new ArgumentNullException(nameof(facingDirection));

            this.point = new Point(x, y);
            this.compassPoint = new CompassPoint(facingDirection);
        }

        public string turn(string turnDirection) {
            return compassPoint.turn(turnDirection);
        }

        public Point move() {
            point += compassPoint.movePoint;
            //TODO: move to higher level of abstraction
            //if(point.X < 0 || point.Y < 0) {
            //    throw new ArgumentOutOfRangeException("Oh, no! Rover fell over the edge of the platform!");
            //}
            return point;
        }

    }
}
