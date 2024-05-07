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
TODO
 - fix backtracking issue
    - abababababababababababababa works
 - change test cases / break it
*/

namespace Practice {
    public class Program {
    static void Main(string[] args) {
        //create the grid
        char[][] grid;
        char[] one   = { 'a', 'b', 'c' };
        char[] two   = { 'd', 'e', 'f' };
        char[] three = { 'g', 'h', 'i' };
        grid = new char[][] { one, two, three };

        //initialize target
        string target = "aei";

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
        Console.WriteLine(result);
        //end of runnable program


        //Depth first search 
        /*
            * This function/method attempts to find the next character in the target sequence by 
            * comparing it to each of the 4 potential 'adjacent' elements in the 2d array. 
            * 
            * This function calls itself recursively (depth first) until the end of the sequence
            * is found or until all possible solutions have been checked
            * 
            * returns:
            * true - if a solution exists
            * false - if no solution
        */
        bool DFS(int rank, int index, int characterIndex, string previous) {
                Console.WriteLine(grid[rank][index]);
            //left adjacent index
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
            //right adjacent index
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
            //top adjacent index
            if (!result) {
                    if (!previous.Equals("top")){
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
            //bot adjacent index
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
    /*
        //good reference, not needed for this project
        public class Point{
            int i = 0;
            int j = 0;

            int geti() {
                return i;
            }
            int getj() {
                return j;
            }

            //constructor
            public Point(int i, int j) {
                this.i = i;
                this.j = j;
            }
        }
    */


//class libarary basically collection of these extra functions and classes like Point that you just made
//the purpose of them is to save time, so you don't have to write a Point class in every project

//so.. I should be able to store all of the grid data into a 2d array and reference it 
//like this.. array[a][b] where a = which array it is and b = the index 
//
//can I find a character in the array and then return it's index?
//
//what is depth first search?

//I think I have to write custom functions to search


