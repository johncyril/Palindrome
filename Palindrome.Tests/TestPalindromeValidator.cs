using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Palindrome;

namespace Palindrome.Tests
{
    [TestClass]
    public class TestPalindromeValidator
    {
        private PalindromeValidator testValidator;

        private void SetUp()
        {
            testValidator = new PalindromeValidator();
        }

        [TestMethod]
        public void TestPalindromeVaidatorHandlesNullInput()
        {
            var testInput = "    ";
            SetUp();
            Assert.IsFalse(testValidator.IsValidPalindrome(testInput));
        }

        [TestMethod]
        public void TestPalindromeVaidatorIdentifiesNonPalindromes()
        {
            var testInput = "hijkllkh";
            SetUp();
            Assert.IsFalse(testValidator.IsValidPalindrome(testInput));
        }

        [TestMethod]
        public void TestPalindromeVaidatorWorksWithEvenCharPallindromes()
        {
            var testInput = "hijkllkjih";
            SetUp();
            Assert.IsTrue(testValidator.IsValidPalindrome(testInput));
        }

        [TestMethod]
        public void TestPalindromeVaidatorWorksWithOddCharPallindromes()
        {
            var testInput = "hijklkjih";
            SetUp();
            Assert.IsTrue(testValidator.IsValidPalindrome(testInput));
        }

        [TestMethod]
        public void TestPalindromeVaidatorInvalidatesSingleCharInput()
        {
            var testInput = "a";
            SetUp();
            Assert.IsFalse(testValidator.IsValidPalindrome(testInput));
        }

        [TestMethod]
        public void TestPalindromeVaidatorDoesntMindMixedCasing()
        {
            var testInput = "dEfGgfeD";
            SetUp();
            Assert.IsTrue(testValidator.IsValidPalindrome(testInput));
        }

        [TestMethod]
        public void TestPalindromeVaidatorDoesntMindLettersAndNumbers()
        {
            var testInput = "d1331D";
            SetUp();
            Assert.IsTrue(testValidator.IsValidPalindrome(testInput));
        }

        [TestMethod]
        public void TestPalindromeVaidatorHandlesPalindromesAccrossWhitespace()
        {
            var testInput = "d13  31D";
            SetUp();
            Assert.IsTrue(testValidator.IsValidPalindrome(testInput));
        }

        [TestMethod]
        public void TestPalindromeVaidatorHandlesPalindromesDespitePunctuation()
        {
            var testInput = "Live on time, emit no evil!?";
            SetUp();
            Assert.IsTrue(testValidator.IsValidPalindrome(testInput));
        }
    }
}
