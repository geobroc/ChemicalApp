using System;
using System.Collections.Generic;

namespace ChemicalApp
{
    class Program
    {
        // global variables
        static List<string> chemicals = new List<string>() { "Cyanide", "Propane", "Alcohol", "Chlorine" };
        // methods and\or functions
        // checks if an integer entered by a user is within a specific range
        static int CheckInt(string question, int min, int max)
        {
            Console.WriteLine(question);

            while (true)
            {
                int userInt = Convert.ToInt32(Console.ReadLine());

                if (userInt >= min && userInt <= max)
                {
                    return userInt;
                }
                Console.WriteLine($"Error: Enter a number between {min} and {max}");
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

            // Display and its final efficiency rating
            Console.WriteLine($"Chemical {chemicals[chemical-1]} has an efficiency rating of {finalEficiency}.");
        }

        static void Main(string[] args)
        {
            // Loop OneChemical() until the user has tested all their chemicals
            string flag = "";
            while (!flag.Equals("XXX"))
            {
                OneChemical();
                Console.WriteLine("Press <Enter> to add another chemical or type 'XXX' to end");
                flag = Console.ReadLine();
            }
            
            // Display the most and least effective chemical
        }
    }
}
