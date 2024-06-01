//      https://leetcode.com/problems/unique-paths/

Console.WriteLine(UniquePaths(8, 8));

int UniquePaths(int m, int n)
{
    long res = 1;
    for (var i = 0; i < n - 1; i++)
    {
        res *= m + i;
        res /= (i + 1);
    }
    return (int)res;
}