using System;

namespace RockPaperScissors1
{
    partial class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Rock, Paper, Scissors!\nPlease enter your name:");
            string playerName = Console.ReadLine();

            bool keepPlaying = true;
            while (keepPlaying)
            {
                int playerWins = 0, computerWins = 0;
                bool successfulConversion = false;
                int playerChoiceInt;
                while (playerWins < 2 && computerWins < 2)
                {
                    Console.WriteLine("Now make a choice.");
                    do
                    {
                        Console.WriteLine("1. Rock\n2. Paper\n3. Scissors");
                        string playerChoice = Console.ReadLine();

                        // create int variable to capture user's converted choice
                        successfulConversion = Int32.TryParse(playerChoice, out playerChoiceInt);

                        // check if the user inputted an inbounds number
                        if (playerChoiceInt > 3 || playerChoiceInt < 1)
                            Console.WriteLine($"You inputted {playerChoiceInt}. This is not a valid choice.");
                        else if (!successfulConversion)
                            Console.WriteLine($"You inputted {playerChoiceInt}. This is not a valid choice.");
                    }
                    // while input is not a number or not in bounds, loop again
                    while (!successfulConversion || !(playerChoiceInt > 0 && playerChoiceInt < 4));

                    if (successfulConversion == true)
                        Console.WriteLine($"The conversion returned {successfulConversion} and the player chose {playerChoiceInt}.");
                    else
                        Console.WriteLine($"The conversion returned {successfulConversion} and the player chose {playerChoiceInt}.");

                    // get random number generator object
                    Random rand = new Random();
                    // get a random number 1-3
                    int computerChoice = rand.Next(1, Enum.GetNames(typeof(RpsChoice)).Length + 1);

                    // print the choices
                    Console.WriteLine($"The player's choice is {(RpsChoice)playerChoiceInt}.");
                    Console.WriteLine($"The computer's choice is {(RpsChoice)computerChoice}.");

                    // check who won
                    if ((playerChoiceInt == 1 && computerChoice == 2) ||
                        (playerChoiceInt == 2 && computerChoice == 3) ||
                        (playerChoiceInt == 3 && computerChoice == 1))
                    {
                        Console.WriteLine("Computer Wins!");
                        computerWins++;
                    }
                    else if (playerChoiceInt == computerChoice)
                        Console.WriteLine("Tie Game!");
                    else
                    {
                        Console.WriteLine($"{playerName} Wins!");
                        playerWins++;
                    }
                }
                if (playerWins >= 2)
                    Console.WriteLine($"{playerName} won it all!");
                else
                    Console.WriteLine("The computer won it all!");

                Console.WriteLine("Would you like to play again? (y/n)");
                string playAgain = Console.ReadLine();
                if (playAgain == "n")
                    keepPlaying = false;
            }// end of game loop
        }// end of main
    }// end of class
}// end of namespace
