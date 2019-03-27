using System;

namespace Наследование
{
    /**
    * Класс Village
    * Наследуется от класса Oblast
    */
    public class Village:Oblast
    {
        /**
        * Создаёт объект класса Village
        * @constructor
        * @param {string} name - название Деревни
        * @param {int} kolvo_person - количество населения
        * @param {string} oblast - Область, в которой находится Деревня
        */
        public Village(string name, int kolvo_person, string oblast) : base(name, kolvo_person)
        {
            this.oblast = oblast;
        }
        /**
        * Выводит информацию об Деревни
        * @override
        */
        public override void vivod()
        {
            nomer++;
            Console.WriteLine(nomer+")Деревня\nНазвание деревни: " + name + "\nНаселение: " + kolvo_person);
        }
    }
}
