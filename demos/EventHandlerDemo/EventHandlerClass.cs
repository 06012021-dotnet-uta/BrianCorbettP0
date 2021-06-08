using System;

namespace EventHandlerDemo
{
    public class EventHandlerClass
    {
        // 1. create the delegate type
        public delegate void MessageHandler(object source, MessageEventArgsClass args); // delegates require EventArgs which MessageEventArgsClass inherits from

        // 2. instantiate the delegate
        public event MessageHandler myMessageHandler;

        // 3. create a method that will raise the event through this preparatory/protector method
        public void MessageSend(string message)
        {
            message += message;
            OnMessageSend(message);
        }

        // 4. create the method that actually raises the event
        private void OnMessageSend(string message)
        {
            // check if there are any subscribers to the delegate
            if (myMessageHandler != null)
            {
                // create instance of MessageEvent to send with the event
                MessageEventArgsClass meac = new MessageEventArgsClass() { MyString = message };
                // invoke the event with 'this' which is the current context class
                myMessageHandler(this, meac);
                Console.WriteLine(meac.MyString);
            }
            else
            {
                Console.WriteLine("there were no subscribers");
            }
        }
    }//EoClass
}//EoNamespace