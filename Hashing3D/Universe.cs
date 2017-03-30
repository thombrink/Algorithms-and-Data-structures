using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hashing3D
{
    public class Universe
    {
        private readonly HashSet<HashSet<HashSet<List<Vector>>>> _points;

        public Universe()
        {
            _points = new HashSet<HashSet<HashSet<List<Vector>>>>();
        }

        public void Add(Vector point)
        {
            var xList = _points.Get(point.X);
            var yList = xList.Get(point.Y);
            var zList = yList.Get(point.Z);
            zList.Add(point);
        }

        public List<Vector> Find(Vector point)
        {
            var xList = _points.Get(point.X);
            var yList = xList.Get(point.Y);
            return yList.Get(point.Z);
        }

        public Vector FindNearest(Vector position, int radius)
        {
            double shortestDistance = double.MaxValue;
            var nearestPlanet = default(Vector);
            for (var i = Math.Max(0, position.X - radius); i <= position.X + radius; i++)
            {
                for (var j = Math.Max(0, position.Y - radius); j <= position.Y + radius; j++)
                {
                    for (var k = Math.Max(0, position.Z - radius); k <= position.Y + radius; k++)
                    {
                        var vector = new Vector(i, j, k);
                        var vectors = Find(vector);
                        foreach (var planet in vectors)
                        {
                            var distance = position.CalcDistance(planet);
                            if (distance <= radius && distance < shortestDistance)
                            {
                                shortestDistance = distance;
                                nearestPlanet = planet;
                            }
                        }
                    }
                }
            }

            return nearestPlanet;
        }
    }
}
