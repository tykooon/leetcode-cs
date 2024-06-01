using System.Text;

// Definition for singly-linked list.
public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}

public static class ListNodeExtension
{
    public static string NodeChainToString(this ListNode node)
    {
        var res = new StringBuilder();
        while (node.next != null)
        {
            res.Append(node.val);
            node = node.next;
        }
        res.Append(node?.val);

        return res.ToString();
    }
}

