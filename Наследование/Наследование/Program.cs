using System;
using System.Collections.Generic;

namespace Наследование
{
    /**
    * Класс Program
    * Главный класс в котором начинается выполнеие программы 
    */
    public class Program
    {
        static string[] name = {"Брест", "Высокое", "Кавалики", "Минск"};
        static int[] kolvo_person = {1050000, 350000, 5200, 0, 2000000 };
        static string[] oblast = { "Гродненеская","Брестская", "Брестская", "Брестская", "Минская", "Брестская", "Брестская" };
        public static int key=1;
        /**
        * Точка входа в программу
        * @param {string[] args} - передаваемые аргументы
        */
        static void Main(string[] args)
        {
            Program a = new Program();
            a.Nasl(name,kolvo_person,oblast);
            Console.ReadKey();
        }
        /**
        * Создание коллекции с её элементами
        * Вызов запросов
        * Вывод на экран 
        * @param {string[]} name - массив названий
        * @param {int[]} kolvo_person - массив населения
        * @param {string[]} oblast - массив областей
        * @return {int} 0 - всё нормально, другое число - ошибка при создании объекта
        */
        public int Nasl(string[] name, int[] kolvo_person, string[] oblast)
        {
            List<Oblast> Strana = new List<Oblast>(); 
            Strana.Add(new Oblast(oblast[0], kolvo_person[0]));
            if (key == 0) return 1;
            Strana.Add(new City(name[0], kolvo_person[1], oblast[1]));
            if (key == 0) return 2;
            Strana.Add(new City(name[1], kolvo_person[2], oblast[2]));
            if (key == 0) return 3;
            Strana.Add(new Village(name[2], kolvo_person[3], oblast[3]));
            if (key == 0) return 4;
            Strana.Add(new Minsk(name[3], kolvo_person[4], oblast[4]));
            if (key == 0) return 5;
            foreach (var i in Strana)
                i.vivod();
            cityvoblasi(oblast[5], ref Strana);
            naseleniecityvoblasti(oblast[6], ref Strana);
            Mesto.kolvo_obj = Mesto.nomer;            
            Mesto.Object();            
            return 0;
        }
        /**
        * Считает количество городов в заданной области и выводит это на экран
        * @param {string} oblast - название области
        * @param {List<Oblast>} Strana - коллекция
        * @return {bool} - Города есть или нет
        */
        public bool cityvoblasi(string oblast,ref List<Oblast> Strana)
        {
            int key = 0;
            Console.WriteLine("\nГорода в области " + oblast + ":");
            foreach (var i in Strana)
            {
                if(i.oblast==oblast)
                    if(i is City || i is Minsk)
                    {
                        key = 1;
                        Console.WriteLine(i.name);
                    }    
            }
            if (key==0)
            {
                Console.WriteLine("Городов нет!");
                return false;
            }
            return true;
        }
        /**
        * Считает общее количество населения во всех городах заданной области
        * @param {string} oblast - название области
        * @param {List<Oblast>} Strana - коллекция
        * @return {int} - количество населения
        */
        public int naseleniecityvoblasti(string oblast, ref List<Oblast> Strana)
        {
            int nas = 0;
            foreach (var i in Strana)
            {
                if (i.oblast == oblast)
                    if (i is City || i is Minsk)
                        nas += i.kolvo_person; 
            }
            Console.WriteLine("\nКоличество населения в городах области "+oblast+": "+nas);
            return nas;
        }
    }
}
