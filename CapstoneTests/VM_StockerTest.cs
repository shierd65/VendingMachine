using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Capstone.Classes;

namespace CapstoneTests
{
    [TestClass]
    public class VM_StockerTest
    {
        [TestMethod]
        public void ReadingTextInput()
        {

            VM_Item a1 = new VM_Item("Potato Crisps", 3.25, "A1");
            VM_Item a2 = new VM_Item("Stackers", 1.75, "A2");
            Dictionary<string, VM_Item> testDictionary = new Dictionary<string, VM_Item>()
            {
                {"A1", a1},
                {"A2", a2 }
            };


            VM_Stocker s1 = new VM_Stocker("vendingmachine.csv");

            //Assert.AreSame(s1.Inventory["A1"], a1);
            //CollectionAssert.AllItemsAreInstancesOfType(s1.Inventory, VM_Item());
            Assert.AreEqual(s1.Inventory["A1"].Price, a1.Price);
            Assert.AreEqual(s1.Inventory["A1"].Name, a1.Name);
            Assert.AreEqual(s1.Inventory["A1"].QuantityRemaining, a1.QuantityRemaining);
            Assert.AreEqual(s1.Inventory["A1"].QuantitySold, a1.QuantitySold);
            Assert.AreEqual(s1.Inventory["A1"].Slot, a1.Slot);

            Assert.AreEqual(s1.Inventory["A2"].Price, a2.Price);
            Assert.AreEqual(s1.Inventory["A2"].Name, a2.Name);
            Assert.AreEqual(s1.Inventory["A2"].QuantityRemaining, a2.QuantityRemaining);
            Assert.AreEqual(s1.Inventory["A2"].QuantitySold, a2.QuantitySold);
            Assert.AreEqual(s1.Inventory["A2"].Slot, a2.Slot);

            //Assert.AreEqual(s1.Inventory["A1"].Name, testDictionary.Inventory["A1"].Name);
            //CollectionAssert.Contains(s1.Inventory, a1);
            //CollectionAssert.Contains(s1.Inventory, a2);
        }
    }
}
