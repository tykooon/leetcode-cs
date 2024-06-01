//  https://leetcode.com/problems/longest-substring-without-repeating-characters/

Console.WriteLine(LengthOfLongestSubstring("fgkslkg jsdfklidius idhiajpo fjnndmaf"));

int LengthOfLongestSubstring(string s)
{
    int result = 0;
    var set = new HashSet<char>();
    var hp = 0;
    for (var lp = 0; lp < s.Length; lp++)
    {
        if (set.Contains(s[lp]))
        {
            if (set.Count > result)
            {
                result = set.Count;
            }
            do
            {
                set.Remove(s[hp]);
                hp++;
            } while (s[hp - 1] != s[lp]);
        }
        set.Add(s[lp]);
    }
    if (set.Count > result)
    {
        result = set.Count;
    }
    return result;
}