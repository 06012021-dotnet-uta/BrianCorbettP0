using System;

namespace BusinessLayer
{
    public class Read : IRead
    {
        public int GetInteger(string prompt = "=> ")
        {
            Console.Write(prompt);
            string UserInput = Console.ReadLine();
            int UserInputInt;
            bool successfulConversion = Int32.TryParse(UserInput, out UserInputInt);
            if (successfulConversion && UserInputInt >= 1) return UserInputInt;
            else return -1;
        }

        public string GetString(string prompt = "=> ")
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }
    }
}