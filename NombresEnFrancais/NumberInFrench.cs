namespace NombresEnFrancais
{
    public static class NumberInFrench
    {
        const string Separator = "-";

        public static string GetNumberInFrench(int number)
        {
            var numberMapping = new Dictionary<int, string>
            {
                { 0, "zero"},
                { 1, "un"},
                { 2, "deux"},
                { 3, "trois"},
                { 4, "quatre"},
                { 5, "cinq"},
                { 6, "six"},
                { 7, "sept"},
                { 8, "huit"},
                { 9, "neuf"},
                { 10, "dix"},
                { 11, "onze"},
                { 12, "douze"},
                { 13, "treize"},
                { 14, "quatorze"},
                { 15, "quinze"},
                { 16, "seize"},
                { 20, "vingt"},
                { 30, "trente"},
                { 40, "quarante"},
                { 50, "cinquante"},
                { 60, "soixante"},
                { 80, "quatre-vingt"},
                { 81, "quatre-vingt-un"}
            };

            if (numberMapping.ContainsKey(number))
            {
                return numberMapping[number] + (number == 80 ?  "s" : string.Empty);
            }

            var lastDigit = number % 10;
            var tens = number / 10 * 10;
            if (tens == 70)
            {
                tens -= 10;
            }

            return numberMapping[tens] + GetSeparator(lastDigit) + GetNumberInFrench(number - tens);
        }

        private static string GetSeparator(int lastDigit)
        {
            return lastDigit == 1
                ? $"{Separator}et{Separator}"
                : Separator;
        }
    }
}
