//      https://leetcode.com/problems/reverse-integer/
Console.WriteLine(Reverse(19872081));


int Reverse(int x)
{
    var s = x.ToString();
    var isNegative = s[0] == '-';
    if (isNegative) s = s[1..];
    var result = 0;
    var sum = 0;

    for (var i = s.Length - 1; i >= 0; i--)
    {
        var digit = s[i] - '0';
        if (i > 8 && digit > 2)
        {
            return 0;
        }
        sum = digit * PowerOfTen(i) + result;
        if (sum < result)
        {
            return 0;
        }
        result = sum;
    }

    if (isNegative)
    {
        result *= -1;
    }

    return result;
}

int PowerOfTen(int p) => p <= 0 ? 1 : 10 * PowerOfTen(p - 1);
