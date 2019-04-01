using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Store.Tests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void JuiceDays()
        {
            Good tovar = new Good("Сок", 10, 10.03F);
            Assert.AreEqual(9.03F, tovar.UpdateGoods());
        }
        [TestMethod]
        public void JuiceDays0()
        {
            Good tovar = new Good("Сок", 0, 10.03F);
            Assert.AreEqual(5.01F, tovar.UpdateGoods());
        }
        [TestMethod]
        public void JuiceDays0Price0()
        {
            Good tovar = new Good("Сок", 0, 0.01F);
            Assert.AreEqual(0, tovar.UpdateGoods());
        }
        [TestMethod]
        public void Blade()
        {
            Good tovar = new Good("Мечь короля Артура", 10, 45F);
            Assert.AreEqual(45, tovar.UpdateGoods());
        }
        [TestMethod]
        public void BladeDays0()
        {
            Good tovar = new Good("Мечь короля Артура", 0, 45F);
            Assert.AreEqual(45, tovar.UpdateGoods());
        }
        [TestMethod]
        public void Koniak()
        {
            Good tovar = new Good("Коньяк", 100, 34F);
            Assert.AreEqual(35, tovar.UpdateGoods());
        }
        [TestMethod]
        public void KoniakPrice50()
        {
            Good tovar = new Good("Коньяк", 100, 50F);
            Assert.AreEqual(50, tovar.UpdateGoods());
        }
        [TestMethod]
        public void koniakDays0()
        {
            Good tovar = new Good("Коньяк", 0, 45F);
            Assert.AreEqual(22.5F, tovar.UpdateGoods());
        }
        [TestMethod]
        public void TicketPrice50()
        {
            Good tovar = new Good("Билет на концерт", 1, 49F);
            Assert.AreEqual(50, tovar.UpdateGoods());
        }
        [TestMethod]
        public void TicketDays30()
        {
            Good tovar = new Good("Билет на концерт", 30, 20F);
            Assert.AreEqual(21, tovar.UpdateGoods());
        }
        [TestMethod]
        public void TicketDays10()
        {
            Good tovar = new Good("Билет на концерт", 10, 20F);
            Assert.AreEqual(22, tovar.UpdateGoods());
        }
        [TestMethod]
        public void TicketDays5()
        {
            Good tovar = new Good("Билет на концерт", 5, 20F);
            Assert.AreEqual(23, tovar.UpdateGoods());
        }
        [TestMethod]
        public void TicketDays0()
        {
            Good tovar = new Good("Билет на концерт", 0, 20F);
            Assert.AreEqual(0, tovar.UpdateGoods());
        }
    }
}
