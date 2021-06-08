using System;

namespace P0
{
    public class UserInteract
    {
        public void PutLine(string message)
        {
            Console.WriteLine(message);
        }

        public void TakeLine(Type type)
        {
            string UserInput = Console.ReadLine();
            if (type == typeof(System.String))
            {
                //
            }
            else if (type == typeof(System.Int32))
            {
                int UserInputInt;
                try
                {
                    bool SuccessfulConversion = Int32.TryParse(UserInput, out UserInputInt);
                }
            }
        }
    }
}