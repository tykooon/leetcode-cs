//  https://leetcode.com/problems/string-to-integer-atoi/

Console.WriteLine(MyAtoi("-21474836482"));

int MyAtoi(string s)
{
    if (string.IsNullOrWhiteSpace(s))
    {
        return 0;
    }
    var chars = s.ToCharArray();
    var currPos = 0;

    while (chars[currPos] == ' ')
    {
        currPos++;
    }

    var sign = 1;
    switch (chars[currPos])
    {
        case '-':
            sign = -1;
            currPos++;
            break;
        case '+':
            currPos++;
            break;
    }

    var sum = 0;
    var limit = int.MaxValue / 10;
    while (currPos < chars.Length && chars[currPos] >= '0' && chars[currPos] <= '9')
    {
        if (sum > limit || sum < -limit)
        {
            sum = sign > 0 ? int.MaxValue : int.MinValue;
            break;
        }
        if (sum == -limit && chars[currPos] == '9')
        {
            sum = int.MinValue;
            break;
        }
        if (sum == limit && chars[currPos] > '7')
        {
            sum = int.MaxValue;
            break;
        }

        sum = sum * 10 + sign * (chars[currPos] - '0');
        currPos++;
    }

    return sum;
}