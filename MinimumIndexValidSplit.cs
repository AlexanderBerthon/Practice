using System.Collections;

/*
#2780
Minimum Index of a Valid Split

An element x of an int array arr of length n is dominant if more than half the elements of arr have a value of x

you are given a 0-indexed int array nums of length n with one dominant element.

you can split nums at an index i into two arrays nums[0, .., i]  and nums[i + 1, ..., n - 1], but the split is only valid if:
 - 0<= i < n - 1
 - nums[0, ..., i], and nums[i + 1, ..., n - 1] have the same dominant element

Here, nums[i, ..., j] denotes the subarray of nums starting at index i and ending at index j, both ends being inclusive. Particularly, if j < i then nums[i, ..., j] deontes an empty subarray.

return the minimum index of a valid split. if no valid split exists, return -1

example 1:
input: nums = [1, 2, 2, 2]
output: 2
explaination:

example 2:
input: nums = [2, 1, 3, 1, 1, 1, 7, 1, 2, 1]
output: 4

example 3:
input: nums = [3, 3, 3, 3, 7, 2, 2]
output: -1
*/

public class MinimumIndexValidSplit{

    public MinimumIndexValidSplit() { }

    public static int Solve(int[] arr) {
        Hashtable frequency = new Hashtable();
        int solution = -1;

        //get frequency
        for (int i = 0; i < arr.Length; i++) {
            int key = arr[i];
            if (!frequency.ContainsKey(key)) {
                frequency.Add(key, 1);
            }
            else {
                int value = (int)frequency[key];
                frequency.Remove(key);
                frequency.Add(key, value + 1);
            }
        }

        //get dominant value
        int dominantValue = arr[0];
        foreach (DictionaryEntry e in frequency) {
            if ((int)e.Value > (int)frequency[dominantValue]) {
                dominantValue = (int)e.Key;
            }
        }

        //calculate split
        int count1 = 0;
        int count2 = 0;
        for (int i = 0; i < arr.Length - 1; i++) {
            if (arr[i] == dominantValue) {
                count1 += 1;
            }
            if (count1 * 2 > i + 1) {
                count2 = 0;
                for (int j = i + 1; j <= arr.Length - 1; j++) {
                    if (arr[j] == dominantValue) {
                        count2 += 1;
                    }
                }
                if (count2 * 2 > arr.Length - (i + 1)) {
                    solution = i;
                    i = arr.Length - 1;
                }
            }
        }
        return solution;
    }
}


/*
explain the problem in your own words

given an array that has a 'dominant' value, ie. [value's frequency]*2 > array.length = true
need to split the array into 2 such that both sub arrays maintain this dominant value in both / satisfy the above equation
return the minimum index this is possible in or -1 if it's impossible
------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
explain the solution in your own words as simple as possible

so first we need to identify what the dominant value is - we do this by using a hashmap to get all the values and their frequencies from the given array
once we know what the dominant value is, we iterrate through the array and calculate all possible solutions starting from index 0. 
we calculate from 0->n for the first half of the array and if the first half maintains the dominant value then we check the second half; which is just the rest of the array
if that works, return i
if it doesn't, keep going until we get to the end
if there still isn't a solution return -1
------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
improvements?

some say this can be done in O(n) but idk how
some say this can be done with 2 passes of the array, idk how 
this is my solution..
1 pass to build the hashmap
1 pass of the hashmap to find dominant element (not needed?)
nested for loops to calculate all possible subarrays(worst case)
got to be like.. O(n^2) worst case right?
build hashmap = O(n)
find dominant value = O(n-1) worst case. 100 element array with all unique values, except for 1 that is duplicated. 
calculate all possible sub arrays = 
    if [1, 1, 1, .., 1]
    solved in 1 go, O(n)
    still has to check every element and add them up though, maybe could make it O(nlogn) with a clever formula?
    if [1, 2, 3, ..., 1]
    has to make n sub arrays for the first half and 1 for the second half
O(n) - iterate over whole array 1 time {1, 2, 3, 4, 5, 6, 7, 8, 9, 10]
instead we are doing..
[1]
[1, 2]
[1, 2, 3]
[1, 2, 3, 4]
[1, 2, 3, 4, 5]
[1, 2, 3, 4, 5, 6]
[1, 2, 3, 4, 5, 6, 7]
[1, 2, 3, 4, 5, 6, 7, 8]
[1, 2, 3, 4, 5, 6, 7, 8, 9]
[1]
slightly worse than O(n^2).. like O(n^2.1) 
rather than itterating over the entire sub array every single time, since we know that we are just adding one element to the list. we could improve the efficiency by just checking
the most recent element we added. which makes the calculation..
[1]
[2]
[3]
[4]
[5]
[6]
[7]
[8]
[9]
[1]
which makes it O(n) as well, the problem is idk how to do that. but now I can see at least it is theoretically possible
still 2 nested for loops, but together worst case they still add up to O(n)
I'm basically just recalculating the same results over and over again with 1 minor addition each time
in the root loop, I should just have the result saved and check if the new element = dominant, if so update and check otherside, otherwise add another and apply the same logic
seems feasible if I keep 2 separate variables for the count for each side / I can't just reset the variable and reuse it for both sides
1 extra int variable seems like a small price to pay for the complexity reduction
Update to this logic:
not that easy
this only works if the second half is exactly 1 element
if the second half is greater than 1 element then you also have to iterrate over that array as well to calculate the dominant value
so there isn't any way to avoid a nested for loop
however, due to how the dominant value works, it's also not possible to have a worst case that is O(n^2)
I'm sure there is a mathmatical formula that can be written to guarantee certain things, since the dominant value is guaranteed in the initial array and it must be the same in the two
sub arrays. 
Quite possible to get this to O(n) using a clever algorithm
but for now I am satisfied with my solution
it works and it isn't horribly inefficient
------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
What did I learn?
1. hashmaps are handy
    can be used as a mini object? If you just need to store 2 related data points
    in this case, tracking the number in an array as well as it's frequency
    seems quite handy
2. don't actually have to split an array to solve some of these problems
    you can just as easily iterrate through sections of an array and isolate them from the rest without physically separating the data 
    how would you solve this same problem if it required you to 'split' the array 5 times instead for example though?
    you would have like.. 6 instances of a double nested for loop?
    I guess efficiency-wise, it would still be O(n^2) at the worst? But not really because you are technically splitting the array and therefore you aren't itterating the whole array?
    there is likely an even simpler way to do the calcualtions tbh, so idk
    moral of the story is you can isolate the data without physically moving it
*/