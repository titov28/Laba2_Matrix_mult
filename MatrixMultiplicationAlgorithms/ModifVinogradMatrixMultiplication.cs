using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace MatrixMultiplicationAlgorithms
{
    public class ModifVinogradMatrixMultiplication : Algorithm
    {
        public ModifVinogradMatrixMultiplication() : base()
        {
            Name = "Модифицированный алгоритм Винограда";
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

            int buf = 0;

            //счетчик тактов
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            //вычисление rowFactors и columnFactors
            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < N - 1 ; j += 2)
                {
                    rowFactors[i] += (matrixA[i, j + 1] * matrixA[i, j]);
                }
            }

            for (int i = 0; i < Q; i++)
            {
                for (int j = 0; j < N - 1; j += 2)
                {
                    columnFactors[i] += (matrixB[j + 1, i] * matrixB[j, i]);
                }
            }


            // вычисление матрицы resultMatrix

            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < Q; j++)
                {
                    buf = -rowFactors[i] - columnFactors[j];

                    for (int k = 0; k < N - 1; k += 2)
                    {
                        buf += (matrixA[i, k + 1] + matrixB[k, j])
                            * (matrixA[i, k] + matrixB[k + 1, j]);
                    }
                    resultMatrix[i, j] = buf;
                    buf = 0;
                }
            }

            if (N % 2 == 1)
            {
                for (int i = 0; i < M; i++)
                {
                    for (int j = 0; j < Q; j++)
                    {
                        resultMatrix[i, j] += (matrixA[i, N - 1] * matrixB[N - 1, j]);
                    }
                }
            }

            stopWatch.Stop();
            time = (double)stopWatch.ElapsedMilliseconds / 1000; // запись времени в секундах

        }
    }
}
