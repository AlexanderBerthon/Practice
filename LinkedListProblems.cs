using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice {
    public class LinkedListProblems {
        public LinkedListProblems() { }

        ///problem: rotate a singly linked list n times
        public void rotate(int n) {
            LinkedList<int> test = new LinkedList<int>();

            //initialize
            for (int i = 1; i < 6; i++) {
                test.AddLast(i);
            }


            //print unedited list
            Console.WriteLine();
            foreach (int i in test) {
                Console.Write(i+" ");
            }

            //rotate 'n' number of times
            int temp = 0;
            for (int i = n; i > 0; i--) {
                temp = test.Last();
                test.RemoveLast();
                test.AddFirst(temp);
            }

            //print edited list
            Console.WriteLine();
            foreach (int j in test) {
                Console.Write(j+" ");
            }
            Console.WriteLine();

        }

    }
}
