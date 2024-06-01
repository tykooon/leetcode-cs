//      https://leetcode.com/problems/two-sum/


var res = TwoSum([2, 4, 5, 7, 8, 11, 23, 43, 56], 31);
Console.WriteLine(res == null ? "Not found" : $"Indices: {res[0]} and {res[1]}");

int[] TwoSum(int[] nums, int target)
{
    var Pairs = new HashSet<int>();
    for (var i = 0; i < nums.Length; i++)
    {
        if (Pairs.Contains(target - nums[i]))
        {
            var j = Array.IndexOf(nums, target - nums[i]);
            return new int[] { i, j };
        }
        else
        {
            Pairs.Add(nums[i]);
        }

    }

    return null;
}