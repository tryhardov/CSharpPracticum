namespace CSharpPracticum.Tasks.Level2;

public static class StringExtensions
{
    public static bool IsPalindrome(this string text)
    {
        ArgumentNullException.ThrowIfNull(text);

        int left = 0;
        int right = text.Length - 1;
        while (left < right)
        {
            if (!char.IsLetterOrDigit(text[left]))
            {
                left++;
            }
            else if (!char.IsLetterOrDigit(text[right]))
            {
                right--;
            }
            else if (char.ToLowerInvariant(text[left++]) != char.ToLowerInvariant(text[right--]))
            {
                return false;
            }
        }

        return true;
    }

    public static int WordCount(this string text)
    {
        ArgumentNullException.ThrowIfNull(text);

        int count = 0;
        bool inWord = false;
        foreach (char c in text)
        {
            bool isWordChar = char.IsLetterOrDigit(c) || c == '\'';
            if (isWordChar && !inWord)
            {
                count++;
            }

            inWord = isWordChar;
        }

        return count;
    }

    public static string ReverseString(this string text)
    {
        ArgumentNullException.ThrowIfNull(text);

        char[] chars = text.ToCharArray();
        for (int i = 0, j = chars.Length - 1; i < j; i++, j--)
        {
            (chars[i], chars[j]) = (chars[j], chars[i]);
        }

        return new string(chars);
    }
}
