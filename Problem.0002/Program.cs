//      https://leetcode.com/problems/add-two-numbers/

// Test set creation
var node11 = new ListNode(8);
var node12 = new ListNode(6, node11);
var node13 = new ListNode(9, node12);  // number 968

var node21 = new ListNode(6);
var node22 = new ListNode(7, node21);
var node23 = new ListNode(2, node22);
var node24 = new ListNode(9, node23);  // number 6729

var result = AddTwoNumbers(node13, node24);
Console.Write(result.NodeChainToString());


//  Function for task-solution
ListNode AddTwoNumbers(ListNode l1, ListNode l2)
{
    var result = new ListNode();
    var tail = result;
    var carry = 0;

    while (l1 != null || l2 != null || carry != 0)
    {
        tail.next = new();
        tail = tail.next;
        var sum = (l1?.val ?? 0) + (l2?.val ?? 0) + carry;
        tail.val = sum % 10;
        carry = sum / 10;
        l1 = l1?.next;
        l2 = l2?.next;
    }
    return result.next;
}