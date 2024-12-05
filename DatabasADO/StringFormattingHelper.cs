using System.Globalization;

namespace DatabasADO
{
    public class StringFormattingHelper
    {
        private static readonly CultureInfo _currentCulture = CultureInfo.CurrentCulture;
        private static readonly TextInfo _textInfo = _currentCulture.TextInfo;
        public static string ConvertToTitleCase(string text)
        {
            var textWords = text.Split(" ");

            for (int i = 0; i < textWords.Length; i++)
            {
                textWords[i] = _textInfo.ToTitleCase(textWords[i].ToLower());
            }

            return string.Join(" ", textWords);
        }

        public static void PrintTitlesWithIndex(List<Film> films)
        {
            int index = 1;

            foreach (Film film in films)
            {
                Console.WriteLine($"{index.ToString().PadLeft(2)}. {ConvertToTitleCase(film.Title)}");
                index++;
            }
        }
    }
}
