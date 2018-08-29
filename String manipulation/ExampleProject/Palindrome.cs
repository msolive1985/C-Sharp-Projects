using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleProject
{
    public class Palindrome
    {
        string _value;
        public Palindrome(string value)
        {
            _value = value;
        }

        // Even size strings iterate the whole array 
        // Odd size strings stop one short         
        public string StringSwap(string stringToSwap)
        {
            char[] array = stringToSwap.ToCharArray();
            int offset = (stringToSwap.Length % 2);

            for (int i = 0; i < array.Length - offset; i += 2)
            {
                char temp = array[i];
                array[i] = array[i + 1];
                array[i + 1] = temp;
            }

            return new String(array);
        }

        public bool checkPalindrome()
        {
            Console.Write("\n value: {0}", _value);
            var reversed = StringSwap(_value);
            var palindrome = _value == reversed;

            if (palindrome == false)
            {
                string checkIfOneWordWorks = _value.Remove(_value.Length - 1, 1);
                var auxReversed1 = new string(checkIfOneWordWorks.Reverse().ToArray());
                palindrome = checkIfOneWordWorks == auxReversed1;

                if (palindrome == false)
                {
                    string checkIfTwoWordWorks = checkIfOneWordWorks.Remove(checkIfOneWordWorks.Length - 1, 1);
                    var auxReversed2 = new string(checkIfTwoWordWorks.Reverse().ToArray());
                    palindrome = checkIfTwoWordWorks == auxReversed2;
                }
            }

            return palindrome;
        }

        public void printPalindrome()
        {
            Console.WriteLine("\n {0} = {1}", _value, checkPalindrome());
        }
    }
}
