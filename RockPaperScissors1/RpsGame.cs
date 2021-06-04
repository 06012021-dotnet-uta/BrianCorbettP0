using System;

namespace RockPaperScissors1
{
    partial class RpsGame
    {
        private bool keepPlaying = true;
        public bool KeepPlaying
        {
            get
            {
                return keepPlaying;
            }
            set
            {
                keepPlaying = value;
            }
        }

        public string WelcomeMessage()
        {
            string welcome = "Welcome to Rock, Paper, Scissors!\n";
            return welcome;
        }

        public string getPlayerName(string playerInput)
        {
            playerInput = playerInput.Trim();
            if (playerInput.Length > 20 || playerInput.Length < 1)
            {
                return null;
            }
            return playerInput;
        }

        public string roundWinner(int playerChoice, int computerChoice)
        {
            if ((playerChoice == 1 && computerChoice == 2) ||
                (playerChoice == 2 && computerChoice == 3) ||
                (playerChoice == 3 && computerChoice == 1))
                return "computer";
            else if (playerChoice == computerChoice)
                return "tie";
            else
                return "player";
        }

        public int InputToInt(string input)
        {
            int playerChoiceInt;
            // create int variable to capture user's converted choice
            bool successfulConversion = Int32.TryParse(input, out playerChoiceInt);
            if (!successfulConversion)
            {
                Console.WriteLine($"You inputted {playerChoiceInt}. This is not a valid choice.");
                return 0;
            }
            else
            {
                if (playerChoiceInt < 1 || playerChoiceInt > 3)
                {
                    Console.WriteLine($"You inputted {playerChoiceInt}. This is not a valid choice.");
                    return 0;
                }
                else return playerChoiceInt;
            }
        }
    }
}

