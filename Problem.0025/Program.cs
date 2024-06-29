//      https://leetcode.com/problems/reverse-nodes-in-k-group/submissions/
//      Hard

Console.WriteLine("Without Test Set");

ListNode ReverseKGroup(ListNode head, int k)
{
    if (head == null)
    {
        return null;
    }

    var currFirst = head;
    int i = 1;
    var currNode = head;
    var currNext = head.next;

    while (i < k && currNext != null)
    {
        var tmp = currNext.next;
        currNext.next = currNode;
        currNode = currNext;
        currNext = tmp;
        i++;
    }

    if (i < k)
    {
        head.next = null;
        return ReverseKGroup(currNode, i);
    }
    else
    {
        head.next = ReverseKGroup(currNext, k);
        return currNode;
    }

}