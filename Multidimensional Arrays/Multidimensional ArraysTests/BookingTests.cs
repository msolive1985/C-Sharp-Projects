using Microsoft.VisualStudio.TestTools.UnitTesting;
using Multidimensional_Arrays;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multidimensional_Arrays.Tests
{
    [TestClass()]
    public class BookingTests
    {
        [TestMethod()]
        public void reservedSeatsFunctionTest1()
        {
            Booking bobj = new Booking(2, "1A 2F 1C 2J");
            Console.WriteLine("{0}", bobj.reservedSeatsFunction().ToString());
        }

        public void reservedSeatsFunctionTest2()
        {
            Booking bobj = new Booking(2, "1A 2F 1C");
            Console.WriteLine("{0}", bobj.reservedSeatsFunction().ToString());
        }

        public void reservedSeatsFunctionTest3()
        {
            Booking bobj = new Booking(40, "1A 3C 40G 5A");
            Console.WriteLine("{0}", bobj.reservedSeatsFunction().ToString());
        }

        public void reservedSeatsFunctionTest4()
        {
            Booking bobj = new Booking(1, "");
            Console.WriteLine("{0}", bobj.reservedSeatsFunction().ToString());
        }

        public void reservedSeatsFunctionTest5()
        {
            Booking bobj = new Booking(-11, "1A");
            Console.WriteLine("{0}", bobj.reservedSeatsFunction().ToString());
        }

        public void reservedSeatsFunctionTest6()
        {
            Booking bobj = new Booking(30, "2A 3E 4A");
            Console.WriteLine("{0}", bobj.reservedSeatsFunction().ToString());
        }

        public void reservedSeatsFunctionTest7()
        {
            Booking bobj = new Booking(51, "1A 3C 40G 5A");
            Console.WriteLine("{0}", bobj.reservedSeatsFunction().ToString());
        }
    }
}