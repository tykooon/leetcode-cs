//    https://leetcode.com/problems/integer-to-roman/

Console.WriteLine(IntToRoman(3749));

string IntToRoman(int num)
{
    var thousands = num / 1000;
    var hundreds = (num - thousands * 1000) / 100;
    var tens = (num - thousands * 1000 - hundreds * 100) / 10;
    var units = num % 10;

    var result = new StringBuilder();
    AddSomeDigits(result, "M", thousands);

    AddOrder(result, hundreds, "C", "D", "M");
    AddOrder(result, tens, "X", "L", "C");
    AddOrder(result, units, "I", "V", "X");

    return result.ToString();
}

void AddOrder(StringBuilder result, int nominal, string one, string five, string ten)
{
    switch (nominal)
    {
        case < 4:
            AddSomeDigits(result, one, nominal);
            break;
        case 4:
            AddSomeDigits(result, one + five, 1);
            break;
        case > 4 and < 9:
            AddSomeDigits(result, five, 1);
            AddSomeDigits(result, one, nominal - 5);
            break;
        case 9:
            AddSomeDigits(result, one + ten, 1);
            break;
    }
}

void AddSomeDigits(StringBuilder result, string digit, int times)
{
    for (var i = 0; i < times; i++)
    {
        result.Append(digit);
    }
}