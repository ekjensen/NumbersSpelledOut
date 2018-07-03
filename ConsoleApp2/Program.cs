using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Enter Your number to be converted: ");
            string input = Console.ReadLine();
            int number = Convert.ToInt32(input);
            WrittenOut(number);

            if (input == "0")
            {
                Console.Write("zero");
            }
        }

        static string WrittenOut(int number)
        {
            // Write out thousands. 
            int thousandCounter = 0;
            while (number >= 1000)
            {
                thousandCounter++;
                number -= 1000;
            }
            if (thousandCounter != 0)
            {
                if (thousandCounter == 9)
                {
                    Console.Write("nine");
                }
                if (thousandCounter == 8)
                {
                    Console.Write("eight");
                }
                if (thousandCounter == 7)
                {
                    Console.Write("seven");
                }
                if (thousandCounter == 6)
                {
                    Console.Write("six");
                }
                if (thousandCounter == 5)
                {
                    Console.Write("five");
                }
                if (thousandCounter == 4)
                {
                    Console.Write("four");
                }
                if (thousandCounter == 3)
                {
                    Console.Write("three");
                }
                if (thousandCounter == 2)
                {
                    Console.Write("two");
                }
                if (thousandCounter == 1)
                {
                    Console.Write("one");
                }
                Console.Write(" thousand");
            }

            // Write out hundreds.
            int hundredCounter = 0;
            while (number >= 100)
            {
                hundredCounter++;
                number -= 100;
            }
            if (hundredCounter != 0)
            {
                if (hundredCounter == 9)
                {
                    Console.Write(" nine");
                }
                if (hundredCounter == 8)
                {
                    Console.Write(" eight");
                }
                if (hundredCounter == 7)
                {
                    Console.Write(" seven");
                }
                if (hundredCounter == 6)
                {
                    Console.Write(" six");
                }
                if (hundredCounter == 5)
                {
                    Console.Write(" five");
                }
                if (hundredCounter == 4)
                {
                    Console.Write(" four");
                }
                if (hundredCounter == 3)
                {
                    Console.Write(" three");
                }
                if (hundredCounter == 2)
                {
                    Console.Write(" two");
                }
                if (hundredCounter == 1)
                {
                    Console.Write(" one");
                }
                Console.Write(" hundred ");
            }

            int tensCounter = 0;
            while (number >= 10)
            {
                tensCounter++;
                number -= 10;
            }
            int singleCounter = 0;
            while (number >= 1)
            {
                singleCounter++;
                number -= 1;
            }
            if (tensCounter != 0)
            {
                if (tensCounter == 9)
                {
                    Console.Write(" ninety");
                }
                if (tensCounter == 8)
                {
                    Console.Write(" eighty");
                }
                if (tensCounter == 7)
                {
                    Console.Write(" seventy");
                }
                if (tensCounter == 6)
                {
                    Console.Write(" sixty");
                }
                if (tensCounter == 5)
                {
                    Console.Write(" fifty");
                }
                if (tensCounter == 4)
                {
                    Console.Write(" forty");
                }
                if (tensCounter == 3)
                {
                    Console.Write(" thirty");
                }
                if (tensCounter == 2)
                {
                    Console.Write(" twenty");
                }
                if (tensCounter == 1)
                {
                    if (singleCounter == 9)
                    {
                        Console.Write(" nineteen");
                    }
                    if (singleCounter == 8)
                    {
                        Console.Write(" eighteen");
                    }
                    if (singleCounter == 7)
                    {
                        Console.Write(" seventeen");
                    }
                    if (singleCounter == 6)
                    {
                        Console.Write(" sixteen");
                    }
                    if (singleCounter == 5)
                    {
                        Console.Write(" fifteen");
                    }
                    if (singleCounter == 4)
                    {
                        Console.Write(" fourteen");
                    }
                    if (singleCounter == 3)
                    {
                        Console.Write(" thirteen");
                    }
                    if (singleCounter == 2)
                    {
                        Console.Write(" twelve");
                    }
                    if (singleCounter == 1)
                    {
                        Console.Write(" eleven");
                    }
                    if (singleCounter == 0)
                    {
                        Console.Write("ten");
                    }
                }
            }

            if (singleCounter != 0 && tensCounter != 1)
            {
                if (singleCounter == 9)
                {
                    Console.Write(" nine");
                }
                if (singleCounter == 8)
                {
                    Console.Write(" eight");
                }
                if (singleCounter == 7)
                {
                    Console.Write(" seven");
                }
                if (singleCounter == 6)
                {
                    Console.Write(" six");
                }
                if (singleCounter == 5)
                {
                    Console.Write(" five");
                }
                if (singleCounter == 4)
                {
                    Console.Write(" four");
                }
                if (singleCounter == 3)
                {
                    Console.Write(" three");
                }
                if (singleCounter == 2)
                {
                    Console.Write(" two");
                }
                if (singleCounter == 1)
                {
                    Console.Write(" one");
                }
            }
            Console.ReadLine();
            return "";
        }       
    }
    
}
