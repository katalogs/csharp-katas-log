namespace Converter
{
    public class NumberConverter
    {
        public string ConvertToString(int number)
        {
            return number switch
            {
                0 => "zero",
                1 => "un",
                2 => "deux",
                3 => "trois",
                4 => "quatre",
                5 => "cinq",
                6 => "six",
                7 => "sept",
                8 => "huit",
                9 => "neuf",
                10 => "dix",
                11 => "onze",
                12 => "douze",
                13 => "treize",
                14 => "quatorze",
                15 => "quinze",
                _ => "seize"
            };
        }
    }
}
