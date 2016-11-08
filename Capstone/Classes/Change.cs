using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class Change
    {
        int quarters;
        int dimes;
        int nickels;

        public Change(int numberOfCents, int quartersRemaining, int dimesRemaining, int nickelsRemaining)
        {
            quarters = 0;
            dimes = 0;
            nickels = 0;
            while (numberOfCents >= 25 && quartersRemaining > 0)
            {
                quarters++;
                quartersRemaining--;
                numberOfCents -= 25;
            }
            while (numberOfCents >= 10 && dimesRemaining > 0)
            {
                dimes++;
                dimesRemaining--;
                numberOfCents -= 10;
            }
            while (numberOfCents >= 5 && nickelsRemaining > 0)
            {
                nickels++;
                nickelsRemaining--;
                numberOfCents -= 5;
            }

        }

        public int Quarters
        {
            get { return quarters; }
        }
        public int Dimes
        {
            get { return dimes; }
        }
        public int Nickels
        {
            get { return nickels; }
        }
    }
}
