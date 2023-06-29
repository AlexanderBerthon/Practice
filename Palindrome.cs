using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice {
    public class Palindrome {
        //given an int value, return if value is a palindrome
        //eg. value = 010    output = true
        //eg. value = 10    output = false

        //idea
        //convert to string
        //reverse string
        //compare string
        //if strings = eachother return true
        //else false

        //could do, but you have so many damn variables
        //convert int to string
        //string to char array
        //char array to stack
        //stack to reverse char array
        //reverse char array to string
        //compare string
        //just stupid to do it this way

        //better way?
        //int to string - string original
        //iterrate over string chars, add to stack 1 char at a time
        //pop chars off stack into string? 

        public Palindrome() { }

        public Boolean solve(int value) {
            Boolean result = false;
            string temp = value.ToString();
            Stack<char> stack = new Stack<char>();
            foreach (char c in temp) {
                stack.Push(c);
            }

            temp = "";

            while (stack.Count > 0) {
                temp += stack.Pop();
            }

            int reverse = int.Parse(temp);

            if (value.CompareTo(reverse) == 0) {
                result = true;
            }
            return result;
        }

    }
}
