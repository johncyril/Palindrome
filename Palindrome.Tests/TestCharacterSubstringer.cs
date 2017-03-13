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
    public class TestCharacterSubstringer
    {
        private CharacterSubstringer testSubstringer;

        private void setUp()
        {
            testSubstringer = new CharacterSubstringer();
        }

        [TestMethod]
        public void TestSubstringerHandlesNullOrEmptyTestInput()
        {
            var testInput = "";
            var testChar = 'a';
            setUp();
            var results = testSubstringer.FindSubstrings(testInput,testChar);
            Assert.IsNull(results);
        }

        [TestMethod]
        public void TestSubstringerHandleWhitespaceTestChar()
        {
            var testInput = "abagagagjdk";
            var testChar = ' ';
            setUp();
            var results = testSubstringer.FindSubstrings(testInput, testChar);
            Assert.IsNull(results);
        }

        [TestMethod]
        public void TestSubstringerReturnsCorrectSubstrings()
        {
            var testInput = "aazbbzccz";
            var testChar = 'z';
            setUp();
            var results = testSubstringer.FindSubstrings(testInput, testChar);
            Assert.AreEqual(3, results.Count);
            Assert.IsTrue(results.Contains("aaz"));
            Assert.IsTrue(results.Contains("aazbbz"));
            Assert.IsTrue(results.Contains("aazbbzccz"));
        }

        [TestMethod]
        public void TestSubstringerHandlesMixedCasing()
        {
            var testInput = "aazbbZccz";
            var testChar = 'z';
            setUp();
            var results = testSubstringer.FindSubstrings(testInput, testChar);
            Assert.AreEqual(3, results.Count);
            Assert.IsTrue(results.Contains("aaz"));
            Assert.IsTrue(results.Contains("aazbbZ"));
            Assert.IsTrue(results.Contains("aazbbZccz"));
        }

        [TestMethod]
        public void TestSubstringerReturnsCorrectSubstringsDespiteSameCharacters()
        {
            var testInput = "aaaaaaaaaaaa";
            var testChar = 'a';
            setUp();
            var results = testSubstringer.FindSubstrings(testInput, testChar);
            Assert.AreEqual(12, results.Count);
        }

        [TestMethod]
        public void TestSubstringerReturnsNoResultsIfNoMatchess()
        {
            var testInput = "aaaaaaaaaaaa";
            var testChar = 'd';
            setUp();
            var results = testSubstringer.FindSubstrings(testInput, testChar);
            Assert.AreEqual(0,results.Count);           
        }
    }
}
