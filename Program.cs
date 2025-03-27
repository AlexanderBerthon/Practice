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
using System.Runtime.CompilerServices;
using System.Globalization;

namespace Practice {
    public class Program {
        static void Main(string[] args) {
            System.Console.WriteLine(FizzBuzz.Solve(34));
            System.Console.WriteLine(FizzBuzz.Solve(0));
            System.Console.WriteLine(FizzBuzz.Solve(5));
            System.Console.WriteLine(FizzBuzz.Solve(6));
            System.Console.WriteLine(FizzBuzz.Solve(15));

        }
    }
}


/*
Program Guide
 1. write solution in separate c# class file
 2. add file to project
  - project
  - add existing file (select file)
 3. declare class and call function to run
*/