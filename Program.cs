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

            sortByCustomMapping test = new sortByCustomMapping();
            test.solve();

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