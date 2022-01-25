using System;
using System.Linq;

/**
Practice Problem: "Print duplicate letters in a string"

Assumptions: print letters that were repeated.
             no addittional instructions on how to format output
                 only list repeated letters once?
                 count how many times a letter was repeated? 

basic solution
words that repeat letters more than twice get weird
"hehehe" or "mississippi" for example
can adapt solution to account for these as needed in part 2:
 */
namespace Practice {
    public class StringDuplicates {
        public StringDuplicates() { }

        public void helperFunction(string input) {
            string output = "";

            for (int i = 0; i < input.Length; i++) {
                for (int j = i + 1; j < input.Length; j++) {
                    if (input.ElementAt(i) == input.ElementAt(j)) {
                        output += input.ElementAt(i) + " ";
                    }
                }
            }
            Console.WriteLine(output);
        }
    }
}

//paste this in Program.cs to test
/*
static void Main(string[] args) {
            StringDuplicates test = new StringDuplicates();
            test.helperFunction("veggie"); //replace input string to whatever string you wish to test
        }
*/