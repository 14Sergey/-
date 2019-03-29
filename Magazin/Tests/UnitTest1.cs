using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void SokDays()
        {
            Magazin.Tovar tovar = new Magazin.Tovar("Сок", 10, 10.03F);
            Assert.AreEqual(9.03F, tovar.UpdateGoods());
        }
        [TestMethod]
        public void SokDays0()
        {
            Magazin.Tovar tovar = new Magazin.Tovar("Сок", 0, 10.03F);
            Assert.AreEqual(5.01F, tovar.UpdateGoods());
        }
        [TestMethod]
        public void SokDays0Price0()
        {
            Magazin.Tovar tovar = new Magazin.Tovar("Сок", 0, 0.01F);
            Assert.AreEqual(0, tovar.UpdateGoods());
        }
        [TestMethod]
        public void Mech()
        {
            Magazin.Tovar tovar = new Magazin.Tovar("Мечь короля Артура", 10, 45F);
            Assert.AreEqual(45, tovar.UpdateGoods());
        }
        [TestMethod]
        public void MechDays0()
        {
            Magazin.Tovar tovar = new Magazin.Tovar("Мечь короля Артура", 0, 45F);
            Assert.AreEqual(45, tovar.UpdateGoods());
        }
        [TestMethod]
        public void Koniak()
        {
            Magazin.Tovar tovar = new Magazin.Tovar("Коньяк", 100, 34F);
            Assert.AreEqual(35, tovar.UpdateGoods());
        }
        [TestMethod]
        public void KoniakPrice50()
        {
            Magazin.Tovar tovar = new Magazin.Tovar("Коньяк", 100, 50F);
            Assert.AreEqual(50, tovar.UpdateGoods());
        }
        [TestMethod]
        public void koniakDays0()
        {
            Magazin.Tovar tovar = new Magazin.Tovar("Коньяк", 0, 45F);
            Assert.AreEqual(22.5F, tovar.UpdateGoods());
        }
        [TestMethod]
        public void BiletPrice50()
        {
            Magazin.Tovar tovar = new Magazin.Tovar("Билет на концерт", 1, 49F);
            Assert.AreEqual(50, tovar.UpdateGoods());
        }
        [TestMethod]
        public void BiletDays30()
        {
            Magazin.Tovar tovar = new Magazin.Tovar("Билет на концерт", 30, 20F);
            Assert.AreEqual(21, tovar.UpdateGoods());
        }
        [TestMethod]
        public void BiletDays10()
        {
            Magazin.Tovar tovar = new Magazin.Tovar("Билет на концерт", 10, 20F);
            Assert.AreEqual(22, tovar.UpdateGoods());
        }
        [TestMethod]
        public void BiletDays5()
        {
            Magazin.Tovar tovar = new Magazin.Tovar("Билет на концерт", 5, 20F);
            Assert.AreEqual(23, tovar.UpdateGoods());
        }
        [TestMethod]
        public void BiletDays0()
        {
            Magazin.Tovar tovar = new Magazin.Tovar("Билет на концерт", 0, 20F);
            Assert.AreEqual(0, tovar.UpdateGoods());
        }
    }
}
