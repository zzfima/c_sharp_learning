namespace StaticClass
{
    public static class Utils
    {
        public static string FormatStars(string messageToFormat)
        {
            CustomFormatter customFormatter = new CustomFormatter(messageToFormat);
            return customFormatter.FormatStars();
        }

        public static string FormatSpaces(string messageToFormat)
        {
            CustomFormatter customFormatter = new CustomFormatter(messageToFormat);
            return customFormatter.FormatSpaces();
        }

        public static string FormatDollars(string messageToFormat)
        {
            CustomFormatter customFormatter = new CustomFormatter(messageToFormat);
            return customFormatter.FormatDollars();
        }
    }

    public class CustomFormatter
    {
        private readonly string _stringToFormat;

        public CustomFormatter(string stringToFormat)
        {
            _stringToFormat = stringToFormat;
        }

        public string FormatStars()
        {
            return ($"*** {_stringToFormat} ***");
        }

        public string FormatSpaces()
        {
            return ($"    {_stringToFormat}    ");
        }

        public string FormatDollars()
        {
            return ($"$$$ {_stringToFormat} $$$");
        }
    }
}