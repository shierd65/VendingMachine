using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class VendingMachine
    {
        private Dictionary<string, VM_Item> inventory;
        private double currentBalance;
        private double totalSales;
        private int quartersRemaining;
        private int dimesRemaining;
        private int nickelsRemaining;

        public VendingMachine()
        {
            VM_Stocker s1 = new VM_Stocker("vendingmachine.csv");
            this.inventory = s1.Inventory;
            currentBalance = 0.0;
            totalSales = 0.0;
            quartersRemaining = 200;
            dimesRemaining = 150;
            nickelsRemaining = 100;
        }

        public double CurrentBalance
        {
            get { return currentBalance; }
        }
        public double TotalSales
        {
            get { return totalSales; }
        }
        public int QuartersRemaining
        {
            get { return quartersRemaining; }
            set { quartersRemaining = value; }
        }
        public int DimesRemaining
        {
            get { return dimesRemaining; }
            set { dimesRemaining = value; }
        }
        public int NickelsRemaining
        {
            get { return nickelsRemaining; }
            set { nickelsRemaining = value; }
        }

        public double GetTotalChange()
        {
            return (quartersRemaining * .25) + (dimesRemaining * .1) + (nickelsRemaining * .05);
         }

        public void FeedMoney(int dollars)
        {
            currentBalance += (double)dollars;
        }

        public Change ReturnChange()
        {
            Change changeRetured = new Change((int)(currentBalance * 100), quartersRemaining, dimesRemaining, nickelsRemaining);
            TxWriter.Audit(currentBalance);
            currentBalance = 0.00;
            quartersRemaining -= changeRetured.Quarters;
            dimesRemaining -= changeRetured.Dimes;
            nickelsRemaining -= changeRetured.Nickels;
            return changeRetured;
        }

        public Dictionary<string, VM_Item> GetInventory()
        {
            return inventory;
        }

        public void Purchase(VM_Item item)
        {
            item.QuantityRemaining--;
            item.QuantitySold++;
            currentBalance -= item.Price;
            totalSales += item.Price;

            TxWriter.Audit(item);
        }
    }
}
