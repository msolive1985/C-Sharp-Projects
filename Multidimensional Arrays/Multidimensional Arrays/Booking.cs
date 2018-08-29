using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Multidimensional_Arrays
{
    public class Booking
    {
        private int N;
        private string S;
        private string[] planeSeats = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "J", "K" }; //		

        /// <summary>
        /// Constructor of the class for booking seats on a plane. 
        /// </summary>
        /// <param name="_N">This is the number of seats in a plane. The plane only has 50 chairs</param>
        /// <param name="_S">This is the letter next to the number of the plane. It goes from A to K and this program should ignore letter I.</param>
        public Booking(int _N, string _S)
        {
            N = _N;
            S = _S;
        }

        /// <summary>
        /// Function to return the number of families of 3 members that can be accommodated in a plane having into consideration that there is an array of reserved seats. 
        /// </summary>
        /// <returns>Returns the possible combinations</returns>
        public int reservedSeatsFunction()
        {            
            int result = 0;
            int countEmpty = 0;

            if (N < 1 | N > 50)
            {
                return -1; // N is an integer between 1 and 50
            }

            if (S == string.Empty)
            {
                return (N * 3); // Because we can seat at most three families
            }            

            string[] reservedSeats = S.Split(' ');

            foreach (string seat in reservedSeats)
            {
                if (seat.Length > 3)
                {
                    return -2; // S consist of valid seat names separated with spaces
                }

            }

            if (reservedSeats.Length != reservedSeats.Distinct().Count())
            {
                return -3; // Duplicate value. Every seat number appears is string S at most once.
            }

            if (reservedSeats.Length > 909)
            {
                return -4; // M is an integer between 0 and 909. You don't have more than 50K seats
            }

            string[,] M = new string[N, 10];

            //1. Fill matrix with value reserved
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    foreach (string value in reservedSeats)
                    {
                        try
                        {
                            var cadAux = new Regex("(?<Numeric>[0-9]*/*[0-9]*)(?<Alpha>[a-zA-Z]*)");
                            var match = cadAux.Match(value);

                            if (int.Parse(match.Groups["Numeric"].Value) <= 0 | int.Parse(match.Groups["Numeric"].Value) > N)
                                return -5; // You can only choose enter a min value of 1 and a max value of N

                            int valAux1 = int.Parse(match.Groups["Numeric"].Value) - 1;

                            if (!planeSeats.Contains(match.Groups["Alpha"].Value.ToUpper()))
                                return -6; // You can only choose between letter A to K (I is not included)

                            int valAux2 = Array.IndexOf(planeSeats, match.Groups["Alpha"].Value.ToUpper());
                            if (M[valAux1, valAux2] == null) M[valAux1, valAux2] = "O";
                        }
                        catch(Exception e)
                        {
                            Console.WriteLine(e.Message);
                            return -7;       
                        }                          
                    }

                    //2. Making combinations for ABC
                    // Check firsts seats
                    if (M[i, 0] == "O" | M[i, 2] == "O")
                    {
                        M[i, 1] = "X";
                    }

                    if (M[i, 1] == "O" | M[i, 1] == "X")
                    {
                        M[i, 0] = "X";
                        M[i, 2] = "X";
                    }


                    //Check middle seats												
                    if (M[i, 3] == "O" | M[i, 4] == "O" | M[i, 5] == "O" | M[i, 6] == "O")
                    {
                        M[i, 3] = "X";
                        M[i, 4] = "X";
                        M[i, 5] = "X";
                        M[i, 6] = "X";
                    }

                    //Checkk last seats
                    if (M[i, 7] == "O" | M[i, 9] == "O")
                    {
                        M[i, 8] = "X";
                    }

                    if (M[i, 8] == "O" | M[i, 8] == "X")
                    {
                        M[i, 7] = "X";
                        M[i, 9] = "X";
                    }

                    if (M[i, j] == null)
                    {
                        M[i, j] = "Y";
                    }

                    Console.Write(string.Format("{0} ", M[i, j]));
                }
                Console.Write(Environment.NewLine + Environment.NewLine);
            }

            for (int i = 0; i < N; i++)
            {
                if (M[i, 2] == "Y")
                {
                    countEmpty++;
                }

                if (M[i, 6] == "Y")
                {
                    countEmpty++;
                }

                if (M[i, 9] == "Y")
                {
                    countEmpty++;
                }
            }

            result = countEmpty;
            return result;
        }
    }
}
