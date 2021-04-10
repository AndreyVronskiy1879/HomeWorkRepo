using System;

namespace ArraysHW
{
    class Program
    {
        static void Main(string[] args)
        {
            //1.Напишите программу на C # Sharp для хранения элементов в массиве и его печати. Перейдите в редактор
            //Test Data:
            //            Введите 10 элементов в массив:
            //            элемент - 0: 1
            //элемент - 1: 1
            //элемент - 2: 2.......
            //Ожидаемый результат :
            //Элементы в массиве: 1 1 2 3 4 5 6 7 8 9

            int[] numbers = new int[10] { 1, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            foreach (int i in numbers)
            {
                Console.WriteLine(i);
            }
            Console.ReadKey();
        }
    }
}
