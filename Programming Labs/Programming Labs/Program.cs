using System;

namespace guessthenumber2
{
    internal class Program
    {
        static void Main(string[] args)
        {
                Random random = new Random();
                int computerGuess;
                int low = 1;
                int high = 100;
                int attempts = 0;
                const int maxAttempts = 10;

                Console.WriteLine("Think of a number between 1 and 100.");
                Console.WriteLine("Press Enter when you're ready for the computer to start guessing");
                Console.ReadLine();

                while (attempts < maxAttempts)
                {
                    computerGuess = random.Next(low, high + 1);
                    Console.WriteLine($"Computer's guess {attempts + 1}: {computerGuess}");

                    Console.WriteLine("Is this guess correct? (y/n)");
                    string userResponse = Console.ReadLine().ToLower();

                    if (userResponse == "y")
                    {
                        Console.WriteLine("Computer guessed correctly! Computer wins!");
                        return;
                    }
                    else if (userResponse == "n")
                    {
                        Console.WriteLine("Was the guess too high or too low? (h/l)");
                        string userFeedback = Console.ReadLine().ToLower();

                        if (userFeedback == "h")
                        {
                            high = computerGuess - 1;
                        }
                        else if (userFeedback == "l")
                        {
                            low = computerGuess + 1;
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter 'h' or 'l'.");
                            continue;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter 'yes' or 'no'.");
                        continue;
                    }

                attempts++;
        }
            Console.WriteLine($"The computer has run out of attempts. You win!");
        }
}
}
