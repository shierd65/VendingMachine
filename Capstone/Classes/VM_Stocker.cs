using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class VM_Stocker
    {
        private Dictionary<string, VM_Item> inventory;

        public VM_Stocker(string fileInput)
        {
            inventory = new Dictionary<string, VM_Item>();

            using (StreamReader sRead = new StreamReader(fileInput))
            {
                string currentLine = "";
                while (!sRead.EndOfStream)
                {
                    currentLine = sRead.ReadLine();

                    int currentIndex = currentLine.IndexOf("|");
                    string slot = currentLine.Substring(0, currentIndex);
                    string remainder = currentLine.Substring(currentIndex + 1);

                    currentIndex = remainder.IndexOf("|");
                    string itemName = remainder.Substring(0, currentIndex);
                    remainder = remainder.Substring(currentIndex + 1);
                    double price = double.Parse(remainder);

                    VM_Item newItem = new VM_Item(itemName, price, slot);
                    inventory.Add(slot, newItem);
                }
            }
        }

        public Dictionary<string, VM_Item> Inventory
        {
            get { return inventory; }
        }
    }
}
