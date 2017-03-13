using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Palindrome
{
    public class PalindromeValidator
    {
        /// <summary>
        /// Sentence-length palindromes may be written when allowances are made for adjustments to capital letters, punctuation, and word dividers,
        /// such as "A man, a plan, a canal, Panama!", "Was it a car or a cat I saw?" or "No 'x' in Nixon".
        /// 
        /// We will validate any given string, by removing whitespace, punctuation and normalising casing.
        /// As a palindrome must be a sequence of characters, single characters are not considered palindromes.
        /// </summary>
        /// <param name="substring"></param>
        /// <returns></returns>
        public bool IsValidPalindrome(string input)
        {
            var preparedString = prepareString(input);

            if (string.IsNullOrEmpty(preparedString) || string.IsNullOrWhiteSpace(preparedString) || preparedString.Count() <2) return false;
            if (preparedString.Equals(reverseString(preparedString))) return true;
            return false;
        }

        private string reverseString(string preparedString)
        {
            return new string(preparedString.Reverse().ToArray());
        }

        private string prepareString(string input)
        {
            var sb = new StringBuilder();

            foreach (var character in input.ToLower())
            {
                if (!char.IsPunctuation(character))
                {
                    sb.Append(character);
                }
            }

            return sb.ToString();
        }
    }
}
