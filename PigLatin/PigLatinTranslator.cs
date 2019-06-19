using System;
using System.Collections.Generic;
using System.Linq;

namespace PigLatin
{
    public static class PigLatinTranslator
    {
        public static string Translate(string input)
        {
            Func<string, string> map = s =>
            {
                return StartsWithVowel(s)
                    ? s + "ay"
                    : FormatForConsonantCluster(s);
            };
            Func<string, string> format = s =>
            {
                var punctuation = s.SkipWhile(x => !Char.IsPunctuation(x));
                var removedPunctuation = punctuation.Any() ? s.Remove(s.Length - punctuation.Count()) : s;
                var transformedWord = map(removedPunctuation);
                transformedWord = transformedWord.ToLower();
                if (Char.IsUpper(s[0]))
                {
                    transformedWord = Char.ToUpper(transformedWord[0]) + transformedWord.Substring(1);
                }

                return transformedWord + String.Join("", punctuation);
            };
            var formattedWords = input.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(format);
            return String.Join(" ", formattedWords);
        }

        // 1). Remove Punctuation (keeping track of what it is)
        // 2). Keep track of the casing of the consonant cluster or vowel
        // 3). Transform
        // 4). ToLower the entire transformation
        // 5). Update the casing of the first letter (if needed)
        // 6). Add back punctuation

        private static string FormatForConsonantCluster(string input)
        {
            var consonants = input.TakeWhile(x => !IsVowel(x));
            return input.Substring(consonants.Count()) + new String(consonants.ToArray()) + "ay";
        }

        private static bool StartsWithVowel(string word)
        {
            return IsVowel(word[0]);
        }

        private static bool IsVowel(char letter)
        {
            return new List<char> {'a', 'e', 'i', 'o', 'u'}.Contains(letter);
        }


    }
}
