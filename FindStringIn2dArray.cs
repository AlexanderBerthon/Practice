using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using System.Data.SqlClient;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Dynamic;
using static System.Net.Mime.MediaTypeNames;
using System.ComponentModel.Design;

/*
    
    Problem: 'Find string in 2d array' ?
    Given a grid of characters and a string, return true if the string exists within the data grid.
    each sequential character of the string must be adjacent to the previous character and each character
    can only be used once.
    
    //visual representation, not required for code execution
    string = mouse
    [m, o, u]       [M, O, U]
    [w, a, s] -->   [ ,  , S]
    [t, b, e]       [ ,  , E]
    
    TRUE
    
    string = muffin
    [m, i, n]      [ ,  ,  ]
    [f, n, f] -->  [ ,  , F]
    [m, u, f]      [M, U, F]

    FALSE
*/
namespace Practice {
    public class FindStringIn2dArray {

        public FindStringIn2dArray() {}

        public bool solve() {
            //create the grid
            char[][] grid;
            char[] one = { 'a', 'b', 'c' };
            char[] two = { 'd', 'e', 'f' };
            char[] three = { 'g', 'h', 'i' };
            grid = new char[][] { one, two, three };

            //initialize target
            string target = "adebcfihg";

            //result variable to return
            bool result = false;

            for (int i = 0; i < grid.Length; i++) {
                for (int j = 0; j < grid[i].Length; j++) {
                    if (grid[i][j] == target[0]) {
                        //write recursive function here
                        if (DFS(i, j, 1, "")) {
                            break;
                        }
                    }
                }
            }
            return result;


            //Depth first search 
            /*
                * This function/method attempts to find the target sequence by recursively
                * comparing the current element to each 'adjacent' element in the 2d array. 
                * 
                * This function calls itself recursively (depth first) when the next element in the sequence
                * is found in an ajacent location, until the full sequence is verified or a dead end is reached
                * after checking all available ajacent values
                * 
                * returns:
                * true - if the full sequence exists in the 2d array
                * false - if no/incomplete sequence
            */
            bool DFS(int rank, int index, int characterIndex, string previous) {
                //check left adjacent index
                if (!result) {
                    if (!previous.Equals("left")) {
                        try {
                            if (grid[rank][index - 1] == target[characterIndex]) {
                                if (characterIndex == target.Length - 1) {
                                    result = true;
                                }
                                else {
                                    DFS(rank, index - 1, characterIndex + 1, "right");
                                }
                            }
                        }
                        catch (IndexOutOfRangeException e) { } //ignore and try other adjacent option
                    }
                }
                //check right adjacent index
                if (!result) {
                    if (!previous.Equals("right")) {
                        try {
                            if (grid[rank][index + 1] == target[characterIndex]) {
                                if (characterIndex == target.Length - 1) {
                                    result = true;
                                }
                                else {
                                    DFS(rank, index + 1, characterIndex + 1, "left");
                                }
                            }
                        }
                        catch (IndexOutOfRangeException e) { } //ignore and try other adjacent option
                    }
                }
                //check top adjacent index
                if (!result) {
                    if (!previous.Equals("top")) {
                        try {
                            if (grid[rank - 1][index] == target[characterIndex]) {
                                if (characterIndex == target.Length - 1) {
                                    result = true;
                                }
                                else {
                                    DFS(rank - 1, index, characterIndex + 1, "bottom");
                                }
                            }
                        }
                        catch (IndexOutOfRangeException e) { } //ignore and try other adjacent option
                    }
                }
                //check bot adjacent index
                if (!result) {
                    if (!previous.Equals("bottom")) {
                        try {
                            if (grid[rank + 1][index] == target[characterIndex]) {
                                if (characterIndex == target.Length - 1) {
                                    result = true;
                                }
                                else {
                                    DFS(rank + 1, index, characterIndex + 1, "top");
                                }
                            }
                        }
                        catch (IndexOutOfRangeException e) { } //ignore and try other adjacent option
                    }
                }

                return result;
            }
        }
    }
}