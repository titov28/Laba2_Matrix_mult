using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace MatrixMultiplicationAlgorithms
{
    public class StdMatrixMultiplication : Algorithm
    {
        
        public StdMatrixMultiplication(): base()
        {
            Name = "Стандартный алгоритм";
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

            //счетчик тактов
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            //Стандартный алгоритм умножения матриц
            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < Q; j++)
                {
                    for (int k = 0; k < M; k++)
                    {
                        resultMatrix[i, j] = resultMatrix[i, j] + matrixA[i, k] * matrixB[k, j];
                    }
                }
            }

            stopWatch.Stop();
            time = (double)stopWatch.ElapsedMilliseconds/1000; // запись времени в секундах
            
        }

    }
}
