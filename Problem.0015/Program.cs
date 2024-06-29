//      https://leetcode.com/problems/3sum/
//      Medium

var res = ThreeSum(new int[] { -4, -2, -2, -2, 0, 1, 2, 2, 2, 3, 3, 4, 4, 6, 6 });
Console.WriteLine(res.Any());

foreach (var item in res)
{
    Console.WriteLine($"[{item[0]}, {item[1]}, {item[2]}]");
}


IList<IList<int>> ThreeSum(int[] nums)
{
    var res = new List<IList<int>>();
    if (nums.Length < 3)
    {
        return res;
    }


    var ordered = nums.Order().ToList();
    var len = ordered.Count();
    var pFirst = 0;
    var pSecond = 1;
    var pThird = len - 1;

    while (pSecond < pThird && ordered[pFirst] <= 0)
    {
        var sum = ordered[pFirst] + ordered[pSecond] + ordered[pThird];
        if (sum == 0 && (!res.Any() || res[^1][0] != ordered[pFirst] || res[^1][1] != ordered[pSecond]))
        {
            res.Add(new int[] { ordered[pFirst], ordered[pSecond], ordered[pThird] });
        }

        (pSecond, pThird) = sum < 0 ? (pSecond + 1, pThird) : (pSecond, pThird - 1);
        if (pSecond < pThird)
        {
            continue;
        }

        if (pSecond >= pThird)
        {
            do
            {
                pFirst++;
            }
            while (pFirst < len && ordered[pFirst] == ordered[pFirst - 1]);

            pSecond = pFirst + 1;
            pThird = len - 1;
        }
    }

    return res;
}