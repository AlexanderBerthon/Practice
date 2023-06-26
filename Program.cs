using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Practice {
    public class Program {
        static void Main(string[] args) {
            TwoSum test = new TwoSum();
            int[] nums = { 4, 3, 0 };
            int target = 3;

            Console.WriteLine(test.solve(nums, target));
        }
    }
}