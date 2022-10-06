namespace Converter
{
    public class NumberConverter
    {
        public string ConvertToString(int number)
        {
            return number switch
            {
                0 => "Zéro",
                1 => "Un",
                2 => "Deux",
                3 => "Trois",
                4 => "Quatre",
                5 => "Cinq",
                6 => "Six",
                7 => "Sept",
                8 => "Huit",
                9 => "Neuf",
                10 => "Dix",
                11 => "Onze",
                12 => "Douze",
                13 => "Treize",
                14 => "Quatorze",
                15 => "Quinze",
                16 => "Seize",
                20 => "Vingt",
                30 => "Trente",
                40 => "Quarante",
                50 => "Cinquante",
                60 => "Soixante",
                80 => "Quatre-vingts",
                81 => "Quatre-vingt-un",
                > 81 and <= 99 => ConvertToString(GetTens(number))[..^1] + GetSeparator(number) +
                                  ConvertToString(number - GetTens(number))
                                      .ToLower(),
                _ => ConvertToString(GetTens(number)) + GetSeparator(number) + ConvertToString(number - GetTens(number))
                    .ToLower()
            };
        }

        private static int GetTens(int number)
            => number / 10 * 10 is 70 or 90
                ? number / 10 * 10 - 10 
                : number / 10 * 10;

        private static string GetSeparator(int number)  
            => number % 10 == 1 ? "-et-" : "-";
    }
}
