using MarsRoverBlazor.Shared;
using MarsRoverLib.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MarsRoverLib.Service {
    public class HoustonService : IHoustonService {

        /// <summary>
        /// Method should provide the path to move for the rover
        /// </summary>
        /// <param name="directive">Expected pattern <strong>"[0-9]+ [0-9]+ [A-Z][|][LRM]+"</strong>
        /// e.g.</br>
        /// 1 2 N|LMLMLMLMM</br>
        /// 3 3 E|MMRMMRMRRM
        /// </param>
        /// <returns></returns>
        public IEnumerable<Directive> sendDirective(string directive) {
            if (directive is null) throw new ArgumentNullException(nameof(directive));
            if (!Regex.IsMatch(directive, "^[0-9]+ [0-9]+ [NESW][|][LRM]+$")) throw new ArgumentException("Incorrect directive pattern", nameof(directive));

            var splitDirectives = directive.Split("|");
            var roverInit = splitDirectives[0].Split(" ");
            var moves = splitDirectives[1];
            var rover = new Rover(int.Parse(roverInit[0]), int.Parse(roverInit[1]), char.Parse(roverInit[2]));

            yield return new Directive() {
                direction = rover.compassPoint.facingDirection,
                x = rover.point.X,
                y = rover.point.Y
            };

            foreach (var move in moves) {
                if (move.Equals('M')) {
                    rover.move();
                } else {
                    rover.turn(move);
                }
                yield return new Directive() {
                    direction = rover.compassPoint.facingDirection,
                    x = rover.point.X,
                    y = rover.point.Y
                };
            }

        }

    }
}
