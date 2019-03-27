using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testsm
{
    [TestClass]
    public class UnitTest1
    {
        static int[,] m1 = { { 1, 2 }, { 3, 4 } };
        static int[,] m2 = { { 10, 20, 30 }, { 40, 50, 60 }, { 70, 80, 90 } };
        static int[,] m3 = { { 1, 10 }, { 15, 20 } };
        Matrix.matrix obj1 = new Matrix.matrix(m1);
        Matrix.matrix obj2 = new Matrix.matrix(m2);
        Matrix.matrix obj3 = new Matrix.matrix(m3);
        [TestMethod]
        public void Slogenie1()
        {
            bool rez=Matrix.matrix.slogenie(obj1, obj3);
            Assert.AreEqual(rez, true);
        }
        [TestMethod]
        public void Slogenie2()
        {
            bool rez = Matrix.matrix.slogenie(obj1, obj2);
            Assert.AreEqual(rez, false);
        }
        [TestMethod]
        public void Razmer1()
        {
            bool rez = Matrix.matrix.razmermatr(obj1, obj3);
            Assert.AreEqual(rez, true);
        }
        [TestMethod]
        public void Razmer2()
        {
            bool rez = Matrix.matrix.razmermatr(obj1, obj2);
            Assert.AreEqual(rez, false);
        }
        [TestMethod]
        public void SravnenieBolshe1()
        {
            bool[] otv = {false,false,false,false};
            bool [,]rez = Matrix.matrix.sravneniebolshe(obj1, obj3);
            int i = 0;
            foreach(bool elem in rez)
            {
                Assert.AreEqual(elem, otv[i]);
                i++;
            }
        }
        [TestMethod]
        public void SravnenieBolshe2()
        {
            bool[] otv = {false};
            bool[,] rez = Matrix.matrix.sravneniebolshe(obj1, obj2);
            int i = 0;
            foreach (bool elem in rez)
            {
                Assert.AreEqual(elem, otv[i]);
                i++;
            }
        }
        [TestMethod]
        public void SravnenieMenshe1()
        {
            bool[] otv = { false, true, true, true };
            bool[,] rez = Matrix.matrix.sravneniemenshe(obj1, obj3);
            int i = 0;
            foreach (bool elem in rez)
            {
                Assert.AreEqual(elem, otv[i]);
                i++;
            }
        }
        [TestMethod]
        public void SravnenieMenshe2()
        {
            bool[] otv = { false };
            bool[,] rez = Matrix.matrix.sravneniemenshe(obj1, obj2);
            int i = 0;
            foreach (bool elem in rez)
            {
                Assert.AreEqual(elem, otv[i]);
                i++;
            }
        }
        [TestMethod]
        public void Element1()
        {
            int rez = Matrix.matrix.element(ref obj1, 0, 0);
            Assert.AreEqual(rez, 1);
        }
        [TestMethod]
        public void Element2()
        {
            int rez = Matrix.matrix.element(ref obj1, 5, 0);
            Assert.AreEqual(rez, -1);
        }
        [TestMethod]
        public void Element3()
        {
            int rez = Matrix.matrix.element(ref obj1, 0, -1);
            Assert.AreEqual(rez, -1);
        }
    }
}
