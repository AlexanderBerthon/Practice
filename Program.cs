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

            int[] arr1 = { 1, 2, 2, 2 };
            int[] arr2 = { 2, 1, 3, 1, 1, 1, 7, 1, 2, 1 };
            int[] arr3 = { 3, 3, 3, 3, 7, 2, 2 };

            System.Console.WriteLine(MinimumIndexValidSplit.Solve(arr1));
            System.Console.WriteLine(MinimumIndexValidSplit.Solve(arr2));
            System.Console.WriteLine(MinimumIndexValidSplit.Solve(arr3));

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