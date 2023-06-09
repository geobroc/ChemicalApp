﻿using System;
using System.Collections.Generic;

namespace ChemicalApp
{
    class Program
    {
        // global variables
        static List<string> chemicals = new List<string>() { "Cyanide", "Propane", "Alcohol", "Chlorine" };
        static int flag = 0;
        static int topChemical = 0;
        static float topEfficiency = 0;
        static int lowChemical = 9000;
        static float lowEfficiency = 9000;


        // methods and\or functions

        // checks if an integer entered by a user is within a specific range
        static int CheckInt(string question, int min, int max)
        {
            Console.WriteLine(question);

            while (true)
            {
                try
                {
                    int userInt = Convert.ToInt32(Console.ReadLine());

                    if (userInt >= min && userInt <= max)
                    {
                        return userInt;
                    }
                    Console.WriteLine($"Error: Enter a number between {min} and {max}\n");
                }
                catch
                {
                    Console.WriteLine($"Error: Enter a number between {min} and {max}\n");
                }
                
            }

        }

        // Calculate the efficiency of a chemical 
        static void OneChemical()
        {
            // Decide which chemical is used
            int chemical = CheckInt("Choose a chemical:\n" +
                "1. Cyanide\n" +
                "2. Propane\n" +
                "3. Alcohol\n" + 
                "4. Chlorine\n" +
                "5. Quit\n", 1, 5);

            

            if (chemical == 5)
            {
                flag = 5;
            }
            else
            {
                float sumEfficiencies = 0;
                // repeat the test 5 times
                for (int i = 0; i < 5; i++)
                {
                    // Enter and store amount of germs in sample

                    int germCount = CheckInt("Please enter an initial germ count in a sample", 100, 9000);

                    // Display an amount of time passed
                    Console.WriteLine("--- 45 minutes passed ---");

                    // Find amount of germs after passed time
                    Random randGerm = new Random();
                    int afterGermCount = randGerm.Next(0, germCount);

                    // Determine the efficiency of the chemical
                    float efficiency = (float)(germCount - afterGermCount) / 45;

                    sumEfficiencies = sumEfficiencies + efficiency;
                }
                // calculate the average which will be the final efficiency rating
                float finalEficiency = (float)sumEfficiencies / 5;
                finalEficiency = (float)Math.Round(finalEficiency, 2);

                Console.ReadLine();
                Console.Clear();
                // Display and its final efficiency rating
                Console.WriteLine($"Chemical {chemicals[chemical - 1]} has an efficiency rating of {finalEficiency}.\n");

                if (finalEficiency > topEfficiency)
                {
                    topEfficiency = finalEficiency;
                    topChemical = chemical;
                }
                if (finalEficiency < lowEfficiency)
                {
                    lowEfficiency = finalEficiency;
                    lowChemical = chemical;
                }
            }
            
        }

        static void Main(string[] args)
        {
            Console.WriteLine(@" _____ _                    _           _    ___              " + "\n" +
                              @"/  __ \ |                  (_)         | |  / _ \             " + "\n" +
                              @"| /  \/ |__   ___ _ __ ___  _  ___ __ _| | / /_\ \_ __  _ __  " + "\n" +
                              @"| |   | '_ \ / _ \ '_ ` _ \| |/ __/ _` | | |  _  | '_ \| '_ \ " + "\n" +
                              @"| \__/\ | | |  __/ | | | | | | (_| (_| | | | | | | |_) | |_) |" + "\n" +
                              @" \____/_| |_|\___|_| |_| |_|_|\___\__,_|_| \_| |_/ .__/| .__/ " + "\n" +
                              @"                                                 | |   | |    " + "\n" +
                              @"                                                 |_|   |_|    " + "\n");
            Console.WriteLine("------------------------------------------------------------------------");
            Console.WriteLine("Chemical app is an app that is used to test chemcials.\n" +
                "Select a chemical and choose an amount of germs and test 5 times with the chemical.\n" +
                "Then have a choice to test another chemical or stop.\n");
            Console.WriteLine("------------------------------------------------------------------------");

            Console.WriteLine("Press Enter to continue");
            Console.ReadLine();
            Console.Clear();

        // Loop OneChemical() until the user has tested all their chemicals
            
            while (flag != 5)
            {
                OneChemical();
            }

            Console.ReadLine();
            Console.Clear();
            // Display the most and least effective chemical
            Console.WriteLine($"The most efficent chemical is {chemicals[topChemical - 1]} with a rating of {topEfficiency}.\nThe least efficient chemical is {chemicals[lowChemical - 1]} with a rating of {lowEfficiency}.\n");
            
            
        }
    }
}
