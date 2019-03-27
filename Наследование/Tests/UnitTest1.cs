using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        Наследование.Program a = new Наследование.Program();
        string[] name = { "Брест", "Высокое", "Кавалики", "Минск" };
        [TestMethod]
        public void AddCollection1()
        {
            
            int[] kolvo_person = { 1050000, 350000, 5200, 102, 2000000 };
            string[] oblast = { "Гродненеская", "Брестская", "Брестская", "Брестская", "Минская", "Минская", "Брестская" };
            int rez=a.Nasl(name, kolvo_person, oblast);
            Assert.AreEqual(rez, 0);
        }
        [TestMethod]
        public void AddCollection2()
        {
            int[] kolvo_person = { 0, 0, 0, 0, 0 };
            string[] oblast = { "Гродненеская", "Брестская", "Брестская", "Брестская", "Минская", "Минская", "Брестская" };
            int rez = a.Nasl(name, kolvo_person, oblast);
            Assert.AreEqual(rez, 0);
        }
        [TestMethod]
        public void AddCollection3()
        {
            int[] kolvo_person = { -1050000, 350000, 5200, 102, 2000000 };
            string[] oblast = { "Гродненеская", "Брестская", "Брестская", "Брестская", "Минская", "Минская", "Брестская" };
            int rez = a.Nasl(name, kolvo_person, oblast);
            Assert.AreEqual(rez, 1);
        }
        [TestMethod]
        public void CityVOblasti1()
        {
            int[] kolvo_person = { 1050000, 350000, 5200, 102, 2000000 };
            string[] oblast = { "Гродненеская", "Брестская", "Брестская", "Брестская", "Минская", "Брестская", "Брестская" };
            List<Наследование.Oblast> Strana = new List<Наследование.Oblast>();
            Strana.Add(new Наследование.Oblast(oblast[0], kolvo_person[0]));
            Strana.Add(new Наследование.City(name[0], kolvo_person[1], oblast[1]));
            Strana.Add(new Наследование.City(name[1], kolvo_person[2], oblast[2]));
            Strana.Add(new Наследование.Village(name[2], kolvo_person[3], oblast[3]));
            Strana.Add(new Наследование.Minsk(name[3], kolvo_person[4], oblast[4]));
            bool rez = a.cityvoblasi(oblast[5], ref Strana);
            Assert.AreEqual(rez, true);
        }
        [TestMethod]
        public void CityVOblasti2()
        {
            int[] kolvo_person = { 1050000, 350000, 5200, 102, 2000000 };
            string[] oblast = { "Гродненеская", "Брестская", "Брестская", "Брестская", "Минская", "Гродненская", "Брестская" };
            List<Наследование.Oblast> Strana = new List<Наследование.Oblast>();
            Strana.Add(new Наследование.Oblast(oblast[0], kolvo_person[0]));
            Strana.Add(new Наследование.City(name[0], kolvo_person[1], oblast[1]));
            Strana.Add(new Наследование.City(name[1], kolvo_person[2], oblast[2]));
            Strana.Add(new Наследование.Village(name[2], kolvo_person[3], oblast[3]));
            Strana.Add(new Наследование.Minsk(name[3], kolvo_person[4], oblast[4]));
            bool rez = a.cityvoblasi(oblast[5], ref Strana);
            Assert.AreEqual(rez, false);
        }
        [TestMethod]
        public void NaselenieCityVOblasti1()
        {
            int[] kolvo_person = { 1050000, 350000, 5200, 102, 2000000 };
            string[] oblast = { "Гродненеская", "Брестская", "Брестская", "Брестская", "Минская", "Брестская", "Гродненская" };
            List<Наследование.Oblast> Strana = new List<Наследование.Oblast>();
            Strana.Add(new Наследование.Oblast(oblast[0], kolvo_person[0]));
            Strana.Add(new Наследование.City(name[0], kolvo_person[1], oblast[1]));
            Strana.Add(new Наследование.City(name[1], kolvo_person[2], oblast[2]));
            Strana.Add(new Наследование.Village(name[2], kolvo_person[3], oblast[3]));
            Strana.Add(new Наследование.Minsk(name[3], kolvo_person[4], oblast[4]));
            int rez = a.naseleniecityvoblasti(oblast[6], ref Strana);
            Assert.AreEqual(rez, 0);
        }
        [TestMethod]
        public void NaselenieCityVOblasti2()
        {
            int[] kolvo_person = { 1050000, 350000, 5200, 102, 2000000 };
            string[] oblast = { "Гродненеская", "Брестская", "Брестская", "Брестская", "Минская", "Брестская", "Брестская" };
            List<Наследование.Oblast> Strana = new List<Наследование.Oblast>();
            Strana.Add(new Наследование.Oblast(oblast[0], kolvo_person[0]));
            Strana.Add(new Наследование.City(name[0], kolvo_person[1], oblast[1]));
            Strana.Add(new Наследование.City(name[1], kolvo_person[2], oblast[2]));
            Strana.Add(new Наследование.Village(name[2], kolvo_person[3], oblast[3]));
            Strana.Add(new Наследование.Minsk(name[3], kolvo_person[4], oblast[4]));
            int rez = a.naseleniecityvoblasti(oblast[6], ref Strana);
            Assert.AreEqual(rez, 355200);
        }
    }
}
