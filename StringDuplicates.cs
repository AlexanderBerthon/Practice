using System;
using System.Linq;

/**
Practice Problem: "Print duplicate letters in a string"
 */
namespace Practice {
    public class StringDuplicates {
        public StringDuplicates() { }

        public void helperFunction(string input) {
            string output = "";

            for (int i = 0; i < input.Length; i++) {
                for (int j = i + 1; j < input.Length; j++) {
                    if (input.ElementAt(i) == input.ElementAt(j) && !output.Contains(input.ElementAt(i))) {
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
            test.helperFunction("mississippi"); //replace input string to whatever string you wish to test
        }
*/