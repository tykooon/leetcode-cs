//      https://leetcode.com/problems/zigzag-conversion
using System.Text;

Console.WriteLine(Convert("Hello, New Anb Wonderful World!", 3));

string Convert(string s, int numRows)
{
    var builder = new StringBuilder();
    var delta = numRows - 1;
    if (delta == 0)
    {
        return s;
    }
    for (var i = 0; i < numRows; i++)
    {
        var pos = i;
        while (pos < s.Length)
        {
            builder.Append(TakeChar(s, pos));

            if (i != 0 && i != delta)
            {
                builder.Append(TakeChar(s, pos + 2 * (delta - i)));
            }

            pos += delta * 2;
        }
    }
    return builder.ToString();

}

string TakeChar(string s, int position)
{
    return (uint)position < s.Length ? s[position].ToString() : "";
}