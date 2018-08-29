using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multidimensional_Arrays
{
    public class Messages
    {
        /// <summary>
        /// Print error messages according to cases
        /// </summary>
        /// <param name="opc">Value return from reservedSeatsFunction function.</param>
        /// <param name="num">Value entered by the user.</param>
        /// <returns></returns>
        public string printErrorMessages(int opc, int num)
        {
            string result = string.Empty;
            switch (opc)
            {
                case -1:
                    result = "Error: The maximum number of seats (N) is an integer between 1 and 50.";
                    break;
                case -2:
                    result = "Error: the reserved seats (S) consist of valid seat names separated with spaces";
                    break;
                case -3:
                    result = "Error: there is a duplicate value in S. Every seat number appears is string S at most once.";
                    break;
                case -4:
                    result = "Error: M is an integer between 0 and 909. You don't have more than row 50 and column K seats.";
                    break;
                case -5:
                    result = "Error: You can only choose enter a min value of 1 and a max value of " + num; 
                    break;
                case -6:
                    result = "Error: You can only choose between letter A to K (I is not included).";
                    break;
                case -7:
                    result = "Error: An unexpected error just happened. Please check the values you entered.";
                    break;
                default:
                    result = "Error: You can only choose between letter A to K (I is not included).";
                    break;
            }

            return result;
        }
    }
}
