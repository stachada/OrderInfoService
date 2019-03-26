using System.Globalization;

namespace OrderInfoService.WinFormsApp.Infrastructure
{
    public static class ParsingHelpers
    {
        public static double? ParseDouble(string s)
        {
            double result;
            double? nullableResult;
            if (double.TryParse(s, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out result))
                nullableResult = result;
            else
                nullableResult = null;

            return nullableResult;
        }

        public static long? ParseLong(string s)
        {
            long result;
            long? nullableResult;
            if (long.TryParse(s, out result))
                nullableResult = result;
            else
                nullableResult = null;

            return nullableResult;
        }

        public static int? ParseInt(string s)
        {
            int result;
            int? nullableResult;
            if (int.TryParse(s, out result))
                nullableResult = result;
            else
                nullableResult = null;

            return nullableResult;
        }
    }
}
