using System.Globalization;

namespace KJ.Tourify.WebUI.Utils
{
    public static class TourFormat
    {
        private static readonly CultureInfo PriceCulture = CultureInfo.GetCultureInfo("en-US");

        public static string Price(string? value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return string.Empty;

            var digits = new string(value.Where(char.IsDigit).ToArray());

            return decimal.TryParse(digits, NumberStyles.None, PriceCulture, out var amount)
                ? amount.ToString("C0", PriceCulture)
                : value.Trim();
        }

        public static string Days(string? value) => WithUnit(value, "Day", "Days");

        public static string Persons(string? value) => WithUnit(value, "Person", "Persons");

        public static int? Capacity(string? value)
        {
            var digits = new string((value ?? string.Empty).Where(char.IsDigit).ToArray());
            return int.TryParse(digits, out var count) ? count : null;
        }

        private static string WithUnit(string? value, string singular, string plural)
        {
            if (string.IsNullOrWhiteSpace(value))
                return string.Empty;

            var trimmed = value.Trim();
            if (!int.TryParse(trimmed, out var count))
                return trimmed;

            return $"{count} {(count == 1 ? singular : plural)}";
        }
    }
}
