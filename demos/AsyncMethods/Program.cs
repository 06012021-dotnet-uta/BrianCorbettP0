using System;
using System.Threading.Tasks;

namespace AsyncMethods
{
    class Program
    {
        static async Task Main(string[] args)
        {
            AsyncMethodsClass amc = new AsyncMethodsClass();

            // Task<string> task1 = amc.Method1();
            // string method1 = await amc.Method1();
            // Console.WriteLine($"method1 returned {method1}");

            // int method2 = await amc.Method2();                                       << basically asynchronous
            // Console.WriteLine($"method2 returned {method2}");

            // int method3 = await amc.Method3();
            // Console.WriteLine($"method3 returned {method3}");

            // Person method4 = await amc.Method4();
            // Console.WriteLine($"method4 returned {method4.Fname}, age {method4.Age}");

            DateTime start = DateTime.Now;

            Task<string> method1 = amc.Method1();
            Task<int> method2 = amc.Method2();
            Task<int> method3 = amc.Method3();
            Task<Person> method4 = amc.Method4();


            string method1result = await method1;
            Console.WriteLine($"method1 returned {method1result}");

            int method2result = await method2;
            Console.WriteLine($"method2 returned {method2result}");

            int method3result = await method3;
            Console.WriteLine($"method3 returned {method3result}");

            Person method4result = await method4;
            Console.WriteLine($"method4 returned {method4result.Fname}, age {method4result.Age}");

            DateTime finish = DateTime.Now;

            TimeSpan dur = finish.Subtract(start);
            Console.WriteLine(dur);
        }
    }
}
