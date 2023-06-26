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
            List<int> storage = new List<int>();

            for(int i = 0; i< nums.Length; i++) {
                if (nums[i] < target) {
                    storage.Add(nums[i]);
                }
            }

            

            storage.Sort();
            //[0, 3]
            for(int i = storage.Count-1; i > 0; i--) {
                if (storage[i] + storage[i-1] == target) {
                    solution = "(" + i + ", " + (i - 1) + ")";
                }
            }

            return solution;
        }
    }
}
/*
This solution works
but
is there a better way to solve it?

currently it is O(n)*O(n-1)
basically O(n)^2 which is pretty bad
*/

/*
atempt 2
subarray?

foreach element in the array
if(element at i < target)
 add to new array

[1, 2, 3, 4, 5] tar=9 this breaks

[5, 4, 3, 2, 1] tar = 3
[3, 2, 1] = works
[20, 10, 5, 2, 1] tar = 7
[5, 2, 1]

[2, 7, 11, 15] tar = 9
[2, 7] works


[3, 2, 4] =6
[4, 3, 2] works

[3, 3] = 6
works

ok
so its kinda scuffed
but you gotta sort it
*/

