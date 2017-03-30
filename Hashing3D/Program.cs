using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hashing3D
{
    class Program
    {
        static void Main(string[] args)
        {
            var universe = new Universe();
            universe.Add(new Vector(4, 3, 5));
            universe.Add(new Vector(23, 19, 20));
            universe.Add(new Vector(33, 29, 10));

            Console.WriteLine("vectors on 3, 9, 0");
            universe.Find(new Vector(3, 9, 0)).ForEach(Console.WriteLine);

            Console.WriteLine("\nnearest planet to 3, 9, 0");
            Console.WriteLine(universe.FindNearest(new Vector(3, 9, 0), 10));
        }
    }
}
