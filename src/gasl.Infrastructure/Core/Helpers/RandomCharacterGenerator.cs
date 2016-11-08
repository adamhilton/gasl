using System;
using System.Linq;

namespace gasl.Infrastructure.Core.Helpers
{
    public class RandomCharacterGenerator
    {
        private static Random random = new Random();
        private static string PossibleCharacters = 
            "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        public static string GetCharacters(int characterLength) {
            return new string(Enumerable.Repeat(PossibleCharacters, characterLength)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}