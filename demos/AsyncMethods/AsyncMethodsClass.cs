using System.Threading.Tasks;

namespace AsyncMethods
{
    public class AsyncMethodsClass
    {
        public async Task<string> Method1()
        {
            System.Console.WriteLine("MEthod 1 BT");
            Task task = Task.Delay(4000);
            System.Console.WriteLine("MEthod 1 AT");


            // System.Console.WriteLine("Please enter a sentence");
            // string userInput = Console.ReadLine();


            await task;
            System.Console.WriteLine("MEthod 1 AAwaitingT");

            return "userInput";
        }

        public async Task<int> Method2()
        {

            System.Console.WriteLine("MEthod 2 BT");
            Task task = Task.Delay(3000);
            System.Console.WriteLine("MEthod 2 AT");

            await task;
            System.Console.WriteLine("MEthod 2 AAwaitingT");

            return 1;
        }
        public async Task<int> Method3()
        {

            System.Console.WriteLine("MEthod 3 BT");
            Task task = Task.Delay(3000);
            System.Console.WriteLine("MEthod 3 AT");

            await task;
            System.Console.WriteLine("MEthod 3 AAwaitingT");

            return 1;
        }
        public async Task<Person> Method4()
        {

            System.Console.WriteLine("MEthod 4 BT");
            Task task = Task.Delay(3000);
            System.Console.WriteLine("MEthod 4 AT");
            Person p = new Person() { Fname = "Ethan", Age = 50 };
            await task;
            System.Console.WriteLine("MEthod 4 AAwaitingT");

            return p;
        }
    }
}