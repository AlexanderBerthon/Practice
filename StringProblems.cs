using System;
using System.Linq;
using System.Collections;

namespace Practice {
    public class StringProblems {
        public StringProblems() { }

        //"Print duplicate letters in a string"
        /*
        notes:
        Iterate through string and compare each letter to the rest
        
        left to right, don't have to compare backwards if that makes sense.
        
        letters that match get added to the output, check output string so the same letter isn't included



        //input: "mississippi"
        //expected output: "i s p"

        //paste this in Program.cs to test
        static void Main(string[] args) {
            StringProblems test = new StringProblems();
            test.printDuplicates("mississippi"); //replace input string to whatever string you wish to test
        }
        */
        public void printDuplicates(string input) {
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

        //"Print the first duplicate letter in a string"
        /*
        Notes:
        Mostly the same code as above but end early
        break;?
        how does break work in c#?
        works, but not sure if I could do the breaks in a better way. 



        //input: "mississippi"
        //expected output: "i"

        //paste this in Program.cs to test
        static void Main(string[] args) {
                    StringProblems test = new StringProblems();
                    test.firstDuplicate("mississippi"); //replace input string to whatever string you wish to test
        }
        */
        public void firstDuplicate(string input) {
            Boolean done = false;
            for (int i = 0; i < input.Length; i++) {
                for (int j = i + 1; j < input.Length; j++) {
                    if (input.ElementAt(i) == input.ElementAt(j)) {
                        Console.WriteLine(input.ElementAt(i));
                        done = true;
                        break;
                    }
                }
                if (done) {
                    break;
                }
            }
        }

        //"Print the first NON-duplicate letter in a string"
        /*
        Notes:
        basically exactly the same as above, just change the exit condition. 
        what do you do if all letters are repeated? return empty string? return error? 
        take this example. aabb
            - first a is seen as a duplicate
            - second a only checks to the right, sees only bb. thinks a is non-duplicate 
        Need to check EVERY entry for every letter.
        If I check every entry and compare to a single entry. the same character will ALWAYS be checked
        program will think that every string contains a duplicate.
        probably going to have to make a subarray..
        remove the character to be compared
        compare it to the sub array
        then put it back in
        hmm
        how does that affect length and size?
        how do you put the character back in the same exact spot? 
        does that even matter? 
        do I have to even put it back in? or can I just 'reset' after each attempt
        just use the original input
        I feel like there is a compare function for strings that I can utilize..
        how do you remove a single character from a string? substring starts at index..
        temp = input.substring(0,i)+input.substring(i,input.length);??? //this wont work
        aaab
        ab
        aabb 
        use string.remove //this function returns a substring with the given index removed. perfect
        victory
        I feel like I might have overthought this solution a bit, but it works. 



        //input: "aaab"
        //expected output: "b"

        //paste this in Program.cs to test
        static void Main(string[] args) {
                    StringProblems test = new StringProblems();
                    test.firstNonDuplicate("aaab"); //replace input string to whatever string you wish to test
        }
        */
        public void firstNonDuplicate(string input) {
            Boolean duplicateFound;
            String substring = "";
            String output = "The string: " + input + " does not contain a non-duplicate character";
            for (int i = 0; i < input.Length; i++) {
                duplicateFound = false;
                substring = "" + input.Remove(i, 1);
                for (int j = 0; j < substring.Length; j++) {
                    if (input.ElementAt(i) == substring.ElementAt(j)) {
                        duplicateFound = true; //duplicate
                    }
                }
                if (!duplicateFound) {
                    output = "" + input.ElementAt(i);
                    break;
                }
            }
            Console.WriteLine(output);
        }

        //"Check if two strings are mirrored"
        /*
        example
        input1: dog
        input2: god
        true
        
        notes:
        reverse second string and check if .equals?

        can improve efficiency too by first checking if the lengths of the two strings are equal
        if they aren't, you don't need to do any work. just return false. 

        this also lets me save memory. I can replace the data from input2 instead of making a separate
        variable to hold the reversed version.
        
        normally I wouldn't be able to change the data of input2 because I use input2.length as an exit
        condition for the for loop. But since I already checked that input1.length and input2.length are equal
        I can use it in it's place. Without having to store length in a int variable of course. 
        
        very very minor efficiency and resource gain. But it is still an improvement at no cost. 

        ***UPDATE***
        Turns out there is literally a string function called .reverse.... just use that?


        
        //input: "abcd", "dcba"
        //expected output: true

        //paste this in Program.cs to test
        static void Main(string[] args) {
                    StringProblems test = new StringProblems();
                    test.mirrorCheck("abcd", "dcba"); //replace input string to whatever string you wish to test
        }
        */
        public void mirrorCheck(string input1, string input2) {
            Boolean result = false;
            //check if lengths are equal, easy check and O(1) for strings that are obviously not anagrams
            if (input1.Length == input2.Length) {
                //reverse input2
                Stack reverse = new Stack();
                for (int i = 0; i < input2.Length; i++) {
                    reverse.Push(input2.ElementAt(i));
                }
                input2 = "";
                for (int i = 0; i < input1.Length; i++) { //I can use input1.Length here because I already checked that the original input2.Length and input1.Length are the same
                    input2 += reverse.Pop(); //override input2 value to save a variable declaration / memory
                }
                if (input1.Equals(input2)) {
                    result = true;
                }
                else {
                    result = false; //redundant, but makes the logic clear/complete. 
                }
            }
            else {
                result = false; //redundant, but makes the logic clear/complete.
            }
            Console.WriteLine(result);
        }

        //"Check if two strings are anagrams"
        /*
        notes:
        check length first. the two inputs must be the same length in order to be anagrams. 
        I think the easiest way is to just cheat
        don't try to create every possible combination and check each against the second input
        just tally up each letter for both inputs and compare that. break them both down into data
        eg
        input1: dormitory 
        d,1
        o,2
        r,2
        m,1
        i,1
        t,1
        y,1
        input2: dirtyroom
        d,1
        o,2
        r,2
        m,1
        i,1
        t,1
        y,1
        they match, therefore it is an anagram.
        what if I use the string.remove function?
        go letter by letter, and only have to iterate through the list once rather than creating
        a bunch of data arrays to compare to eachother?
        eg
        input1: dormitory
        input2: dirtyroom
        iterate through input2..
        does input 1 have a d?
        if yes, input1.remove(d)
        if no, break;
        does input1 have an i?
        if yest input1.remove(i)
        if no, break;
        etc.
        bonus of not having to run through whole process if bad match. 

        I can account for whitespace as needed, if "dormitory" and "dirty room" is more appealing

        Am I overthinking it again? 
        Can't I just sort them both and .equals? 

        basically just sort and filter the input
        and compare them
        thats it

        depending on the situation, it might be more efficient to do the search and destroy method.
        say if you were checking thousands of strings per day and most of them turned out to be false.
        then you have the potential to save time

        with the sorting method, you just sort both then check, all the work is done up front and no
        chance to bail halfway through

        I'll implement the sorting method, because it is a lot simpler, cleaner, and practical solution. 
        However, the other method is a good niche solution

        //input: "dormitory", "dirtyroom"
        //expected output: true

        //paste this in Program.cs to test
        static void Main(string[] args) {
                    StringProblems test = new StringProblems();
                    test.anogramCheck("abcd", "dcba"); //replace input string to whatever string you wish to test
        }
        */
        public void anagramCheck(string input1, string input2) {
            Boolean result = false;
            input1 = input1.Replace(" ", "");
            input2 = input2.Replace(" ", "");

            //lazy check
            if (input1.Length == input2.Length) {
                input1 = String.Concat(input1.OrderBy(c => c)).ToLower(); //LINQ, this is 100% cheating
                input2 = String.Concat(input2.OrderBy(c => c)).ToLower();

                if (input1.Equals(input2)) {
                    result = true;
                }
                else {
                    result = false; //redundant but clean logic
                }
            }
            else {
                result = false; //redundant but clean logic
            }
            Console.WriteLine(result);
        }

        //"Reverse a string using recursion"
        /*
        Notes:
        Simply notate the last character of the string and call the function again with input.last removed

        not sure if I am stupid or the question is stupid.
        you only want to use recursion in cases where it makes sense to use it
        I don't think using recursion to reverse a string is really necessary
        I am basically using recursion as a glorified loop here
        so either there is a better way to recursively solve this problem / I am using recursion wrong
        or
        this isn't a good problem for recursion, therefore it IS just a glorified loop
        
        there are plenty of good solutions to reverse a string, so using recursion is kind of unnecessary? 
        overkill?


        //input: "dog"
        //expected output: "god"

        //paste this in Program.cs to test
        static void Main(string[] args) {
                    StringProblems test = new StringProblems();
                    test.recursiveReverse("dog"); //replace input string to whatever string you wish to test
        }
        */
        public void recursiveReverse(string input1) {
            if (input1.Length > 0) {
                Console.Write(input1.Last());
                recursiveReverse(input1.Remove(input1.Length - 1));
            }
            else {
                Console.WriteLine();
            }
        }

        //"Check if a string contains only int values"
        /*
        Notes:
        iterate through the input string and compare character to comperator. 
        
        if(string[i] != int value)
            break;

        or just try to cast the string as an int and catch the error?

        maybe this is considered cheating, but it solves the problem in no time.



        //input: "12"
        //expected output: "Input: 12 contains only int values."

        //paste this in Program.cs to test
        static void Main(string[] args) {
                    StringProblems test = new StringProblems();
                    test.intCheck("mississippi"); //replace input string to whatever string you wish to test
        }
        */
        public void intCheck(string input1){
            try {
                int test = int.Parse(input1);
                Console.WriteLine("Input: "+input1+" contains only int values.");
            }
            catch(FormatException e) {
                Console.WriteLine("Input contains a non-int value");
            }
        }


        /// Given an integer, convert it to Roman Numeral
        /// a
        /// Write the roman numeral character with the largest character first followed by the smaller characters
        /// greatest common denominator?
        /// 1       = I
        /// 5       = V
        /// 10      = X
        /// 11      = X + I ~ XI rather than VVI (if that makes sense)
        /// 15      = XV
        /// 20      = XX
        /// 30      = XXX
        /// 40      = XXXX
        /// 50      = L
        /// 100     = C
        /// 500     = D
        /// 1000    = M
        /// 
        /// EXCEPTIONS (hard coded)
        /// 4 - IV
        /// 9 - IX
        /// 40 - XL
        /// 90 - XC
        /// 400 - CD
        /// 900 - CM
        /// 

        //problem can be solved with % ? 
        //largest to smallest? 
        //so check 6 exception cases first
        //else divide and % 1000, if division returns a whole number, add an M : subtract? or set input = remainder?
        //else divide and % 500, if division returns a whole number, add an D
        //else divide and % 100, if division returns a whole number, add an C
        //else divide and % 50, if division returns a whole number, add an L
        //else divide and % 10, if division returns a whole number, add an X
        //else divide and % 5, if division returns a whole number, add an V
        //else divide and % 1, if division returns a whole number, add an I

        //2022
        //MMXXII
        //2222
        //MMCCXXII
        public void intToRoman(int input) {
            String solution = "";
            int storage = 0;
            if(input == 4) {
                solution = "IV";
            }
            else if(input == 9) {
                solution = "IX";
            }
            else if(input == 40) {
                solution = "XL";
            }
            else if(input == 90) {
                solution = "XC";
            }
            else if(input == 400) {
                solution = "CD";
            }
            else if (input == 900) {
                solution = "CM";
            }
            else {
                storage = input / 1000;
                if(storage > 0) {
                    for(int i = storage; i>0; i--) {
                        solution+="M";
                    }
                    input = input % 1000;
                }

                storage = input / 500;
                if (storage > 0) {
                    for (int i = storage; i > 0; i--) {
                        solution += "D";
                    }
                    input = input % 500;
                }

                storage = input / 100;
                if (storage > 0) {
                    for (int i = storage; i > 0; i--) {
                        solution += "C";
                    }
                    input = input % 100;
                }

                storage = input / 50;
                if (storage > 0) {
                    for (int i = storage; i > 0; i--) {
                        solution += "L";
                    }
                    input = input % 50;
                }

                storage = input / 10;
                if (storage > 0) {
                    for (int i = storage; i > 0; i--) {
                        solution += "X";
                    }
                    input = input % 10;
                }

                storage = input / 5;
                if (storage > 0) {
                    for (int i = storage; i > 0; i--) {
                        solution += "V";
                    }
                    input = input % 5;
                }

                storage = input / 1;
                if (storage > 0) {
                    for (int i = storage; i > 0; i--) {
                        solution += "I";
                    }
                    input = input % 1;
                }
            }
            Console.WriteLine(solution);
        }
    }
}