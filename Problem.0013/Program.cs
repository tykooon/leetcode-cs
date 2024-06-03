//      https://leetcode.com/problems/roman-to-integer/

Console.WriteLine(RomanToInt("MMCMXCIX"));

int RomanToInt(string s)
{
    string[] digits = { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };
    int[] values = { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
    int sPointer = 0;
    int result = 0;

    for (var i = 0; i < values.Length; i++)
    {
        while (s[sPointer..].StartsWith(digits[i]))
        {
            sPointer += (i % 2) + 1;
            result += values[i];
        }
    }

    return result;
}