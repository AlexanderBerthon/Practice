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


namespace Practice {
    public class Program {
        static void Main(string[] args) {
            FindStringIn2dArray test2 = new FindStringIn2dArray();
            Console.WriteLine(test2.solve());
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