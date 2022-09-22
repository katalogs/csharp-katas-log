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
                _ => ConvertToString(number / 10 * 10) + "-" + ConvertToString(number % 10).ToLower()
            };
        }
    }
}
