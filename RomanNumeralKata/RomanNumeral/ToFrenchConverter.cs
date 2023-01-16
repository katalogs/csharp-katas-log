using System.Collections.Generic;

namespace RomanNumerals
{
    public class ToFrenchConverter
    {
        private Dictionary<int, string> dictionaryUnit =
            new Dictionary<int, string>
            {
                {0, "Zéro"},
                {1, "Un"},
                {2, "Deux"},
                {3, "Trois"},
                {4, "Quatre"},
                {5, "Cinq"},
                {6, "Six"},
                {7, "Sept"},
                {8, "Huit"},
                {9, "Neuf"},
            };

        public ToFrenchConverter()
        {
        }

        public string Convert(int number)
        {
            return dictionaryUnit[number];
        }
    }
}
