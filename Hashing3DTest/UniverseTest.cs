using System;
using Hashing3D;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Hashing3DTest
{
    [TestFixture]
    public class UniverseTest
    {
        [Test]
        public void it_should_work()
        {
            var universe = new Universe();

            universe.Add(new Vector(3, 3, 6));

            var vectors = universe.Find(new Vector(3, 3, 6));

            Assert.AreEqual(1, vectors.Count);
        }

        [Test]
        public void ItShouldReturnNearestPlanet()
        {
            var planets = new List<Vector>
            {
                new Vector(3, 4, 2),
                new Vector(7, 5, 1)
            };

            var universe = new Universe();
            planets.ForEach(universe.Add);

            var nearest = universe.FindNearest(new Vector(2, 3, 1), 1);
            Assert.AreEqual(planets.First(), nearest);
        }

        [Test]
        public void ItShouldNotReturnPlanetIfOutOfRadius()
        {
            var planets = new List<Vector>
            {
                new Vector(5, 4, 2),
                new Vector(7, 5, 1)
            };

            var universe = new Universe();
            planets.ForEach(universe.Add);

            var nearest = universe.FindNearest(new Vector(2, 3, 1), 2);
            Assert.AreEqual(null, nearest);
        }
    }
}
