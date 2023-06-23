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
            List<int> list = new List<int>();
            list.Add(4);
            list.Add(3);
            list.Add(0);
            Console.WriteLine("nums length: "+nums.Length);
            Console.WriteLine("nums count: "+nums.Count());
            Console.WriteLine("list count: "+list.Count);

            int target = 3;

            Console.WriteLine(test.solve(nums, target));
        }
    }
}