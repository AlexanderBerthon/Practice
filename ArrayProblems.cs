using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice {
    internal class ArrayProblems {
        ArrayProblems() { }

        //shortest path alg pretty much
        //always start at input[0]
        //values represent number of jumps
        //goal is to get to the last index with the fewest number of jumps
        //e.g. [2, 3, 0, 3, 1]
        public void jumpgame2(int[] input) {
            //check how many jumps to reach the end
            //check if current index can reach the end
            //if so, win
            //else check options
            //loop number of options # of times
            //check each option, if an option lets you move to the finish, end
            //recursive function needed..
            //how do you decide between 2 options if both options don't get you to the end?
            //pick largest number? = highest number of options? probably?
            //I think in that scenario you just pick the bigger number. doesn't matter really? or does it?
            // [5, 4, 3, 2, 1, 1, 1, 1, 1, 1, 1, 1]
            //starting at 5..
            //you can pick 4, 3, 2, or 1
            //none of them get you to the end.
            //all options get you to the same spot. bad example? 
            //[0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11]
            //[5, 4, 3, 4, 1, 1, 1, 1, 1, 1, 1, 1]
            //start --> 5 --> 6 --> 7 --> 8 --> 9 --> 10 --> 11
            //start --> 3 --> 7 --> 8 --> 9 --> 10 --> 11
            // 
            // not as simple as just picking the furthest possible
            // not as simple as just picking the largest number
            // not as simple as just picking the largest number that is the furthest along? maybe you can do a calculation?
            // maybe a 'stat weight' solution? 
            // ie, the value of the number is in part calculated by its position and also in part by the size of the number
            // so if you could pick out of the next 3 indexes...
            // there was a large number but it was at index 1
            // there was a tiny number but it was at index 3
            // there was a large number -1 but it was at index 2
            //
            // making this example real..
            // 5 4 1
            // you could pick either 5 or 4 to get the same value.
            // I think I am over thinking it a bit.
            // there is literally NO difference between 5 and 4 because they cover the same RANGE
            // i think..
            // not sure if there is any counter examples out there, but I think this is fine since it is range based and not node based (locked in)
            // so no need for shortest path algorithm
            // just a weighted algorithm
            // based on position and size
            // so... example from the top again
            // calculate the value of each move
            //
            //[0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11]
            //[5, 4, 3, 4, 1, 1, 1, 1, 1, 1, 1, 1]
            //option 1 = (4 + 1) = 5
            //option 2 = (2 + 3) = 5
            //option 3 = (3 + 4) = 7
            //option 4 = (4 + 1) = 5
            //option 5 = (5 + 1) = 6
            // pick the option with the highest value
            // test this on the other examples..
            //
            //
            // 0 1 2 3 4
            // 2 3 1 1 4
            //
            //
            //
            // 0 1 2 3 4
            // 2 3 0 1 4




        }


    }
}
