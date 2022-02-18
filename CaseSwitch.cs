using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Threading;

namespace Practice {
    public class CaseSwitch {
        public CaseSwitch() { }
        /*
        Case switch supposed to be easier to read and faster
        I don't think it is easier to read
        It is 2-10x slower than the if else version and less consistent in this test. 
        This probably isn't a good speed test though, so it could potentially run way faster for all I know.
        */
        public void caseSwitchVersion() {
            Stopwatch time = Stopwatch.StartNew();
            time.Start();
            List<String> input = new List<String>();
            input.Add("red");
            input.Add("up");
            input.Add("hot");
            input.Add("day");
            input.Add("sun");
            input.Add("left");

            String opposite = "";
            foreach (String s in input) {
                switch (s) {
                    case "red": opposite = "blue"; break;
                    case "up": opposite = "down"; break;
                    case "hot": opposite = "cold"; break;
                    case "day": opposite = "night"; break;
                    case "sun": opposite = "moon"; break;
                    case "left": opposite = "right"; break;
                }
                Console.WriteLine(opposite);
            }
            time.Stop();
            Console.WriteLine("RunTime: " + time.Elapsed);
        }


        public void ifElseVersion() {
            Stopwatch time = Stopwatch.StartNew();
            time.Start();
            List<String> input = new List<String>();
            input.Add("red");
            input.Add("up");
            input.Add("hot");
            input.Add("day");
            input.Add("sun");
            input.Add("left");

            String opposite = "";
            foreach (String s in input) {
                if (s == "red")
                    opposite = "blue";
                else if (s == "up")
                    opposite = "down";
                else if (s == "day")
                    opposite = "night";
                else if (s == "sun") 
                    opposite = "moon";
                else if (s == "left") 
                    opposite = "right";
                Console.WriteLine(opposite);
            }
            time.Stop();
            Console.WriteLine("RunTime: " + time.Elapsed);
        }
    }
}
