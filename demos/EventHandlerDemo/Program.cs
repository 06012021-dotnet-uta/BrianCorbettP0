using System;

namespace EventHandlerDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            EventHandlerClass eventHandlerClass = new EventHandlerClass();
            MethodsClass methodsClass = new MethodsClass();

            eventHandlerClass.myMessageHandler += methodsClass.OnMessageSend1;// you can only subscribe methods to the event with '+='
            eventHandlerClass.myMessageHandler += methodsClass.OnMessageSend2;

            System.Console.WriteLine("Enter a word");
            string message = Console.ReadLine(); // get message from user
            eventHandlerClass.MessageSend(message); // invoke the prep/protected method to the event
        }
    }
}
