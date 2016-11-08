using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public static class TxWriter
    {
        public static void Audit(VM_Item item)
        {
            bool logExists = File.Exists("transactionLog.txt");

            using (StreamWriter sw = new StreamWriter("transactionLog.txt", true))
            {
                if (!logExists)
                {
                    CreateHeader(sw);
                }
                sw.Write($"\n{DateTime.Now}".PadRight(24) + $"{item.Name}".PadRight(20) + $"{item.Slot}".PadRight(7)
                    + item.Price.ToString("C"));
            }
        }

        public static void Audit(double change)
        {
            bool logExists = File.Exists("transactionLog.txt");
            bool emptyLine = false;

            if (!logExists)
            {
                using (StreamWriter sw = new StreamWriter("transactionLog.txt"))
                {
                    CreateHeader(sw);
                }
            }
            using (StreamReader sr = new StreamReader("transactionLog.txt"))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    if (line.Length > 0 && line[line.Length - 1] == ' ')
                    {
                        emptyLine = true;
                    }
                    else
                    {
                        emptyLine = false;
                    }
                }
            }

            logExists = File.Exists("transactionLog.txt");
            using (StreamWriter sw = new StreamWriter("transactionLog.txt", true))
            {
                if (!logExists)
                {
                    CreateHeader(sw);
                }

                if (emptyLine)
                {
                    for (int i = 0; i < 63; i++)
                    {
                        sw.Write("-");
                    }
                    sw.Write("  " + change.ToString("C").PadLeft(2) + " \n");
                }
                else
                {
                    sw.Write(change.ToString("C").PadLeft(15) + "\n \n");
                }
            }
        }

        private static void CreateHeader(StreamWriter sw)
        {
                sw.Write("Date".PadRight(10) + "Time".PadRight(13) + "Product".PadRight(20) + "Slot".PadRight(7) +
                "Amount Paid".PadRight(15) + "Change Tendered\n  \n");           
        }
    }
}
