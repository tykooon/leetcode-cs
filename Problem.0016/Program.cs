//      https://leetcode.com/problems/3sum-closest/
//      Medium


var res = ThreeSumClosest(new int[] { -4, -2, -2, -2, 0, 1, 2, 2, 2, 3, 3, 4, 4, 6, 6 }, 100);
Console.WriteLine($"{res}");


int ThreeSumClosest(int[] nums, int target)
{
    var ordered = nums.Order().ToArray();
    var len = ordered.Count();
    var pFirst = 0;
    var pSecond = 1;
    var pThird = len - 1;
    var res = ordered[pFirst] + ordered[pSecond] + ordered[pThird];

    while (pSecond < pThird)
    {
        var sum = ordered[pFirst] + ordered[pSecond] + ordered[pThird];
        if (sum == target)
        {
            return sum;
        }

        if (Math.Abs(sum - target) < Math.Abs(res - target))
        {
            res = sum;
        }

        (pSecond, pThird) = sum < target ? (pSecond + 1, pThird) : (pSecond, pThird - 1);
        if (pSecond < pThird)
        {
            continue;
        }

        if (pSecond >= pThird)
        {
            pFirst++;
            pSecond = pFirst + 1;
            pThird = len - 1;
        }
    }

    return res;
}
