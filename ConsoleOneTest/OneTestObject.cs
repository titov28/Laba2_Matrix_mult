using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatrixMultiplicationAlgorithms;

namespace ConsoleOneTest
{
   public class OneTestObject
    {
        StdMatrixMultiplication stdAlgorithm;
        VinogradMatrixMultiplication vinogradAlgorithm;
        ModifVinogradMatrixMultiplication modifVinogradAlgorithm;

        protected int[,] matrixA;
        protected int[,] matrixB;

        private int size;

      public OneTestObject()
        {
            stdAlgorithm = new StdMatrixMultiplication();
            vinogradAlgorithm = new VinogradMatrixMultiplication();
            modifVinogradAlgorithm = new ModifVinogradMatrixMultiplication();

            size = 0;
        }
        
        private void SetMatrixSize(int size)
        {
            this.size = size;
           // Print();
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

        public void StandartAlgorithm()
        {
            stdAlgorithm.SetMatrix(matrixA, matrixB);
            stdAlgorithm.Calculation();
            stdAlgorithm.Print();
        }


        public void VinogradAlgorithm()
        {
            vinogradAlgorithm.SetMatrix(matrixA, matrixB);
            vinogradAlgorithm.Calculation();
            vinogradAlgorithm.Print();
        }

        public void ModifVinogradAlgorithm()
        {
            modifVinogradAlgorithm.SetMatrix(matrixA, matrixB);
            modifVinogradAlgorithm.Calculation();
            modifVinogradAlgorithm.Print();
        }

        /*
        public virtual void Print()
        {
            for (int i = 0; i < matrixA.GetUpperBound(0) + 1; i++)
            {
                for (int j = 0; j < matrixA.GetUpperBound(1) + 1; j++)
                {
                    Console.Write("{0} ", matrixA[i, j]);
                }
                Console.Write("\n");
            }

            Console.Write("\n");

            for (int i = 0; i < matrixB.GetUpperBound(0) + 1; i++)
            {
                for (int j = 0; j < matrixB.GetUpperBound(1) + 1; j++)
                {
                    Console.Write("{0} ", matrixB[i, j]);
                }
                Console.Write("\n");
            }
        }
        */

    }
}
