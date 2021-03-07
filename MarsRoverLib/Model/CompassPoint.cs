using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverLib.Model {
    public class CompassPoint {

        //order of dictionary items is important and used for the further logic
        public static readonly IReadOnlyDictionary<char, Point> compassDict = new Dictionary<char, Point>() {
            { 'N', new Point(0, 1) },
            { 'E', new Point(1, 0) },
            { 'S', new Point(0, -1) },
            { 'W', new Point(-1, 0) }
        };
        public Size movePoint => (Size)compassDict[facingDirection]; 

        public int index { get; private set; }
        public char facingDirection { get; private set; }

        public CompassPoint(char facingDirection) {
            if (!compassDict.ContainsKey(facingDirection)) throw new ArgumentException("Incorrect cardinal compass point", nameof(facingDirection));

            this.facingDirection = facingDirection;
            index = compassDict.Keys.ToList().IndexOf(facingDirection);
        }

        public char turn(char turnDirection) {
            switch (turnDirection) {
                case 'R':
                    index += 1;
                    if (index > compassDict.Count - 1) { index = 0; }
                    break;
                case 'L':
                    index -= 1;
                    if (index < 0) { index = compassDict.Count - 1; }
                    break;
                default: throw new ArgumentException("Incorrect turn direction", nameof(turnDirection));
            }

            facingDirection = compassDict.Keys.ElementAt(index);
            return facingDirection;
        }

    }
}
