using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class VM_Item
    {
        string name;
        double price;
        int quantityRemaining;
        int quantitySold;
        string slot;

        public VM_Item(string name, double price, string slot)
        {
            this.name = name;
            this.price = price;
            this.slot = slot;
            quantityRemaining = 5;
            quantitySold = 0;
        }

        public string Name
        {
            get { return name; }
        }
        public double Price
        {
            get { return price; }
        }
        public int QuantityRemaining
        {
            get { return quantityRemaining; }
            set { quantityRemaining = value; }
        }
        public int QuantitySold
        {
            get { return quantitySold; }
            set { quantitySold = value; }
        }
        public string Slot
        {
            get { return slot; }
        }
    }
}
