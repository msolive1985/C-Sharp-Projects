using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using nsClearConsole;

namespace Multidimensional_Arrays
{
    public class MainProgram
    {        
        static void Main(string[] args)
        {
            int num = 0;
            string seats = string.Empty;
            bool vcontinue = true;
            ClearConsole ClearMyConsole = new ClearConsole();
            Messages mobj = new Messages();

            while (vcontinue)
            {                
                Console.Write("Enter maximum number of seats (N): ");
                num = Convert.ToInt32(Console.ReadLine());
                
                Console.Write("Enter reserved seats separated by spaces (S): ");
                seats = Console.ReadLine();

                Console.Write("You data is N= {0} rows and S = [{1}] reserved seats.\n", num, seats);

                Booking bobj = new Booking(num, seats);
                int solVal = bobj.reservedSeatsFunction();

                if (solVal > 0)
                    Console.WriteLine("{0} families of 3 members were accomodated in this flight.", solVal);
                else
                {
                    Console.WriteLine("There is an error in your input data. Check your details again.");
                    Console.WriteLine("{0}", mobj.printErrorMessages(solVal, num));
                }

                Console.WriteLine("Do you wish to continue? (y/n)");
                string menu = Console.ReadLine();

                switch (menu)
                {
                    case "y":
                        ClearMyConsole.Clear();
                        break;

                    case "Y":
                        ClearMyConsole.Clear();
                        break;

                    default:
                        vcontinue = false;
                        break;
                }
            }        
        }
    }
}
