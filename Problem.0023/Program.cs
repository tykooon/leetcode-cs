//      https://leetcode.com/problems/merge-k-sorted-lists/

System.Console.WriteLine("Without Test Set");

ListNode MergeKLists(ListNode[] lists)
{
    if (lists.Length == 0)
    {
        return null;
    }

    for (var i = 1; i < lists.Length; i++)
    {
        lists[0] = MergeTwoOrderedLists(lists[0], lists[i]);
    }

    return lists[0];
}

ListNode MergeTwoOrderedLists(ListNode first, ListNode second)
{
    if (first == null && second == null)
    {
        return null;
    }

    ListNode result = new(),
        current = result;

    while (first != null && second != null)
    {
        if (first.val < second.val)
        {
            current.next = first;
            first = first.next;
        }
        else
        {
            current.next = second;
            second = second.next;
        }

        current = current.next;
    }

    if (first != null)
    {
        current.next = first;
    }

    if (second != null)
    {
        current.next = second;
    }

    return result.next;
}

//Definition for singly-linked list.
class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next = null)
    {
        val = val;
        next = next;
    }
}