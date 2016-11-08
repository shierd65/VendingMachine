using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Classes;

namespace CapstoneTests
{
    [TestClass]
    public class VendingMachineTest
    {
        [TestMethod]
        public void TestingFeedMoneyAndCurrentBalanceAndReturnChange()
        {
            //VM_Stocker s1 = new VM_Stocker("vendingmachine.csv");
            //VendingMachine v1 = new VendingMachine(s1.Inventory);
            VendingMachine v1 = new VendingMachine();
            Assert.AreEqual(70, v1.GetTotalChange());

            v1.NickelsRemaining = 0;
            Assert.AreEqual(65, v1.GetTotalChange());

     
            v1.FeedMoney(3);
            Assert.AreEqual(3.00, v1.CurrentBalance);
            v1.FeedMoney(10);
            Assert.AreEqual(13.00, v1.CurrentBalance);
            VendingMachine v2 = new VendingMachine();
            v2.FeedMoney(20);
            Assert.AreEqual(20.00, v2.CurrentBalance);
            v1.ReturnChange();
            Assert.AreEqual(0.00, v1.CurrentBalance);
            v1.FeedMoney(10);
            v1.FeedMoney(10);
            v1.FeedMoney(10);
            Assert.AreEqual(30.00, v1.CurrentBalance);
            v1.ReturnChange();
            Assert.AreEqual(0.00, v1.CurrentBalance);

        }

        [TestMethod]
        public void TestingPurchase()
        {
            VM_Item i1 = new VM_Item("Moonpie", 1.50, "B1");
            VM_Item i2 = new VM_Item("Heavy", 1.50, "C4");
            VM_Item i3 = new VM_Item("Triplemint", 0.75, "D4");
            VendingMachine v1 = new VendingMachine();
            v1.FeedMoney(100);
            v1.ReturnChange();
            v1.FeedMoney(10);
            v1.Purchase(i1);
            v1.Purchase(i3);
            Assert.AreEqual(7.75, v1.CurrentBalance);
            v1.Purchase(i1);
            v1.Purchase(i1);
            Assert.AreEqual(4.75, v1.CurrentBalance);
            Assert.AreEqual(2, i1.QuantityRemaining);
            Assert.AreEqual(4, i3.QuantityRemaining);
            v1.ReturnChange();
            Assert.AreEqual(0.00, v1.CurrentBalance);
            v1.FeedMoney(5);
            v1.ReturnChange();
        }

        [TestMethod]
        public void TestingGetInventory()
        {
            //VM_Item i1 = new VM_Item("Moonpie", 1.50, "B1");
           // VM_Item i2 = new VM_Item("Heavy", 1.50, "C4");
            //VM_Item i3 = new VM_Item("Triplemint", 0.75, "D4");
            VendingMachine v1 = new VendingMachine();
            v1.FeedMoney(10);
            v1.Purchase(v1.GetInventory()["B1"]);
            //v1.Purchase(i1);
            VM_Stocker s1 = new VM_Stocker("vendingmachine.csv");
            Assert.AreEqual(s1.Inventory["A2"].Name, v1.GetInventory()["A2"].Name);
            Assert.AreEqual(s1.Inventory["A4"].Price, v1.GetInventory()["A4"].Price);
            Assert.AreEqual(s1.Inventory["B4"].Price, v1.GetInventory()["B4"].Price);
            Assert.AreNotEqual(s1.Inventory["B1"].QuantityRemaining, v1.GetInventory()["B1"].QuantityRemaining);
            Assert.AreNotEqual(s1.Inventory["B1"].QuantitySold, v1.GetInventory()["B1"].QuantitySold);
            //CollectionAssert.AreEquivalent(v1.GetInventory(), s1.Inventory);

        }

    }
}
