//  https://leetcode.com/problems/palindrome-number/

Console.WriteLine(IsPalindrome(1523251));

bool IsPalindrome(int x)
{
    if (x < 0)
    {
        return false;
    }

    var digits = NumberOfDigits(x) - 1;
    if (digits < 1)
    {
        return true;
    }

    for (var i = 0; i < (digits + 1) / 2; i++)
    {
        if (GetDigit(x, i) != GetDigit(x, digits - i))
        {
            return false;
        }
    }

    return true;
}

int GetDigit(int number, int index)
{
    for (var i = 0; i < index; i++)
    {
        number /= 10;
    }
    return number % 10;
}

int NumberOfDigits(int number)
{
    return number == 0 ? 0 : NumberOfDigits(number / 10) + 1;
}