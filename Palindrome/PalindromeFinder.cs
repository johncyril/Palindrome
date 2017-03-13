using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Palindrome
{
    /// <summary>
    /// We will assume the definition of a palindrome is as follows:
    /// 
    /// A palindrome is a word, phrase, number, or other sequence of characters which reads the same backward as forward, such as madam or racecar. 
    /// Sentence-length palindromes may be written when allowances are made for adjustments to capital letters, punctuation, and word dividers,
    /// such as "A man, a plan, a canal, Panama!", "Was it a car or a cat I saw?" or "No 'x' in Nixon".
    /// 
    /// It is noted that the challenge spec provided examples of palindromes of even character length, however we will consider a palindrome also to include odd character lengths.
    /// There is no assumption that palindromes can't overlap. It is not clear if there is assumption that "unique" palindromes can't be nested? 
    /// Palindromes > 4 characters in length are by definition compromised of smaller palindromes.
    /// The example output in the spec gives a 3rd palindrome of length 6, when actually another nested palindrome of 8 can be found in the first.
    /// We will assume nested pallindromes are valid in this exercise.
    /// </summary>
    public class PalindromeFinder
    {
        private HashSet<string> palindromeCollection;
        private CharacterSubstringer substringer;
        private PalindromeValidator validator;

        public void Initialize()
        {
            palindromeCollection = new HashSet<string>();
            substringer = new CharacterSubstringer();
            validator = new PalindromeValidator();
        }
        
        public IEnumerable<string> FindPalindromes(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) throw new ArgumentException("input string cannot be null or empty");

            //STEP 1. A palindrome will start and end with the same character.
            //we'll start by geting all the (unique) substrings that start and end with the same character.
            HashSet<string> substrings = new HashSet<string>(StringComparer.InvariantCultureIgnoreCase);

            for (int i = 0; i < input.Length; i++)
            {
                var startAndEndChar = input[i];
                var results = substringer.FindSubstrings(input.Substring(i), input[i]);
                if (results == null) break;
                foreach (var result in results)
                {
                    substrings.Add(result);
                }
            }

            //STEP 2. All previously obtained substrings will be validated to see if they meet Palindrome criterion
            // If they do, they will be added to the Palindrome HashSet which will ensure uniqueness. 
            foreach (var substring in substrings)
            {
                if (validator.IsValidPalindrome(substring))
                {
                    palindromeCollection.Add(substring);
                }
            }

            return palindromeCollection;
        }
    }
}
