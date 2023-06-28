using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice {
    public class TwoSum {

        /*
		Given an array of integers and a target int, return index of TWO values in the array
		that when add together equal the target. 

		nums = [1, 2, 3]
		tar = 4
		return: (0, 2)

		*/
        public TwoSum() {
        }

        public string solve(int[] nums, int target) {
            string solution = "No Solution";

            for (int i = 0; i < nums.Length; i++) {
                for(int j = i+1; j < nums.Length; j++) {
                    if (nums[i] + nums[j] == target) {
                        solution = "("+i+", "+j+")";
                    }
                }
            }
            return solution;
        }
    }
}