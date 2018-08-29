using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExampleProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleProject.Tests
{
    [TestClass()]
    public class PalindromeTests
    {
        [TestMethod()]
        public void checkPalindromeEvenTest1()
        {
            //Result should be true
            Palindrome pl = new Palindrome("adda");
            pl.printPalindrome();            
        }
        public void checkPalindromeEvenTest2()
        {
            //Result should be true
            Palindrome pl = new Palindrome("aaff");
            pl.printPalindrome();
        }
        public void checkPalindromeEvenTest3()
        {
            //Result should be false
            Palindrome pl = new Palindrome("fddd");
            pl.printPalindrome();
        }

        public void checkPalindromeOddTest1()
        {
            //Result should be true            
            Palindrome pl = new Palindrome("adddad");
            pl.printPalindrome();
        }

        public void checkPalindromeOddTest2()
        {
            //Result should be true
            Palindrome pl = new Palindrome("aaffaa");
            pl.printPalindrome();
        }
        public void checkPalindromeOddTest3()
        {
            //Result should be false
            Palindrome pl = new Palindrome("hgfhj");
            pl.printPalindrome();
        }
    }
}