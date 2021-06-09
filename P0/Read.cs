using System;

namespace P0
{
    public class Read : IRead
    {
        public double GetNumber()
        {
            Console.Write("=> ");
            string UserInput = Console.ReadLine();
            double UserInputDouble;
            bool successfulConversion = Double.TryParse(UserInput, out UserInputDouble);
            if (successfulConversion && UserInputDouble >= 0.0) return UserInputDouble;
            else return -1.0;
        }

        public string GetString()
        {
            Console.Write(">");
            return Console.ReadLine();
        }
    }
}