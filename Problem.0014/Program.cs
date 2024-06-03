//      https://leetcode.com/problems/longest-common-prefix/

Console.WriteLine(LongestCommonPrefix(new string[] { "flower", "flow", "flight" }));

string LongestCommonPrefix(string[] strs)
{

    var prefix = strs[0];

    for (var i = 1; i < strs.Length; i++)
    {
        var pointer = prefix.Length < strs[i].Length ? prefix.Length : strs[i].Length;
        while (!strs[i].StartsWith(prefix[..pointer]) && pointer > -1)
        {
            pointer--;
        }

        if (pointer == 0)
            return "";

        prefix = prefix[..pointer];
    }

    return prefix;
}