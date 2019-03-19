using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace MatrixMultiplicationAlgorithms
{
    public class VinogradMatrixMultiplication : Algorithm
    {

        public VinogradMatrixMultiplication() : base()
        {
            Name = "Алгоритм Винограда";
        }

        public override void Calculation()
        {
            if (matrixA == null | matrixB == null)
                return;

            //размер resultMatrix 
            int M = matrixA.GetUpperBound(0) + 1;
            int Q = matrixB.GetUpperBound(1) + 1;



            //инициализация массива resultMatrix
            resultMatrix = new int[M, Q];

            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < Q; j++)
                {
                    resultMatrix[i, j] = 0;
                }
            }

            //Инициализация массивов rowFactors и columnFactors
            int[] rowFactors = new int[M];
            int[] columnFactors = new int[Q];

            for (int i = 0; i < M; i++)
            {
                rowFactors[i] = 0;
            }

            for (int j = 0; j < Q; j++)
            {
                columnFactors[j] = 0;
            }

            int N = (matrixA.GetUpperBound(1) + 1);


            //счетчик тактов
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            //вычисление rowFactors и columnFactors
            for (int i = 0; i < M; i++)
            {
                rowFactors[i] = matrixA[i, 0] * matrixA[i, 1];
                for (int j = 1; j < N / 2; j++)
                {
                    rowFactors[i] = rowFactors[i] + (matrixA[i, 2 * j + 1] * matrixA[i, 2 * j]);
                }
            }

            for (int i = 0; i < Q; i++)
            {
                columnFactors[i] = matrixB[0, i] * matrixB[1, i];
                for (int j = 1; j < N / 2; j++)
                {
                    columnFactors[i] = columnFactors[i] + (matrixB[2 * j + 1, i] * matrixB[2 * j, i]);
                }
            }
            

            // вычисление матрицы resultMatrix

            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < Q; j++)
                {
                    resultMatrix[i, j] =  -rowFactors[i] - columnFactors[j];

                    for (int k = 0; k < N / 2; k++)
                    {
                        resultMatrix[i, j] = resultMatrix[i, j] + (matrixA[i, 2 * k + 1] + matrixB[2 * k, j])
                            * (matrixA[i, 2 * k] + matrixB[2 * k + 1, j]);
                    }
                }
            }

            if (N % 2 == 1)
            {
                for (int i = 0; i < M; i++)
                {
                    for (int j = 0; j < Q; j++)
                    {
                        resultMatrix[i, j] = resultMatrix[i, j] + (matrixA[i, N - 1] * matrixB[N - 1, j]);
                    }
                }
            }

            stopWatch.Stop();
            time = (double)stopWatch.ElapsedMilliseconds / 1000; // запись времени в секундах

        }

    }
}
