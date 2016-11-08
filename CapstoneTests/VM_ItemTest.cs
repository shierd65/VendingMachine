using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Classes;

namespace CapstoneTests
{
    [TestClass]
    public class VM_ItemTest
    {
        [TestMethod]
        public void ItemTester()
        {
            VM_Item a1 = new VM_Item("Bologna", 8.65, "A1");

            Assert.AreEqual("Bologna", a1.Name);
            Assert.AreEqual(8.65, a1.Price);
            Assert.AreEqual(5, a1.QuantityRemaining);
            Assert.AreEqual(0, a1.QuantitySold);
            Assert.AreEqual("A1", a1.Slot);

        }
    }
}
