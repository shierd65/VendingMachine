using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Classes;

namespace CapstoneTests
{
    [TestClass]
    public class ChangeTest
    {
        [TestMethod]
        public void PureQuartersTest()
        {
            Change a1 = new Change(1000, 200, 150, 100);
            Assert.AreEqual(40, a1.Quarters);
            Assert.AreEqual(0, a1.Dimes);
            Assert.AreEqual(0, a1.Nickels);
            Change a2 = new Change(0, 200, 150, 100);
            Assert.AreEqual(0, a2.Quarters);
            Assert.AreEqual(0, a2.Dimes);
            Assert.AreEqual(0, a2.Nickels);
            Change a3 = new Change(400, 200, 150, 100);
            Assert.AreEqual(16, a3.Quarters);
            Assert.AreEqual(0, a3.Dimes);
            Assert.AreEqual(0, a3.Nickels);
        }

        [TestMethod]
        public void AlsoOtherCents()
        {
            Change a1 = new Change(1020, 200, 150, 100);
            Assert.AreEqual(40, a1.Quarters);
            Assert.AreEqual(2, a1.Dimes);
            Assert.AreEqual(0, a1.Nickels);
            Change a2 = new Change(0, 200, 150, 100);
            Assert.AreEqual(0, a2.Quarters);
            Assert.AreEqual(0, a2.Dimes);
            Assert.AreEqual(0, a2.Nickels);
            Change a3 = new Change(415, 200, 150, 100);
            Assert.AreEqual(16, a3.Quarters);
            Assert.AreEqual(1, a3.Dimes);
            Assert.AreEqual(1, a3.Nickels);
            Change a4 = new Change(405, 200, 150, 100);
            Assert.AreEqual(16, a4.Quarters);
            Assert.AreEqual(0, a4.Dimes);
            Assert.AreEqual(1, a4.Nickels);
            Change a5 = new Change(410, 200, 150, 100);
            Assert.AreEqual(16, a5.Quarters);
            Assert.AreEqual(1, a5.Dimes);
            Assert.AreEqual(0, a5.Nickels);
            Change a6 = new Change(-1000, 200, 150, 100);
            Assert.AreEqual(0, a6.Quarters);
            Assert.AreEqual(0, a6.Dimes);
            Assert.AreEqual(0, a6.Nickels);
        }


    }
}
