using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace MatrixMultiplicationAlgorithms
{
    public class Algorithm
    {
        protected int[,] matrixA;
        protected int[,] matrixB;
        protected int[,] resultMatrix;

        public string Name { get; set; }

        public double time { get; set; } // время в секундах затраченное на выполнение алгоритма

        public Algorithm()
        {
            matrixA = null;
            matrixB = null;

            resultMatrix = null;


        }

        public void SetMatrix(int[,] m1, int[,] m2)
        {
            matrixA = m1;
            matrixB = m2;
        }

        public void SetMatrix(int size)
        {
            Random rand = new Random();

            matrixA = new int[size, size];
            matrixB = new int[size, size];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    matrixA[i, j] = rand.Next(1, 9);
                    matrixB[i, j] = rand.Next(1, 9);
                }
            }
        }

        public virtual void Calculation() { }


        public void Print()
        {
            string temp = "{0, 8}";

            Console.Write("\n");

            Console.WriteLine("Время рассчета: {0:0.0000} c", time);


            for (int i = 0; i < resultMatrix.GetUpperBound(0) + 1; i++)
            {
                for (int j = 0; j < resultMatrix.GetUpperBound(1) + 1; j++)
                {
                    Console.Write(temp , resultMatrix[i, j]);
                }
                Console.Write("\n");
            }

        }
    }
}
