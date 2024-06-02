//      https://leetcode.com/problems/regular-expression-matching/

// Test Cases
Console.WriteLine(IsMatch("abb", "b*") == false);
Console.WriteLine(IsMatch("", ".*"));
Console.WriteLine(IsMatch("", ".*a*f*"));
Console.WriteLine(IsMatch("bbab", "b*a*") == false);
Console.WriteLine(IsMatch("aaa", "a*a"));
Console.WriteLine(IsMatch("aab", "c*a*b"));
Console.WriteLine(IsMatch("aaa", "ab*a*c*a"));
Console.WriteLine(IsMatch("aa", "a*"));
Console.WriteLine(IsMatch("mississippi", "mis*is*p*.") == false);
Console.WriteLine(IsMatch("a", ".*..a*") == false);
Console.WriteLine(IsMatch("aabcbcbcaccbcaabc", ".*a*aa*.*b*.c*.*a*"));

// Solution
bool IsMatch(string s, string p)
{
    if (p.Length == 0)
    {
        return s.Length == 0;
    }

    char? nextSymbol = p.Length < 2 ? null : p[1];
    char? nextToNextSymbol = p.Length < 3 ? null : p[2];

    return (p[0], nextSymbol, nextToNextSymbol) switch
    {
        ('.', '*', null) => true,
        ('.', '*', _) => IsMatchSubstring(s, p[2..]),
        ('.', null, _) => s.Length == 1,
        ('.', _, _) => s.Length == 0 ? false : IsMatchNext(s, p),
        (_, '*', null) => IsConstString(s, p[0]),
        (_, '*', _) => IsMatchSubstringFromChar(s, p[2..], p[0]),
        (_, null, _) => s.Length == 1 && p[0] == s[0],
        (_, _, _) => s.Length == 0 || p[0] != s[0] ? false : IsMatchNext(s, p),
    };
}

bool IsMatchNext(string s, string p)
{
    var newStr = s.Length > 1 ? s[1..] : "";
    return IsMatch(newStr, p[1..]);
}

bool IsMatchSubstring(string s, string p)
{
    for (var i = 0; i < s.Length; i++)
    {
        if (IsMatch(s[i..], p))
        {
            return true;
        }
    }
    return IsMatch("", p);
}

bool IsMatchSubstringFromChar(string s, string p, char p0)
{
    for (var i = 0; i < s.Length; i++)
    {
        if (IsMatch(s[i..], p))
        {
            return true;
        }
        if (s[i] != p0)
        {
            return false;
        }
    }
    return IsMatch("", p);
}

bool IsConstString(string s, char p0)
{
    for (var i = 0; i < s.Length; i++)
    {
        if (s[i] != p0)
        {
            return false;
        }
    }
    return true;
}