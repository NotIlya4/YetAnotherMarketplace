using System.Text;

namespace Infrastructure.Extensions;

public static class StringExtensions
{
    public static bool EqualsIgnoreCase(this string? s1, string? s2)
    {
        return s1 is not null && s1.Equals(s2, StringComparison.OrdinalIgnoreCase);
    }

    public static string ToReadableString(this IEnumerable<string> separatedStrings, string separator = ", ")
    {
        separatedStrings = separatedStrings.ToList();
        if (!separatedStrings.Any())
        {
            return "";
        }
            
        StringBuilder stringBuilder = new StringBuilder();
        foreach (var separatedString in separatedStrings)
        {
            stringBuilder.Append($"{separatedString}{separator}");
        }

        stringBuilder.Remove(stringBuilder.Length - separator.Length, separator.Length);

        return stringBuilder.ToString();
    }
}