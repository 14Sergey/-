using System;

namespace Наследование
{
    /**
    * Класс Minsk
    * Наследуется от класса City
    */
    public sealed class Minsk:City
    {
        public static int data_osnovania;
        /**
        * Создаёт объект класса Minsk
        * @constructor
        * @param {string} name - название Города
        * @param {int} kolvo_person - количество населения
        * @param {string} oblast - Область, в которой находится Город
        */
        public Minsk(string name, int kolvo_person,string oblast):base(name, kolvo_person,oblast)
        {}
        /**
        * Инициализирует поле data_osnovania
        * @constructor
        */
        static Minsk()
        {
            data_osnovania = 1067;
        }
        /**
        * Выводит информацию о Городе
        * @override
        */
        public override void vivod()
        {
            nomer++;
            Console.WriteLine(nomer+ ")Город Минск\nНазвание города: " + name + "\n" + oblast + " область\nГод основания: " + data_osnovania+"\nНаселение: "+kolvo_person);
        }
    }
}

