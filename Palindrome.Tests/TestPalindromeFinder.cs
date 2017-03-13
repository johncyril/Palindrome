using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Palindrome;


namespace Palindrome
{
    [TestClass]
    public class TestPalindromeFinder
    {
        private PalindromeFinder testFinder;

        private void setUp()
        {
            testFinder = new PalindromeFinder();
            testFinder.Initialize();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void testFinderHandlesNullOrEmptyStrings()
        {
            setUp();
            var results = testFinder.FindPalindromes(" ");            
        }

        [TestMethod]
        public void testFinderReturnsCorrectNumberOfPalindromes()
        {
            setUp();
            var results = testFinder.FindPalindromes("Hannah");
            Assert.AreEqual(3, results.Count());
        }

        [TestMethod]
        public void testFinderReturnsOnlyUniquePalindromes()
        {
            setUp();
            var results = testFinder.FindPalindromes("hannahiuhweqrhannah");
            Assert.AreEqual(3, results.Count());
        }

        [TestMethod]
        public void testFinderReturnsOnlyUniquePalindromesDespiteMixedCase()
        {
            setUp();
            var results = testFinder.FindPalindromes("HAnnAhiuhweqrHannah");
            Assert.AreEqual(3, results.Count());
        }

        [TestMethod]
        public void testFinderReturnsOnlyUniquePalindromesDespiteMixedCaseAndWhitespace()
        {
            setUp();
            var results = testFinder.FindPalindromes("HAn nAhiu hweqrH an nah");
            Assert.AreEqual(3, results.Count());
        }

        [TestMethod]
        public void testFinderHandlesOverlappingPalindromes()
        {
            setUp();
            var results = testFinder.FindPalindromes("abdfdbabdf");
            Assert.AreEqual(6, results.Count());
        }
    }
}
