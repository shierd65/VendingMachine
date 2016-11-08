using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public static class HiddenMenu
    {
        public static void SalesReport(VendingMachine vm1)
        {
            string fileName = $"Vendo-Matic-Sales{DateTime.Now.ToString("M-dd-yyyy_hhmmss")}.csv";
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                foreach (KeyValuePair<string, VM_Item> kvp in vm1.GetInventory())
                {
                    sw.Write(kvp.Value.Name + "|");
                    sw.Write(kvp.Value.QuantitySold + "|");
                    sw.WriteLine((kvp.Value.QuantitySold * kvp.Value.Price).ToString("C"));
                }
                sw.WriteLine("\n**TOTAL SALES**" + vm1.TotalSales.ToString("C"));
            }
        }

        public static void Restock(VendingMachine vm1)
        {
            foreach (KeyValuePair<string, VM_Item> kvp in vm1.GetInventory())
            {
                kvp.Value.QuantityRemaining = 5;
            }
            vm1.QuartersRemaining = 200;
            vm1.DimesRemaining = 150;
            vm1.NickelsRemaining = 100;
        }
    }
}
