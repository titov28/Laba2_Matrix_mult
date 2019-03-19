using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleOneTest
{
    class Program
    {
        static void Main(string[] args)
        {
            OneTestObject one = new OneTestObject();

            int number = 0;
            Console.Write("Введите размер массива: ");
            one.SetMatrix(Convert.ToInt32(Console.ReadLine()));

            while (true) {
                
                Console.WriteLine("Введите номер алгоритма: ");
                Console.WriteLine("1. Стандарнтный алгоритм.");
                Console.WriteLine("2. Алгоритм Винограда.");
                Console.WriteLine("3. Модифицированный алгоритм Винограда.");
                Console.Write("Вариант: ");


                number = Convert.ToInt32(Console.ReadLine());

                switch (number)
                {
                    case 1:
                        one.StandartAlgorithm();
                        break;
                    case 2:
                        one.VinogradAlgorithm();
                        break;
                    case 3:
                        one.ModifVinogradAlgorithm();
                        break;
                }

                Console.Write("\n");
            }

            

        }
    }
}
