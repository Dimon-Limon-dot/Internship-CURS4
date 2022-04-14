using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlatinumInform;
using System;

namespace ModulTests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void TC1()
        {
            bool IsTrue = ClassTests.DeleteProduct(23);
            Assert.AreEqual(true, IsTrue);
        }

        [TestMethod]
        public void TC2()
        {
            bool IsFalse = ClassTests.DeleteProduct(0);
            Assert.AreEqual(false, IsFalse);
        }

        [TestMethod]
        public void TC3()
        {
            bool IsTrue = ClassTests.AddProduct(25, 1001, "4097", 25, "Example", 1);
            Assert.AreEqual(true, IsTrue);
        }

        [TestMethod]
        public void TC4()
        {
            bool IsFalse = ClassTests.AddProduct(25, 1001, "4097а", 25, "Example", 1);
            Assert.AreEqual(false, IsFalse);
        }

        [TestMethod]
        public void TC5()
        {
            bool IsTrue = ClassTests.DeleteProduct(11);
            Assert.AreEqual(true, IsTrue);
        }

        [TestMethod]
        public void TC6()
        {
            bool IsFalse = ClassTests.DeleteProduct(0);
            Assert.AreEqual(false, IsFalse);
        }

        [TestMethod]
        public void TC7()
        {
            bool IsTrue = ClassTests.SearchProductName("Рама");
            Assert.AreEqual(true, IsTrue);
        }

        [TestMethod]
        public void TC8()
        {
            bool IsFalse = ClassTests.SearchProductName("Рамач");
            Assert.AreEqual(false, IsFalse);
        }

        [TestMethod]
        public void TC9()
        {
            bool IsTrue = ClassTests.SearchProductDep(1);
            Assert.AreEqual(true, IsTrue);
        }

        [TestMethod]
        public void TC10()
        {
            bool IsTrue = ClassTests.SearchProductAll("Рама",3);
            Assert.AreEqual(true, IsTrue);
        }

        [TestMethod]
        public void TC11()
        {
            bool IsFalse = ClassTests.SearchProductAll("Рама2", 3);
            Assert.AreEqual(false, IsFalse);
        }

        [TestMethod]
        public void TC12()
        {
            bool IsFalse = ClassTests.SearchProductAll("Рама", 2);
            Assert.AreEqual(false, IsFalse);
        }

        [TestMethod]
        public void TC13()
        {
            bool IsTrue = ClassTests.SearchPrice(23);
            Assert.AreEqual(true, IsTrue);
        }

        [TestMethod]
        public void TC14()
        {
            bool IsTrue = ClassTests.DeletePrice(20);
            Assert.AreEqual(true, IsTrue);
        }

        [TestMethod]
        public void TC15()
        {
            DateTime date = DateTime.Now;
            bool IsTrue = ClassTests.AddPriceProd(25,date,"100","10001");
            Assert.AreEqual(true, IsTrue);
        }

        [TestMethod]
        public void TC16()
        {
            DateTime date = DateTime.Now;
            bool IsFalse = ClassTests.AddPriceProd(25, date, "100a", "10001");
            Assert.AreEqual(false, IsFalse);
        }

        [TestMethod]
        public void TC17()
        {
            DateTime date = DateTime.Now;
            bool IsFalse = ClassTests.AddPriceProd(25, date, "-100", "10001");
            Assert.AreEqual(false, IsFalse);
        }

        [TestMethod]
        public void TC18()
        {
            DateTime date = DateTime.Now;
            bool IsFalse = ClassTests.AddPriceProd(25, date, "100", "10001a");
            Assert.AreEqual(false, IsFalse);
        }

        [TestMethod]
        public void TC19()
        {
            DateTime date = DateTime.Now;
            bool IsFalse = ClassTests.AddPriceProd(25, date, "-100", "10001f");
            Assert.AreEqual(false, IsFalse);
        }

        [TestMethod]
        public void TC20()
        {
            bool IsFalse = ClassTests.DeletePrice(0);
            Assert.AreEqual(false, IsFalse);
        }
    }
}
