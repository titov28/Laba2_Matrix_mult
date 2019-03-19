using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatrixMultiplicationAlgorithms;
using System.IO;

namespace ConsoleMultiTest
{

    public class MultiTestObject
    {
        StdMatrixMultiplication stdAlgorithm;
        VinogradMatrixMultiplication vinogradAlgorithm;
        ModifVinogradMatrixMultiplication modifVinogradAlgorithm;

        private int[,] matrixA;
        private int[,] matrixB;

        private double[] stdTimeEven;
        private double[] stdTimeOdd;

        private double[] vinogradTimeEven;
        private double[] vinogradTimeOdd;

        private double[] modifVinogradTimeEven;
        private double[] modifVinogradTimeOdd;

        public MultiTestObject()
        {
            stdAlgorithm = new StdMatrixMultiplication();
            vinogradAlgorithm = new VinogradMatrixMultiplication();
            modifVinogradAlgorithm = new ModifVinogradMatrixMultiplication();


            stdTimeEven = new double[10];
            stdTimeOdd = new double[10];

            vinogradTimeEven = new double[10];
            vinogradTimeOdd = new double[10];

            modifVinogradTimeEven = new double[10];
            modifVinogradTimeOdd = new double[10];
        }

        public void Calculation()
        {
            Test(stdAlgorithm, stdTimeEven, 1);
            Test(stdAlgorithm, stdTimeOdd, 0);

            Test(vinogradAlgorithm, vinogradTimeEven, 1);
            Test(vinogradAlgorithm, vinogradTimeOdd, 0);

            Test(modifVinogradAlgorithm, modifVinogradTimeEven, 1);
            Test(modifVinogradAlgorithm, modifVinogradTimeOdd, 0);

        }


        private void Test(Algorithm algorithm, double[] avgTime, int flag)
        {
            Console.WriteLine("\nНачало рассчета: {0} {1}", algorithm.Name, DateTime.Now.ToString("HH:mm:ss"));

            double[] locTime = new double[10];
            int size = 0;

            if (flag == 1)
            {
                size = 100;

                Console.WriteLine("Перемножение \"четных\" матриц");
            }
            else
            {
                size = 101;
                Console.WriteLine("Перемножение \"нечетных\" матриц");
            }

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    algorithm.SetMatrix(size);
                    algorithm.Calculation();
                    locTime[j] = algorithm.time;
                }
                avgTime[i] = AverageValue(locTime);
                size += 100;
            }

            Console.WriteLine("\nЗавершение рассчета: {0} {1}", algorithm.Name, DateTime.Now.ToString("HH:mm:ss"));

        }


        private double AverageValue(double[] time)
        {
            double temp = 0;

            for (int i = 0; i < time.Length; i++)
            {
                temp += time[i];
            }

            return temp / time.Length;

        }

        public void WriteFile()
        {
            string writePath = @"./ResultMultiTest.txt";

            using (StreamWriter streamWriter = new StreamWriter(writePath, false, System.Text.Encoding.Default))
            {
                streamWriter.WriteLine(stdAlgorithm.Name);
                streamWriter.WriteLine("Время рассчета \"четных матриц\"");

                foreach(double el in stdTimeEven)
                {
                    streamWriter.WriteLine(el);
                }

                streamWriter.WriteLine("Время рассчета \"нечетных матриц\"");
                foreach (double el in stdTimeOdd)
                {
                    streamWriter.WriteLine(el);
                }

                //=================================================

                streamWriter.WriteLine(vinogradAlgorithm.Name);
                streamWriter.WriteLine("Время рассчета \"четных матриц\"");

                foreach (double el in vinogradTimeEven)
                {
                    streamWriter.WriteLine(el);
                }

                streamWriter.WriteLine("Время рассчета \"нечетных матриц\"");
                foreach (double el in vinogradTimeOdd)
                {
                    streamWriter.WriteLine(el);
                }

                //=================================================
                streamWriter.WriteLine(modifVinogradAlgorithm.Name);
                streamWriter.WriteLine("Время рассчета \"четных матриц\"");

                foreach (double el in modifVinogradTimeEven)
                {
                    streamWriter.WriteLine(el);
                }

                streamWriter.WriteLine("Время рассчета \"нечетных матриц\"");
                foreach (double el in modifVinogradTimeOdd)
                {
                    streamWriter.WriteLine(el);
                }


            }
        }
    }
}
