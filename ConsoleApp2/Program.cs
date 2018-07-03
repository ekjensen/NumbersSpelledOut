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

            // Validate the user's input.
            // The number only supports up to thousands. 
            if (number > 9999)
            {
                Console.WriteLine("This program only supports numbers up to 9999");
                return;
            }
            // The program does not support negative numbers. 
            if (number <= 0)
            {
                Console.WriteLine("This program only accepts numbers greather or equal to.");
                return;
            }

            Console.WriteLine("The number you entered was: ");
            var converter = new NumberToTextConverter(LetterCase.TitleCase, "-uhhh-");
            var fullNumberText = converter.GetText(number);
            Console.WriteLine(fullNumberText);

            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
    }
}
