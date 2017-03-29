using System;
using Hashing3D;
using NUnit.Framework;

namespace Hashing3DTest
{
    [TestFixture]
    public class VectorTest
    {
        [Test]
        public void ItCalculatesTheDistance()
        {
            var vectorA =  new Vector(0,0,0);
            var vectorB = new Vector(3,4,5);

            var distance = vectorA.CalcDistance(vectorB);

            // pythagoras(3,4) = 5
            // pythagoras(5,5) = sqrt(50)
            Assert.AreEqual(Math.Sqrt(50), distance);
        }
    }
}
