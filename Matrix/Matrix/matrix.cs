using System;

namespace Matrix
{
    /**
    * Класс matrix
    */
    public class matrix
    {
        int[,] m;
        /**
        * Создаёт объект класса matrix
        * @constructor
        * @param {int[,]} m - матрица
        */
        public matrix(int[,] m)
        {
            this.m = m;
        }
        ~matrix()
        {
            Console.WriteLine("Матрица удалёна.");
            //Console.ReadKey();
        }
        /**
        * Складывает две матрицы
        * @param {matrix} obj1 - матрица 1
        * @param {matrix} obj2 - матрица 2
        * @return {bool} - одинаковой размерности матрицы или нет
        */
        public static bool slogenie(matrix obj1, matrix obj2)
        {
            int[,] m = new int[obj1.m.GetLength(0), obj1.m.GetLength(1)];
            matrix obj3 = new matrix(m);
            if (obj1.m.GetLength(0) == obj2.m.GetLength(0) && obj1.m.GetLength(1) == obj2.m.GetLength(1))
            {
                obj3 = obj1 + obj2;
                return true;
            }
            else
            {
                Console.WriteLine("\nДля сложения массивы должны быть одинакового размера!");
                return false;
            }
        }
        /**
        * Копирование матрицы
        * @param {matrix} obj1 - матрица 1
        * @param {matrix} obj2 - матрица 2
        * @return {cop} - матрица 1 стала копией матрицы 2
        */
        public static bool copi(matrix obj1,matrix obj2)
        {
            bool cop=obj1 == obj2;
            return cop;
        }
        /**
        * Сравнивает размерности матриц
        * @param {matrix} obj1 - матрица 1
        * @param {matrix} obj2 - матрица 2
        * @return {bool} - одинаковой размерности матрицы или нет
        */
        public static bool razmermatr(matrix obj1, matrix obj2)
        {
            bool razmer = obj1 != obj2;
            Console.WriteLine();
            return razmer;
        }
        /**
        * Сравнение матриц со знаком больше
        * @param {matrix} obj1 - матрица 1
        * @param {matrix} obj2 - матрица 2
        * @return {sravn} - матрица правдивости сравнения элементов
        */
        public static bool[,] sravneniebolshe(matrix obj1, matrix obj2)
        {
            bool[,] sravn = obj1 > obj2;
            return sravn;
        }
        /**
        * Сравнение матриц со знаком меньше
        * @param {matrix} obj1 - матрица 1
        * @param {matrix} obj2 - матрица 2
        * @return {sravn} - матрица правдивости сравнения элементов
        */
        public static bool[,] sravneniemenshe(matrix obj1, matrix obj2)
        {
            bool[,] sravn = obj1 < obj2;
            return sravn;
        }
        /**
        * получение элемента заданной матрицы
        * @param {matrix} obj1 - матрица 1
        * @param {int} x - столбец матрицы
        * @param {int} y - строка матрицы
        * @return {int} - элемент матрицы
        */
        public static int element(ref matrix obj,int x, int y)
        {
            for (int i = 0; i < (obj.m.GetLength(0)); i++)
            {
                for (int j = 0; j < (obj.m.GetLength(1)); j++)
                {
                    Console.Write(obj[i, j] + " ");
                }
                Console.WriteLine();
            }
            try
            {
                Console.WriteLine("Элемент данного массива: [" + x + "][" + y + "]=" + obj[x, y]);
                return obj[x, y];
            }
            catch
            {
                Console.WriteLine("Элементa данного массива: [" + x + "][" + y + "] не существует!");
                return -1;
            }
        }
        /**
        * перегрузка оператора +
        * @param {matrix} obj1 - матрица 1
        * @param {matrix} obj2 - матрица 2
        * @return {matrix} - полученная после сложения матрица 
        */
        public static matrix operator +(matrix obj1, matrix obj2)
        {
            int[,] m = new int[obj1.m.GetLength(0), obj1.m.GetLength(1)];
            matrix obj = new matrix(m);
            for (int i = 0; i < (m.GetLength(0)); i++)
            {
                for (int j = 0; j < (m.GetLength(1)); j++)
                {
                    m[i, j] = obj1[i, j] + obj2[i, j];
                    Console.Write(m[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            return obj;
        }
        /**
        * перегрузка оператора ==
        * @param {matrix} obj1 - матрица 1
        * @param {matrix} obj2 - матрица 2
        * @return {true} - матрица 1 стала копией матрицы 2
        */
        public static bool operator ==(matrix obj1, matrix obj2)
        {
            obj1.m=new int[obj2.m.GetLength(0), obj2.m.GetLength(1)];
            for (int i = 0; i < (obj2.m.GetLength(0)); i++)
            {
                for (int j = 0; j < (obj2.m.GetLength(1)); j++)
                {
                    obj1[i, j] = obj2[i, j];
                    Console.Write(obj1[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            return true;
        }
        /**
        * перегрузка оператора !=
        * @param {matrix} obj1 - матрица 1
        * @param {matrix} obj2 - матрица 2
        * @return {bool} - одинаковой размерности матрицы или нет
        */
        public static bool operator !=(matrix obj1, matrix obj2)
        {
            if(obj1.m.GetLength(0)==obj2.m.GetLength(0) && obj1.m.GetLength(0) == obj2.m.GetLength(1))
            {
                Console.Write("Размеры матриц совпадают.");
                return true;
            }
                
            else
            {
                Console.Write("Размеры матриц  не совпадают!");
                return false;
            }
                
        }
        /**
        * перегрузка оператора больше
        * @param {matrix} obj1 - матрица 1
        * @param {matrix} obj2 - матрица 2
        * @return {bool[,]} - матрица правдивости сравнения элементов
        */
        public static bool[,] operator >(matrix obj1, matrix obj2)
        { 
            if (obj1!=obj2)
            {
                Console.WriteLine();
                bool[,] m=new bool [obj1.m.GetLength(0), obj1.m.GetLength(1)];
                for (int i = 0; i < (obj1.m.GetLength(0)); i++)
                {
                    for (int j = 0; j < (obj1.m.GetLength(1)); j++)
                    {
                        if (obj1[i, j] > obj2[i, j])
                        {
                            Console.Write("true ");
                            m[i, j] = true;
                        }
                        else
                        {
                            Console.Write("false ");
                            m[i, j] = false;
                        }
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
                return m; 
            }
            else
            {
                Console.Write(" Поэтому нельзя их сравнивать!");
                Console.WriteLine();
                bool[,]m ={{ false }};
                return m;
            }               
        }
        /**
        * перегрузка оператора меньше
        * @param {matrix} obj1 - матрица 1
        * @param {matrix} obj2 - матрица 2
        * @return {bool[,]} - матрица правдивости сравнения элементов
        */
        public static bool[,] operator <(matrix obj1, matrix obj2)
        {
            if (obj1 != obj2)
            {
                Console.WriteLine();
                bool[,] m = new bool[obj1.m.GetLength(0), obj1.m.GetLength(1)];
                for (int i = 0; i < (obj1.m.GetLength(0)); i++)
                {
                    for (int j = 0; j < (obj1.m.GetLength(1)); j++)
                    {
                        if (obj1[i, j] < obj2[i, j])
                        {
                            Console.Write("true ");
                            m[i, j] = true;
                        }
                        else
                        {
                            Console.Write("false ");
                            m[i, j] = false;
                        }
                    }
                    Console.WriteLine();
                }
                return m;
            }
            else
            {
                Console.Write(" Поэтому нельзя их сравнивать!");
                Console.WriteLine();
                bool[,] m = { { false } };
                return m;
            }
        }
        /**
        * индексатор
        * @param {int} x - столбец матрицы
        * @param {int} y - строка матрицы
        * @return {int} - элемент матрицы
        */
        public int this[int x, int y]
        {
            get
            {
                return m[x, y];
            }
            set
            {
                m[x, y] = value;
            }
        }
    }
}
