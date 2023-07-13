using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Practice {
    public class Program {
        static void Main(string[] args) {
            //manage duplicates here
            List<string> strings = new List<string>();
            strings.Add("alex");
            strings.Add("rob");
            strings.Add("alex");
            strings.Add("rob");
            strings.Add("alex");
            strings.Add("rob");
            strings.Add("rob");

            List<string> temp = new List<string>();
            for (int i = 0; i < strings.Count; i++) {
                if (i == strings.Count - 1) {
                    temp.Add(strings[i]);
                    break;
                }
                for (int j = i + 1; j < strings.Count; j++) {
                    if (strings[i].Equals(strings[j])) {
                        break;
                    }
                    else if (j == strings.Count - 1) {
                        temp.Add(strings[i]);
                    }
                }
            }

            strings = temp;

            foreach(string s in strings) {
                Console.WriteLine(s);
            }
            

            /*
            Palindrome test = new Palindrome();
            Console.WriteLine(test.solve(10));
            */
        }
    }
}
