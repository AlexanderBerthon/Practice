using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Practice {
    public class Program {
        static void Main(string[] args) {
            //Palindrome test = new Palindrome();
            //Console.WriteLine(test.solve(111));


            Console.WriteLine(123);
            int value = 123;
            string original = value.ToString();
            Console.WriteLine(original);
            string reverse = (original.Reverse()).ToString();
            Console.WriteLine(reverse);

            if (original.Equals(reverse)) {
                Console.WriteLine("TRUE");
                }
            else {
                Console.WriteLine("FALSE");
            }

        }
    }
}