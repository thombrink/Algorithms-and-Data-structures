using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opgave_1 {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine(PrintLetters(3));
            Console.WriteLine(PrintLetters2(3, 5));


            Console.WriteLine(IsPalindroom("pap"));
            Console.WriteLine(IsPalindroom("abba"));
            Console.WriteLine(IsPalindroom("was it a car or a cat I saw"));
            Console.WriteLine(IsPalindroom("10201"));

            Console.ReadKey();
        }

        static string PrintLetters(int n) {
            if(n <= 0) {
                return string.Empty;
            }

            return "A" + PrintLetters(n - 1) + "Z";
        }

        static string PrintLetters2(int p, int q) {
            string result = string.Empty;

            if(p <= 0 && q <= 0) {
                return string.Empty;
            }

            if (p > 0) {
                result += "A";
            }

            result += PrintLetters2(p - 1, q - 1);

            if (q > 0) {
                result += "Z";
            }

            return result;
        }

        static bool IsPalindroom(string s) {
            if (s.Length <= 1) {
                return true;
            }

            if (Char.IsWhiteSpace(s[0])){
                return IsPalindroom(s.Substring(1));
            }

            if (Char.IsWhiteSpace(s[s.Length - 1])){
                return IsPalindroom(s.Substring(0, s.Length - 1));
            }

            if (s[0].ToString().ToLower() == s[s.Length - 1].ToString().ToLower()) {
                return IsPalindroom(s.Substring(1, s.Length - 2));
            } else {
                return false;
            }
        }
    }
}
