using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Palindrome
{
    /// <summary>
    /// Will return all unique substrings from input[0] to ocurrences of given character
    /// </summary>
    public class CharacterSubstringer
    {
        public HashSet<string> FindSubstrings(string input, char character)
        {
            if (string.IsNullOrEmpty(input))
            {
                //usually we would log
                Console.WriteLine("input string cannot be null or empty");
                return null;
            }
            if (character == ' ')
            {
                Console.WriteLine("Strings that end in whitespace are not supported");
                return null;            
            }

            var substringList = new HashSet<string>(StringComparer.InvariantCultureIgnoreCase);

            int start = 0;
            int end = 0;

            while ((start < input.Length))
            {
                end = input.IndexOf(character.ToString(), start, StringComparison.InvariantCultureIgnoreCase);
                if (end == -1) break;
                substringList.Add(input.Substring(0, end+1));
                start = end +1;
            }

            return substringList;
        }
    }
}
