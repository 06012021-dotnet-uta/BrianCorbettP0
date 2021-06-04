using System;

namespace RockPaperScissors1
{
    public class ComputerBaseClass : PlayerBaseClass
    {
        public ComputerBaseClass() : base() { }

        public int getRandomChoice()
        {
            Random rand = new Random();
            int choice = rand.Next(1, 4);
            return choice;
        }

    }
}