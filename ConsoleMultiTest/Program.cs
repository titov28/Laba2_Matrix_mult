using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatrixMultiplicationAlgorithms;

namespace ConsoleMultiTest
{
    class Program
    {
        static void Main(string[] args)
        {
            MultiTestObject multiTestObject = new MultiTestObject();
            multiTestObject.Calculation();
            multiTestObject.WriteFile();


            Console.ReadLine();
        }
    }
}
