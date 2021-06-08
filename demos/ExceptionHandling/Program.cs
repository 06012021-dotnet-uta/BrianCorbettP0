using System;

//usage error: program throw errors into program
//program error:
//system error: 

namespace ExceptionHandling
{
    class Program
    {
        static void Main(string[] args)
        {
            int five = 5;
            int zero = 0;
            for (int x = 0; x < 5; x++)
            {
                try
                {
                    int a = five / zero;
                }
                catch (ArithmeticException)
                {
                    Console.WriteLine("\nMoving on.\n");
                    //throw new ArithmeticException("That was a boo boo", ex);
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    Console.WriteLine("This is the finally block.");
                    if (zero == 0)
                    {
                        zero = 5;
                    }
                    else if (zero == 5)
                    {
                        zero = 0;
                    }
                }//try-catch-finally
            }//for-loop
        }//Main
    }//Program
}//ExceptionHandling
