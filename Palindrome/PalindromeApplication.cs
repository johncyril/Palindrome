using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Palindrome
{
    /// <summary>
    /// Given more time, I could probably split this out a bit and write some unit tests.
    /// </summary>
    public class PalindromeApplication
    {
        int numberOfPalindromesToShow;
        string inputString;
        public void Run()
        {
            greet();
            takeDesiredNumberOfPalindromes();
            takeStringToDiscoverPalindromesWithin();
            presentResults(findPalindromes());
        }

        private void presentResults(List<string> results)
        {
            Console.WriteLine(string.Format("A total of {0} palindromes were found - woohoo! \n We'll now show you no more than the longest {1} as promised.",results.Count, numberOfPalindromesToShow));
            var resultsToPresent = results.OrderByDescending(x=>x.Length).Take(numberOfPalindromesToShow);
            foreach (var result in resultsToPresent)
            {
                Console.Write(string.Format("Text: {0}",result));
                Console.Write(string.Format(", Index: {0} ", inputString.IndexOf(result)));
                Console.Write(string.Format(", Length: {0} ", result.Length));
                Console.WriteLine();
            }

            Console.ReadLine();
        }

        private List<string> findPalindromes()
        {
            var palindromeFinder = new PalindromeFinder();
            palindromeFinder.Initialize();
            return palindromeFinder.FindPalindromes(inputString).ToList();
        }

        private void takeStringToDiscoverPalindromesWithin()
        {
            Console.WriteLine("Now please enter your string to discover any palindromes");
            inputString = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(inputString))            
            {
                Console.WriteLine("I'm sorry. We can't look for palindromes in empty strings.");
                inputString = Console.ReadLine();
            }
        }

        private void takeDesiredNumberOfPalindromes()
        {
            Console.WriteLine("If there is a maximum number of palindromes you would like to see, please enter it now. If not, just hit <enter> - We'll default to 3!");
            if (!Int32.TryParse( Console.ReadLine(), out numberOfPalindromesToShow))
            {
                Console.WriteLine("As a valid number was not provided, we're defaulting to show you the 3 longest palindromes.");
                numberOfPalindromesToShow = 3;
            }
            else {
                Console.WriteLine("Thanks");
            }
        }

        private void greet()
        {
            Console.WriteLine("Welcome to the awesome Palindrome finder! This program will find valid unique palindromes in a given string, sorted by length");
        }
    }
}
