using System;
using System.Collections.Generic;
using System.IO;

namespace PCOrderingSystem
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] cpuOptions = { "Intel Core i5 12600kf - $199", "Intel Core i7 12700 - $299", "AMD Ryzen 5 5600x - $229", "AMD Ryzen 7 5800 x3d - $329" };
            double[] cpuPrices = { 199, 299, 229, 329 };

            string[] gpuOptions = { "Nvidia GTX 1060 - $199", "Nvidia RTX 3060ti - $499", "Nvidia RTX 3090 - $729", "Nvidia RTX 4070ti - $979" };
            double[] gpuPrices = { 199, 499, 729, 979 };

            string[] storageOptions = { "128GB SSD Kingstone - $49", "256GB SSD sata samsung - $79", "512GB SSD Samsung m2 evo plus - $129", "1TB HDD seagate barracuda - $59" };
            double[] storagePrices = { 49, 79, 129, 59 };

            string[] ramOptions = { "8GB DDR4 - $59", "16GB DDR4 2x8 - $99", "32GB DDR4 2x16 - $199", "64GB DDR4 4x16- $399" };
            double[] ramPrices = { 59, 99, 199, 399 };

            string[] MotherboardOptions = { "Asus Prime b660 - $59", "AsRock Z690 Steel Legend  - $89", "Msi Tomohawk - $109", "Asus Republic of gamers - $159" };
            double[] MotherPrices = { 59, 89, 109, 159 };

            string[] CaseOptions = { "Deepcool - $49", "Zalman Z3  - $79", "NZXT H510 Elite - $99", "FractalDesign - $149" };
            double[] CasePrices = { 49, 79, 99, 149 };

            string[] CoolingOptions = { "PcCooling - $49", "DeepCool AK620  - $79", "Lian li Liquid Cooling System - $99", "NZXT Kraken z53 - $149" };
            double[] CoolingPrices = { 49, 79, 99, 149 };


            List<string> orderList = new List<string>();

            while (true)
            {

                Console.Clear();
                Console.WriteLine("PC Ordering System\n");
                Console.WriteLine("1. Select CPU");
                Console.WriteLine("2. Select GPU");
                Console.WriteLine("3. Select Storage");
                Console.WriteLine("4. Select RAM");
                Console.WriteLine("5. Select MotherBoard");
                Console.WriteLine("6. Select Case");
                Console.WriteLine("7. Select Cooling System");
                Console.WriteLine("8. Complete Order");

                ConsoleKeyInfo keyInfo = Console.ReadKey();

                if (keyInfo.Key == ConsoleKey.Escape)
                {
                    break;
                }
                else if (keyInfo.Key == ConsoleKey.Enter)
                {

                    Console.Clear();
                    Console.CursorVisible = false;
                    Console.WriteLine("Select an item:");
                    Console.WriteLine();

                    int selectedIndex;
                    double totalPrice;

                    switch (ArrowMenu(new string[] { "CPU", "GPU", "Storage", "RAM", "MotherBoard", "Case", "Cooling System" }))
                    {
                        case 1:
                            selectedIndex = ArrowMenu(cpuOptions) - 1;
                            totalPrice = cpuPrices[selectedIndex];
                            orderList.Add(cpuOptions[selectedIndex]);
                            break;
                        case 2:
                            selectedIndex = ArrowMenu(gpuOptions) - 1;
                            totalPrice = gpuPrices[selectedIndex];
                            orderList.Add(gpuOptions[selectedIndex]);
                            break;
                        case 3:
                            selectedIndex = ArrowMenu(storageOptions) - 1;
                            totalPrice = storagePrices[selectedIndex];
                            orderList.Add(storageOptions[selectedIndex]);
                            break;
                        case 4:
                            selectedIndex = ArrowMenu(ramOptions) - 1;
                            totalPrice = ramPrices[selectedIndex];
                            orderList.Add(ramOptions[selectedIndex]);
                            break;
                        case 5:
                            selectedIndex = ArrowMenu(MotherboardOptions) - 1;
                            totalPrice = MotherPrices[selectedIndex];
                            orderList.Add(MotherboardOptions[selectedIndex]);
                            break;
                        case 6:
                            selectedIndex = ArrowMenu(CaseOptions) - 1;
                            totalPrice = CasePrices[selectedIndex];
                            orderList.Add(CaseOptions[selectedIndex]);
                            break;
                        case 7:
                            selectedIndex = ArrowMenu(CoolingOptions) - 1;
                            totalPrice = CoolingPrices[selectedIndex];
                            orderList.Add(CoolingOptions[selectedIndex]);
                            break;
                        default: continue;
                    }
                    Console.CursorVisible = true;


                    Console.WriteLine();
                    Console.WriteLine("You selected: " + orderList[orderList.Count - 1]);
                    Console.WriteLine("Price: $" + totalPrice);
                    Console.WriteLine();


                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
                else if (keyInfo.Key == ConsoleKey.D8)
                {

                    double totalOrderPrice = 0;

                    Console.Clear();
                    Console.WriteLine("PC Ordering System - Order Summary\n");

                    foreach (string item in orderList)
                    {
                        Console.WriteLine("- " + item);
                    }

                    Console.WriteLine();

                    foreach (double price in cpuPrices)
                    {
                        totalOrderPrice += price;
                    }

                    foreach (double price in gpuPrices)
                    {
                        totalOrderPrice += price;
                    }

                    foreach (double price in storagePrices)
                    {
                        totalOrderPrice += price;
                    }

                    foreach (double price in ramPrices)
                    {
                        totalOrderPrice += price;
                    }

                    foreach (double price in MotherPrices)
                    {
                        totalOrderPrice += price;
                    }
                    foreach (double price in CasePrices)
                    {
                        totalOrderPrice += price;
                    }
                    foreach (double price in CoolingPrices)
                    {
                        totalOrderPrice += price;
                    }

                    Console.WriteLine("Total price: $" + totalOrderPrice);


                    string fileName = "order_history.txt";
                    StreamWriter fileWriter = new StreamWriter(fileName, true);

                    fileWriter.WriteLine(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"));


                    foreach (string item in orderList)
                    {
                        fileWriter.WriteLine("- " + item);
                    }

                    fileWriter.WriteLine("Total price: $" + totalOrderPrice);
                    fileWriter.WriteLine();

                    fileWriter.Close();

                    Console.WriteLine("Order saved to file: " + fileName);


                    Console.WriteLine();
                    Console.WriteLine("Press any key to continue or Escape to exit...");
                    ConsoleKeyInfo key = Console.ReadKey();

                    if (key.Key == ConsoleKey.Escape)
                    {
                        break;
                    }
                    else
                    {
                        orderList.Clear();
                    }
                    totalOrderPrice = 0;
                }
            }
        }

        static int ArrowMenu(string[] options)
        {
            int selectedIndex = 0;

            while (true)
            {
                Console.CursorVisible = false;


                for (int i = 0; i < options.Length; i++)
                {
                    if (i == selectedIndex)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;
                    }

                    Console.WriteLine(options[i]);

                    Console.ResetColor();
                }


                ConsoleKeyInfo keyInfo = Console.ReadKey();

                if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    if (selectedIndex > 0)
                    {
                        selectedIndex--;
                    }
                }
                else if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    if (selectedIndex < options.Length - 1)
                    {
                        selectedIndex++;
                    }
                }
                else if (keyInfo.Key == ConsoleKey.Enter || keyInfo.Key == ConsoleKey.Escape)
                {
                    Console.Clear();
                    Console.CursorVisible = true;
                    return selectedIndex + 1;
                }

                Console.Clear();
            }
        }
    }
}