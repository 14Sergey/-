using System;

namespace Наследование
{
    /**
    * Класс City
    * Наследуется от класса Oblast
    */
    public class City:Oblast
    {
        /**
        * Создаёт объект класса City
        * @constructor
        * @param {string} name - название Города
        * @param {int} kolvo_person - количество населения
        * @param {string} oblast - Область, в которой находится Город
        */
        public City(string name, int kolvo_person,string oblast) : base(name, kolvo_person)
        {
            this.oblast = oblast;
        }
        /**
        * Выводит информацию о Городе
        * @override
        */
        public override void vivod()
        {
            nomer++;
            Console.WriteLine(nomer+")Город\nНазвание города: " + name + "\n"+oblast+" область\nНаселение: " + kolvo_person);
        }
    }
}
