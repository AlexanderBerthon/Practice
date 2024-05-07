using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice {
    public class Palindrome {
        //given an int value, return if value is a palindrome
        //eg. value = 010    output = true
        //eg. value = 10    output = false

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