using System;

namespace Matrix
{
    /**
    * Класс Program
    * Главный класс в котором начинается выполнеие программы 
    */
    class Program
    {
        /**
        * Точка входа в программу
        * @param {string[] args} - передаваемые аргументы
        */
        static void Main(string[] args)
        {
            matritsa();
        }
        /**
        * Создаёт матрицы
        * Вызов действий с матрицами
        */
        static void matritsa()
        {
            int[,] m1 = { { 1, 2 }, { 3, 4 } };
            int[,] m2 = { { 10, 20, 30 }, { 40, 50, 60 }, { 70, 80, 90 } };
            int[,] m3 = { { 1, 10 }, { 15, 20 } };
            vivod(1, m1, 2);
            vivod(2, m2, 3);
            vivod(3, m3, 2);
            matrix obj1 = new matrix(m1);
            matrix obj2 = new matrix(m2);
            matrix obj3 = new matrix(m3);
            Console.WriteLine("\nСложение: m1+m3");
            matrix.slogenie(obj1,obj3);
            Console.WriteLine("Сравнение: m1>m3");
            matrix.sravneniebolshe(obj1, obj3);
            Console.WriteLine("Сравнение: m1<m3");
            matrix.sravneniemenshe(obj1, obj3);
            Console.WriteLine("Сравнение: m2<m3");
            matrix.sravneniemenshe(obj2, obj3);
            Console.WriteLine("\nКопирование: m1==m2");
            matrix.copi(obj1, obj2);
            Console.WriteLine("Элемент массива m2:");
            matrix.element(ref obj2, 0, 0);
            Console.WriteLine("\nЭлемент массива m2:");
            matrix.element(ref obj2, 0, -1);
            Console.WriteLine("\nСравнение размерности матриц m2 и m3:");
            matrix.razmermatr(obj2, obj3);
            Console.WriteLine("\nСравнение размерности матриц m1 и m2:");
            matrix.razmermatr(obj1, obj2);
            Console.ReadKey();
        }
        /**
        * Вывод на экран матрицы
        * @param {int} nomer - номер матрицы
        * @param {int[,]} m - сама матрица
        * @param {int} razmer - размерность квадратной матрицы
        */
        static void vivod(int nomer,int[,]m,int razmer)
        {
            int counter = 0;
            Console.Write("\nm"+nomer + ":\n");
            foreach (int elem in m)
            {
                Console.Write(elem+" ");
                counter++;
                if (counter == razmer)
                {
                    counter = 0;
                    Console.Write("\n");
                }
            }
        }
    }
}
