using System;

namespace Mucyo_Billy_26853
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            bool loggedIn = false;

            // LOGIN SCREEN
            while (!loggedIn)
            {
                Console.Clear();
                Console.WriteLine("========================================");
                Console.WriteLine("           WELCOME - LOGIN              ");
                Console.WriteLine("========================================");
                Console.Write("Enter your username: ");
                string username = Console.ReadLine();
                Console.Write("Enter your password: ");
                string password = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(username) && !string.IsNullOrWhiteSpace(password))
                {
                    loggedIn = true;
                    Console.WriteLine($"\nLogin successful! Welcome, {username}.\n");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("\nInvalid credentials. Please try again.\n");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
            }

            // MAIN MENU
            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.WriteLine("========================================");
                Console.WriteLine("             MAIN MENU                  ");
                Console.WriteLine("========================================");
                Console.WriteLine("  [1] Bicycle Rental                    ");
                Console.WriteLine("  [2] Mushroom Identifier               ");
                Console.WriteLine("  [3] Logout                            ");
                Console.WriteLine("========================================");
                Console.Write("\nChoose an option (1-3): ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        RunBicycleRental();
                        break;
                    case "2":
                        RunMushroomIdentifier();
                        break;
                    case "3":
                        running = false;
                        Console.WriteLine("\nLogged out successfully. Goodbye!\n");
                        break;
                    default:
                        Console.WriteLine("\nInvalid choice. Please enter 1, 2, or 3.\n");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        // PROBLEM 1: BICYCLE RENTAL
        static void RunBicycleRental()
        {
            Console.Clear();
            Console.WriteLine("========================================");
            Console.WriteLine("     BICYCLE RENTAL CALCULATOR          ");
            Console.WriteLine("========================================");

            int startTime, endTime;

            while (true)
            {
                Console.Write("Enter starting time (hour, 0-23): ");
                if (int.TryParse(Console.ReadLine(), out startTime) && startTime >= 0 && startTime <= 23)
                    break;
                Console.WriteLine("Invalid! Enter an integer between 0 and 23.");
            }

            while (true)
            {
                Console.Write("Enter ending time (hour, 1-24): ");
                if (int.TryParse(Console.ReadLine(), out endTime) && endTime >= 1 && endTime <= 24)
                    break;
                Console.WriteLine("Invalid! Enter an integer between 1 and 24.");
            }

            if (startTime >= endTime)
            {
                Console.WriteLine("\nStarting time must be less than ending time.\n");
                Console.WriteLine("Press any key to return to menu...");
                Console.ReadKey();
                return;
            }

            int totalCost = 0;
            int totalHours = endTime - startTime;

            Console.WriteLine("\n---------- Rental Breakdown ----------");
            Console.WriteLine($"{"Hour Range",-15} {"Rate (RWF)",-15} {"Subtotal (RWF)"}");
            Console.WriteLine("--------------------------------------");

            for (int hour = startTime; hour < endTime; hour++)
            {
                int rate = GetHourlyRate(hour);
                totalCost += rate;
                Console.WriteLine($"  {hour:00}:00 - {hour + 1:00}:00    {rate,-15} {rate}");
            }

            Console.WriteLine("--------------------------------------");
            Console.WriteLine($"  Total Hours : {totalHours}");
            Console.WriteLine($"  Total Cost  : {totalCost} RWF");
            Console.WriteLine("--------------------------------------\n");

            Console.WriteLine("Press any key to return to menu...");
            Console.ReadKey();
        }

        static int GetHourlyRate(int hour)
        {
            if ((hour >= 0 && hour < 7) || (hour >= 21 && hour < 24))
                return 500;
            if ((hour >= 7 && hour < 14) || (hour >= 19 && hour < 21))
                return 1000;
            if (hour >= 14 && hour < 19)
                return 1500;
            return 0;
        }

        // PROBLEM 2: MUSHROOM IDENTIFIER
        static void RunMushroomIdentifier()
        {
            Console.Clear();
            Console.WriteLine("========================================");
            Console.WriteLine("      MUSHROOM IDENTIFIER GAME          ");
            Console.WriteLine("========================================");
            Console.WriteLine("\nThink of one of these 6 mushrooms:");
            Console.WriteLine("  1. Agaric Jaunissant");
            Console.WriteLine("  2. Amanite tue-mouche");
            Console.WriteLine("  3. Cepe de bordeau");
            Console.WriteLine("  4. Coprin chevelu");
            Console.WriteLine("  5. Girolle");
            Console.WriteLine("  6. Pied bleu");
            Console.WriteLine("\nAnswer the following questions with 'yes' or 'no'.\n");

            bool[] possible = { true, true, true, true, true, true };
            string[] names = { "Agaric Jaunissant", "Amanite tue-mouche", "Cepe de bordeau",
                               "Coprin chevelu", "Girolle", "Pied bleu" };

            string answer1 = AskQuestion("1. Does your mushroom have gills?");
            if (answer1 == "no")
            {
                possible[0] = false; possible[1] = false; possible[3] = false;
                possible[4] = false; possible[5] = false;
            }
            else
            {
                possible[2] = false;
            }
            if (CountPossible(possible) == 1) { DisplayResult(names, possible); return; }

            string answer2 = AskQuestion("2. Does your mushroom grow in a forest?");
            if (answer2 == "yes")
            {
                possible[0] = false; possible[3] = false;
            }
            else
            {
                possible[1] = false; possible[4] = false; possible[5] = false;
            }
            if (CountPossible(possible) == 1) { DisplayResult(names, possible); return; }

            string answer3 = AskQuestion("3. Does your mushroom have a ring?");
            if (answer3 == "yes")
            {
                possible[4] = false; possible[5] = false; possible[2] = false;
            }
            else
            {
                possible[0] = false; possible[1] = false; possible[3] = false;
            }
            if (CountPossible(possible) == 1) { DisplayResult(names, possible); return; }

            string answer4 = AskQuestion("4. Does your mushroom have a convex cup?");
            if (answer4 == "yes")
            {
                possible[2] = false; possible[3] = false; possible[4] = false;
            }
            else
            {
                possible[0] = false; possible[1] = false; possible[5] = false;
            }

            DisplayResult(names, possible);
        }

        static string AskQuestion(string question)
        {
            while (true)
            {
                Console.Write(question + " (yes/no): ");
                string input = Console.ReadLine().Trim().ToLower();
                if (input == "yes" || input == "no")
                    return input;
                Console.WriteLine("Please answer 'yes' or 'no'.");
            }
        }

        static int CountPossible(bool[] possible)
        {
            int count = 0;
            foreach (bool b in possible) if (b) count++;
            return count;
        }

        static void DisplayResult(string[] names, bool[] possible)
        {
            Console.WriteLine("\n--------------------------------------");
            int count = CountPossible(possible);

            if (count == 1)
            {
                for (int i = 0; i < names.Length; i++)
                {
                    if (possible[i])
                    {
                        Console.WriteLine($"  Your mushroom is: {names[i]}");
                        break;
                    }
                }
            }
            else if (count == 0)
            {
                Console.WriteLine("  No mushroom matches your answers.");
            }
            else
            {
                Console.WriteLine("  Could not determine uniquely. Possibilities:");
                for (int i = 0; i < names.Length; i++)
                    if (possible[i]) Console.WriteLine($"    - {names[i]}");
            }
            Console.WriteLine("--------------------------------------\n");
            Console.WriteLine("Press any key to return to menu...");
            Console.ReadKey();
        }
    }
}
