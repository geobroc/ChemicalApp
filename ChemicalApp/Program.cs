using System;
using System.Collections.Generic;

namespace ChemicalApp
{
    class Program
    {
        // global variables
        static List<string> chemicals = new List<string>() { "Cyanide", "Propane" };
        // methods and\or functions

        // Calculate the efficiency of a chemical 

        static void OneChemical()
        {
            // Decide which chemical is used
            Console.WriteLine("Choose a chemical:\n" +
                "1. Cyanide\n" +
                "2. Propane\n" +
                "3. Quit\n");

            int chemical = Convert.ToInt32( Console.ReadLine());

            float sumEfficiencies = 0;
            // repeat the test 5 times
            for (int i = 0; i < 5; i++)
            {
                // Enter and store amount of germs in sample
                Console.WriteLine("Please enter an initial germ count in a sample");

                int germCount = Convert.ToInt32(Console.ReadLine());

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

            // Display and its final efficiency rating
            Console.WriteLine($"Chemical {chemicals[chemical-1]} has an efficiency rating of {finalEficiency}.");
        }

        static void Main(string[] args)
        {
            OneChemical();
            // Loop OneChemical() until the user has tested all their chemicals

            // Display the most and least effective chemical
        }
    }
}
