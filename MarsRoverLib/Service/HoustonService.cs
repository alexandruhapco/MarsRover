using MarsRoverLib.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverLib.Service {
    public class HoustonService {

        public List<Point> sendDirective(string directive) {
            if (directive is null) throw new ArgumentNullException(nameof(directive));

            var splitDirectives = directive.Split("|");
            var roverInit = splitDirectives[0].Split(" ");
            var moves = splitDirectives[1];
            var rover = new Rover(int.Parse(roverInit[0]), int.Parse(roverInit[1]), char.Parse(roverInit[2]));

            var moveList = new List<Point>();

            foreach(var move in moves) {
                if(move.Equals('M')) {
                    rover.move();
                    moveList.Add(rover.point);
                } else {
                    rover.turn(move);
                }                
            }

            return moveList;
        }

    }
}
