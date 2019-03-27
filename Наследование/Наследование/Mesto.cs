using System;

namespace Наследование
{
    /**
    * Абстрактный Класс Mesto
    */
    public abstract class Mesto
    {
        public string name;
        public int kolvo_person;
        public static int kolvo_obj;
        public static int nomer=0;
        public int Kolvo_person
        {
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Население не может быть отрицательным!\n");
                    Program.key = 0;
                }
                else
                    kolvo_person = value;
            }
            get
            {
                return kolvo_person;
            }
        }
        /**
        * Создаёт объект класса Mesto
        * @constructor
        * @param {string} name - название места
        * @param {int} kolvo_person - количество населения
        */
        public Mesto(string name,int kolvo_person)
        {
            this.name = name;
            Kolvo_person = kolvo_person;
        }
        /**
        * Создаёт объект класса Mesto
        * @constructor
        */
        public Mesto()
        {
            name = "Имя";
            kolvo_person = 0;
        }
        /**
        * Выводит на экран количество объектов в коллекции
        */
        public static void Object()
        {
            Console.WriteLine("\nОбъектов: "+kolvo_obj);
        }        
    }
}
