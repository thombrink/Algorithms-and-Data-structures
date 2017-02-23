using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palindromes
{
    class Program
    {
        static void Main(string[] args)
        {
            var val1 = "testhahaha";
            var val2 = "te st  ha haha";
            var val3 = "tes 4 thasa 6 ahaha sa";

            Console.WriteLine($"palindrome of '{val1}' is '{Recursive(val1)}'");
            Console.WriteLine($"palindrome of '{val2}' is '{Recursive(val2)}'");
            Console.WriteLine($"palindrome of '{val3}' is '{Recursive(val3)}'");

            Console.Write(Environment.NewLine);

            Console.WriteLine($"palindrome of '{val1}' is '{NonRecursive(val1)}'");
            Console.WriteLine($"palindrome of '{val2}' is '{NonRecursive(val2)}'");
            Console.WriteLine($"palindrome of '{val3}' is '{NonRecursive(val3)}'");

            Console.ReadKey();
        }

        static string Recursive(string s)
        {
            if (s.Length == 0)
                return string.Empty;
            else
                return s.Substring(s.Length - 1, 1) + Recursive(s.Substring(0, s.Length - 1));
        }

        static string NonRecursive(string s)
        {
            var result = new StringBuilder();
            for(var i = 0; i < s.Length; i++)
            {
                result.Append(s.Substring(s.Length - 1 - i, 1));
            }
            return result.ToString();
        }
    }
}
