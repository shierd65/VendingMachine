using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class VM_CLI
    {
        public static void Run()
        {
            VendingMachine vm1 = new VendingMachine();
            bool shutdown = false;
            int menuState = -1;
            while (!shutdown)
            {
                if (menuState == -1)
                {
                    menuState = MainMenu();
                }
                else if (menuState == -2)
                {
                    Console.WriteLine("Shutting down...");
                    shutdown = true;
                }
                else if (menuState == 0 && vm1.CurrentBalance == 0)
                {
                    menuState = SecretMenu(vm1);
                }
                else if (menuState == 0)
                {
                    Console.Clear();
                    Console.WriteLine("ERROR: Complete transaction before accessing service menu");
                    menuState = -1;
                }          
                else if (menuState == 1)
                {
                    Console.Clear();
                    menuState = DisplayInventory(vm1);
                }
                else if (menuState == 2)
                {
                    menuState = MakeSelection(vm1);
                }
                else
                {
                    Console.WriteLine(menuState);
                    shutdown = true;
                }
            }
        }

        private static int SecretMenu(VendingMachine vm1)
        {
            Console.WriteLine("1) Generate Sales Report");
            Console.WriteLine("2) Restock Machine");
            Console.WriteLine("3) Back To Main Menu");
            string input = Console.ReadLine();
            if (input == "1")
            {
                HiddenMenu.SalesReport(vm1);
                Console.WriteLine("Successfully generated sales report");
            }
            else if (input == "2")
            {
                HiddenMenu.Restock(vm1);
            }

            Console.Clear();
            return -1;
        }

        public static int MainMenu()
        {
            int selection = -1;
            PrintHeader();
            Console.WriteLine("(1) Display items\n(2) Make Purchase");
            string userInput = Console.ReadLine();
            bool isInt = Int32.TryParse(userInput, out selection);
            if (!isInt || selection > 2 || selection < -2)
            {
                Console.WriteLine("That was not a valid selection");
                selection = -1;
            }
            return selection;
        }

        private static void PrintHeader()
        {
            Console.WriteLine("============================================================================");
            Console.WriteLine("Welcome to Totally-Not-evil-Corp vending machines!  Please make a selection!");
            Console.WriteLine("*/~Insert ASCII art here~\\*");
        }

        public static int DisplayInventory(VendingMachine vm1)
        {
            Console.WriteLine("This is the list of selections");
            Console.WriteLine("==============================");
            Dictionary<string, VM_Item> display = vm1.GetInventory();

            foreach (KeyValuePair<string, VM_Item> kvp in display)
            {
                Console.Write(kvp.Value.Slot + " ");
                Console.Write(kvp.Value.Name.PadRight(20) + " ");
                Console.Write(kvp.Value.Price.ToString("C").PadRight(6) + " ");

                if (kvp.Value.QuantityRemaining == 0)
                {
                    Console.WriteLine("SOLD OUT!");
                }
                else
                {
                    Console.WriteLine(kvp.Value.QuantityRemaining + " remaining");
                }
            }
            return -1;
        }

        public static int MakeSelection(VendingMachine vm1)
        {
            bool backToStartMenu = false;
            int selectionState = 0;

            while (!backToStartMenu)
            {
                Console.WriteLine("Please select an option!  Current Money is " + vm1.CurrentBalance.ToString("C"));
                Console.WriteLine("1) Add money");
                Console.WriteLine("2) Purchase Product");
                Console.WriteLine("3) Finish Transaction");
                Console.WriteLine("4) Back to previous menu");
                string inputString = Console.ReadLine();
                bool isInt = Int32.TryParse(inputString, out selectionState);
                if (!isInt || selectionState > 4 || selectionState < 1)
                {
                    Console.WriteLine("That was not a valid selection");
                    selectionState = 0;
                }

                if (selectionState == 1)
                {
                    int dollarInput = 0;
                    Console.WriteLine("How many dollars would you like to put into the machine?");
                    isInt = Int32.TryParse(Console.ReadLine(), out dollarInput);
                    if (!isInt || dollarInput < 0)
                    {
                        Console.WriteLine("Not a valid dollar amount");
                        dollarInput = 0;
                    }
                    if ((dollarInput + vm1.CurrentBalance) > vm1.GetTotalChange())
                    {
                        Console.WriteLine("Not enough change. Money not taken.");
                        dollarInput = 0;
                    }
                    vm1.FeedMoney(dollarInput);
                    selectionState = 0;
                }
                else if (selectionState == 2)
                {
                    Console.WriteLine("Please enter the slot of the item that you are purchasing.");
                    inputString = Console.ReadLine().ToUpper();
                    bool successfulInput = true;

                    if (!vm1.GetInventory().ContainsKey(inputString))
                    {
                        successfulInput = false;
                        Console.WriteLine("Invalid slot.");
                    }
                    else if (vm1.GetInventory()[inputString].QuantityRemaining < 1)
                    {
                        successfulInput = false;
                        Console.WriteLine("SOLD OUT");
                    }
                    else if (vm1.GetInventory()[inputString].Price > vm1.CurrentBalance)
                    {
                        successfulInput = false;
                        Console.WriteLine("Insufficient funds.");
                    }                 

                    if (successfulInput)
                    {
                        vm1.Purchase(vm1.GetInventory()[inputString]);
                        Console.Clear();
                        PrintHeader();
                        Console.WriteLine($"\nYou receive one {vm1.GetInventory()[inputString].Name.ToString()}!");
                    }

                    selectionState = 0;
                }
                else if (selectionState == 3)
                {
                    selectionState = 0;
                    Change c1 = vm1.ReturnChange();
                    Console.Write("Dispensing change.  You received: ");
                    Console.WriteLine($"{c1.Quarters} Quarters, {c1.Dimes} Dimes, and {c1.Nickels} Nickels.\n");
                    backToStartMenu = true;
                }
                else if (selectionState == 4)
                {
                    backToStartMenu = true;
                }
            }
            return -1;
        }
    }
}
