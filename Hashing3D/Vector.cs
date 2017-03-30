using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hashing3D
{
    public class Vector
    {
        public int X;
        public int Y;
        public int Z;

        public Vector(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public double CalcDistance(Vector dest)
        {
            var dX = Math.Abs(X - dest.X);
            var dY = Math.Abs(Y - dest.Y);
            var dZ = Math.Abs(Z - dest.Z);
            // Step 1: use Pythagoras to calculate Δx, Δy -> xySquared
            var xySquared = Math.Pow(dX, 2) + Math.Pow(dY, 2);

            // Step 2: use Pythagoras to calculate xySquared, Δz -> xyz
            var xyz = Math.Sqrt(xySquared + Math.Pow(dZ, 2));

            return xyz;
        }

        public override string ToString()
        {
            return $"x: {X}, y: {Y}, z: {Z}";
        }
    }
}
