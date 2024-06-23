//      https://leetcode.com/problems/letter-combinations-of-a-phone-number/

foreach (var str in LetterCombinations("247"))
{
    Console.Write($"{str}, ");
}


IList<string> LetterCombinations(string digits)
{
    var dict = new Dictionary<char, char[]>()
    {
        ['2'] = ['a', 'b', 'c'],
        ['3'] = ['d', 'e', 'f'],
        ['4'] = ['g', 'h', 'i'],
        ['5'] = ['j', 'k', 'l'],
        ['6'] = ['m', 'n', 'o'],
        ['7'] = ['p', 'q', 'r', 's'],
        ['8'] = ['t', 'u', 'v'],
        ['9'] = ['w', 'x', 'y', 'z'],
    };

    var res = new List<string>();
    if (digits.Length < 1)
    {
        return res;
    }

    var total = 0;
    foreach (char s in dict[digits[0]])
    {
        res.Add(s.ToString());
        total++;
    }

    foreach (char s in digits[1..])
    {
        total *= dict[s].Length;
        var limit = res.Count();
        for (var i = 0; i < limit; i++)
        {
            foreach (char t in dict[s])
            {
                res.Add(res[i] + t);
            }
        }
    }

    return res[^total..];
}
