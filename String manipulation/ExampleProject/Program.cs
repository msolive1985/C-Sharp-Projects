using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleProject
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = 0;
            Console.Write("\n Enter a number, this number will be the words to be analysed: ");
            num = Convert.ToInt32(Console.ReadLine());
            string[] array = new string[num];
            for (int i = 0; i < num; i++)
            {
                Console.Write("\n Enter a word #{0} value: ", i + 1);
                array[i] = Console.ReadLine();
            }

            foreach (string value in array)
            {
                Palindrome pl = new Palindrome(value);
                pl.printPalindrome();
            }

            Console.ReadLine();
        }
    }
}
