using System;

namespace EventHandlerDemo
{
    public class MethodsClass
    {
        public void OnMessageSend1(object source, MessageEventArgsClass args)
        {
            Console.WriteLine("Add a word to the message");
            string usersMessage = Console.ReadLine(); // get a word from the user
            args.MyString += usersMessage; // append new word to the existing method
        }

        public void OnMessageSend2(object source, MessageEventArgsClass args)
        {
            Console.WriteLine("Add a word to the message");
            string usersMessage = Console.ReadLine(); // get a word from the user
            args.MyString += usersMessage; // append new word to the existing method
        }
    }
}