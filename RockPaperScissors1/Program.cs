using System;

namespace RockPaperScissors1
{
    partial class Program
    {
        static void Main(string[] args)
        {
            RpsGame rpsGame = new RpsGame();
            Console.WriteLine(rpsGame.WelcomeMessage());
            Console.WriteLine("Please enter your first name:");
            string playerFname = rpsGame.getPlayerName(Console.ReadLine());

            PlayerBaseClass player = new PlayerBaseClass(playerFname);
            ComputerBaseClass computer = new ComputerBaseClass();

            while (rpsGame.KeepPlaying)
            {
                int playerChoiceInt;
                while (player.Score < 2 && computer.Score < 2)
                {
                    do
                    {
                        Console.WriteLine("Make a choice.");
                        Console.WriteLine("1. Rock\n2. Paper\n3. Scissors");
                        string playerChoice = Console.ReadLine();
                        playerChoiceInt = rpsGame.InputToInt(playerChoice);
                    }
                    // while input is not a number or not in bounds, loop again
                    while (playerChoiceInt == 0);

                    // get random number generator object
                    // get a random number 1-3
                    int computerChoiceInt = computer.getRandomChoice();

                    // print the choices
                    Console.WriteLine($"{player.Name}'s choice is {(RpsChoice)playerChoiceInt}.");
                    Console.WriteLine($"{computer.Name}'s choice is {(RpsChoice)computerChoiceInt}.");

                    // check who won
                    string winner = rpsGame.roundWinner(playerChoiceInt, computerChoiceInt);
                    if (winner == "tie") Console.WriteLine("Tie round!");
                    else if (winner == "player")
                    {
                        Console.WriteLine($"{player.Name} wins the round!");
                        player.incrementScore();
                    }
                    else
                    {
                        Console.WriteLine($"{computer.Name} wins the round!");
                        computer.incrementScore();
                    }
                }

                if (player.wonItAll())
                    Console.WriteLine($"{player.Name} won it all!");
                else
                    Console.WriteLine($"{computer.Name} won it all!");

                string playAgain;
                do
                {
                    Console.WriteLine("Would you like to play again? (y/n)");
                    playAgain = Console.ReadLine();
                    if (playAgain == "n") rpsGame.KeepPlaying = false;
                    else
                    {
                        player.reset();
                        computer.reset();
                    }
                } while (playAgain != "y" && playAgain != "n");
            }// end of game loop
        }// end of main
    }// end of class
}// end of namespace
