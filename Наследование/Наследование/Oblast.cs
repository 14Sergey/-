using System;

namespace Наследование
{
    /**
    * Класс Oblast
    * Наследуется от класса Mesto
    */
    public class Oblast:Mesto
    {
        public string oblast;
        /**
        * Создаёт объект класса Oblast
        * @constructor
        * @param {string} name - название Области
        * @param {int} kolvo_person - количество населения
        */
        public Oblast(string name, int kolvo_person) :base(name,kolvo_person)
        {
            oblast = name;
        }
        /**
        * Выводит информацию об Области
        * @virtual
        */
        public virtual void vivod()
        {
            nomer++;
            Console.WriteLine(nomer+")Область\nНазвание области: " + name + "\nНаселение: " + kolvo_person);            
        }
    }
}
