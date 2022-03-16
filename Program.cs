using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Practice {
    internal class Program {
        static void Main(string[] args) {
            ArrayProblems demo = new ArrayProblems();

            //2, 3, 0, 3, 1
            //2, 1, 2, 1, 1
            //5, 4, 3, 4, 1, 1, 1, 1, 1, 1, 1, 1 
            int[] input = { 2, 3, 0, 3, 1 };

            for(int i = 0; i < input.Length; i++) {
                Console.Write(input[i]+" ");
            }
            Console.WriteLine("Shortest path = ");
            Console.WriteLine(demo.jumpgame2(input));
        }
    }
}