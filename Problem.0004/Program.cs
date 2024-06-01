//      https://leetcode.com/problems/median-of-two-sorted-arrays/

Console.WriteLine(FindMedianSortedArrays([1, 4, 7, 11, 15, 17, 23, 28], [4, 5, 8, 12, 15, 17, 24, 26, 78]));

double FindMedianSortedArrays(int[] firstArray, int[] secondArray)
{
    int i = 0;      // pointer of first Array
    int j = 0;      // pointer of second Array
    int k = 0;      // pointer of result Array

    int len1 = firstArray.Length;
    int len2 = secondArray.Length;
    int lenTotal = len1 + len2;

    int[] result = new int[lenTotal--];

    while (i < len1 && j < len2)
    {
        result[k++] = (firstArray[i] <= secondArray[j]) ? firstArray[i++] : secondArray[j++];
    }

    while (i < len1)
    {
        result[k++] = firstArray[i++];
    }

    while (j < len2)
    {
        result[k++] = secondArray[j++];
    }

    return (double)(result[lenTotal / 2] + result[lenTotal / 2 + lenTotal % 2]) / 2;
}