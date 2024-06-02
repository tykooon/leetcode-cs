//      https://leetcode.com/problems/container-with-most-water/

Console.WriteLine(MaxArea([1, 8, 6, 2, 5, 4, 8, 3, 7]));

int MaxArea(int[] height)
{
    var start = 0;
    var end = height.Length - 1;

    var volume = height[start] > height[end]
        ? height[end] * end
        : height[start] * end;

    int subVolume;
    while (end - start > 1)
    {
        if ((height[start] < height[end])
            || (height[start] == height[end] && height[start + 1] < height[end - 1]))
        {
            start++;
        }
        else
        {
            end--;
        }
        subVolume = height[start] > height[end]
        ? height[end] * (end - start)
        : height[start] * (end - start);

        if (subVolume > volume)
        {
            volume = subVolume;
        }
    }

    return volume;
}