using System;

namespace P0
{
    public class Write : IWrite
    {
        public void PutLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}