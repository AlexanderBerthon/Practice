using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using System.Data.SqlClient;
/*
-------TESTING CHECKPOING-----
all checkpoints were tested with the following input

stringCompression("ababbaba", 1);

______________________________
*/



//TODO
//FIX ISSUE WHERE COUNT > 9 throws a random solution instead, could cause issues
//error here: text="ppool" k=1 ~ returns o2l? NOT POSSIBLE should return p2o2
//error here: text="aabbaa" k=2 ~ program crashes, likely bc I never tested with k=2




namespace Practice {
    public class Program {
        static void Main(string[] args) {
            int minCompressedLength = stringCompression("ababbaba", 1);
            Console.WriteLine("THE MINIMUM COMPRESSED STRING LENGTH IS: " + minCompressedLength);
        }

        static int stringCompression(string text, int k) {

            Console.WriteLine("Original String: " + text);

            List<string> split = new List<string>();

            //STEP 1: split the string into a substring array                           //would string.substring work better here?
            split.Add(text.ElementAt(0).ToString());
            for(int i = 1; i < text.Length; i++) {
                if (text.ElementAt(i).ToString() == split.Last()) {
                    split[split.Count()-1] += text.ElementAt(i);
                }
                else {
                    split.Add(text.ElementAt(i).ToString());
                }
            }


            //-----TESTING CHECKPOING-----
            //if this works, I should expect the following output -> split = [a, b, a, bb, a, b, a]
            //foreach(string s in split) {
            //    Console.Write(s+" ");
            //}
            //Console.WriteLine("\n");
            //____________________________


            int[] weights = new int[split.Count()];

            //STEP 2: weigh the options
            for(int i = 0; i<split.Count; i++) {
                if (split[i].Length > k || i == 0 || i == split.Count-1) {
                    weights[i] = 0;
                }
                else if (!split[i - 1].ElementAt(0).Equals(split[i + 1].ElementAt(0))){
                    weights[i] = 1;
                }
                else {
                    weights[i] = split[i-1].Length + split[i+1].Length;
                }
            }

            //-----TESTING CHECKPOING-----
            //if this works, I should expect the following output -> weights = [0, 2, 3, 0, 3, 2, 0]
            //foreach (int i in weights) {
            //    Console.Write(i + " ");
            //}
            //Console.WriteLine("\n");
            //____________________________


            //STEP 3: find solutions
            List<int> solutions = new List<int>();
            solutions.Add(weights[0]);
            for (int i = 0; i < k; i++) {
                for (int j = 0; j < weights.Length; j++) {
                    if (weights[j] > solutions[i] && weights[j] < 10) { //TODO:this needs work. just because a weight > 10 doesn't mean index 0 is a better solution
                        solutions[i] = j; //this gives me the index
                    }
                }
            }

            //STEP 4: delete solutions from string
            foreach(int i in solutions) {
                split[i] = null;
            }


            //-----TESTING CHECKPOING-----
            //if this works, I should expect the following output -> split = [a, b, a, bb, NULL, b, a]
            //foreach (string s in split) {
            //    Console.Write(s + " ");
            //}
            //Console.WriteLine("\n");
            //____________________________


            //STEP 5: sew the string back together
            text = "";
            foreach (string s in split) {
                if(s != null) {
                    text += s;
                }
            }


            //-----TESTING CHECKPOING-----
            //if this works, I should expect the following output -> text = ababbba
            //Console.WriteLine(text);
            //Console.WriteLine("\n");
            //____________________________


            //STEP 6: compress final string
            string compressed = "";
            int count = 1;
            //THERE IS A MUCH BETTER WAY TO WRITE THIS BUT I'M TIRED ~ I'll fix it later surely
            for(int i = 0; i<text.Length; i++) {
                if(i == text.Length - 1) {
                    if (count > 1) {
                        compressed += text.ElementAt(i) + count;
                        count = 1;
                    }
                    else {
                        compressed += text.ElementAt(i);
                        count = 1;
                    }
                }
                else if (text.ElementAt(i).Equals(text.ElementAt(i + 1))) {
                    count++;
                }
                else if (count > 1) {
                    compressed += text.ElementAt(i);
                    compressed += count;
                    count = 1;
                }
                else {
                    compressed += text.ElementAt(i);
                    count = 1;
                }
            }


            //-----TESTING CHECKPOING-----
            //if this works, I should expect the following output -> text = abab3a
            //Console.WriteLine(compressed);
            //Console.WriteLine("\n");
            //____________________________

            Console.WriteLine("Compressed String: " + compressed);


            //STEP 7: return count of compressed string ~ minimum calculated compressed length
            return compressed.Length;
        }

    }
}


/*
Palindrome test = new Palindrome();
Console.WriteLine(test.solve(10));
*/