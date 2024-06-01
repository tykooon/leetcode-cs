//      https://leetcode.com/problems/longest-palindromic-substring/


Console.WriteLine(LongestPalindrome("sfdgjskdlfokolomisimolokoijkldj;lka"));

string LongestPalindrome(string s)
{
    var sLen = s.Length;
    var maxLen = 1;
    var center = 0;
    var limit = (sLen - 1) * 2;
    int jLeft;
    int jRight;
    int len;
    for (var i = 0; i < limit; i++)
    {
        jLeft = i / 2 + i % 2 - 1;
        jRight = i / 2 + 1;
        while (jLeft >= 0 && jRight < sLen && s[jLeft] == s[jRight])
        {
            jRight++;
            jLeft--;
        }
        len = (--jRight) - (++jLeft) + 1;
        if (len > maxLen)
        {
            center = i;
            maxLen = len;
        }
    }
    jLeft = center / 2 + center % 2 - maxLen / 2;
    jRight = jLeft + maxLen;
    return s[jLeft..jRight];
}