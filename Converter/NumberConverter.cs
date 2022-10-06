namespace Converter
{
    public class NumberConverter
    {
        public string ConvertToString(int number)
        {
            switch (number)
            {
                case 0:
                    return "Zéro";
                case 1:
                    return "Un";
                case 2:
                    return "Deux";
                case 3:
                    return "Trois";
                case 4:
                    return "Quatre";
                case 5:
                    return "Cinq";
                case 6:
                    return "Six";
                case 7:
                    return "Sept";
                case 8:
                    return "Huit";
                case 9:
                    return "Neuf";
                case 10:
                    return "Dix";
                case 11:
                    return "Onze";
                case 12:
                    return "Douze";
                case 13:
                    return "Treize";
                case 14:
                    return "Quatorze";
                case 15:
                    return "Quinze";
                case 16:
                    return "Seize";
                case 20:
                    return "Vingt";
                case 30:
                    return "Trente";
                case 40:
                    return "Quarante";
                case 50:
                    return "Cinquante";
                case 60:
                    return "Soixante";
                case 80:
                    return "Quatre-vingts";
                case int n when n > 80 && n <= 89:
                    return ConvertToString(GetTens(number))[..^1] +
                        GetSeparator(number) +
                        ConvertToString(number - GetTens(number))
                            .ToLower();
                default:
                    return ConvertToString(GetTens(number)) + GetSeparator(number) +
                           ConvertToString(number - GetTens(number))
                               .ToLower();
            }
        }

        private static int GetTens(int number)
            => number / 10 * 10 == 70 
                ? number / 10 * 10 - 10 
                : number / 10 * 10;

        private static string GetSeparator(int number)  
            => number % 10 == 1 ? "-et-" : "-";
    }
}
