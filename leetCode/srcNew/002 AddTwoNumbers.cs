using System;

public class ListNode 
{
    public int val;
    public ListNode next;
    public ListNode(int x) { val = x; }
}

public class AddTwoNumbers02
{
    /*static void Main(string[] args)
    {
        Solution test = new Solution();
        ListNode l1 = new ListNode(5);
        ListNode l2 = new ListNode(5);
        ListNode ret = test.AddTwoNumbers(l1, l2);

        while(ret != null)
        {
            Console.WriteLine(ret.val);
            ret = ret.next;
        }

        Console.Read();
    }*/

    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        //ListNode reversel1 = ReverseList(l1);
        //ListNode reversel2 = ReverseList(l2);

        ListNode iter1 = l1;
        ListNode iter2 = l2;

        ListNode firstNode = null;
        ListNode lastNode = null;
        int lastCarry = 0;
        for (; iter1 != null || iter2 != null || lastCarry != 0; )
        {
            int val1 = 0;
            if(iter1 != null)
            {
                val1 = iter1.val;
                iter1 = iter1.next; 
            }
            int val2 = 0;
            if(iter2 != null)
            {
                val2 = iter2.val;
                iter2 = iter2.next;
            }

            int add1 = (val1 + val2 + lastCarry) % 10;
            ListNode tmp = new ListNode(add1);
            if(lastNode != null)
            {
                lastNode.next = tmp;
                lastNode = tmp;
            }
            else
            {
                lastNode = tmp;
            }
            lastCarry = (val1 + val2 + lastCarry) / 10;

            if(firstNode == null)
            {
                firstNode = lastNode;
            }
        }

        return firstNode;
    }

    /*ListNode ReverseList(ListNode l1)
    {
        ListNode ret = null;
        while(l1 != null)
        {
            ListNode tmp = new ListNode(l1.val);
            tmp.next = ret;
            ret = tmp;
            l1 = l1.next;
        }
        return ret;
    }*/
}
