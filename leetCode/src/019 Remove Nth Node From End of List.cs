using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetCode
{
    class _19Remove_Nth_Node_From_End_of_List
    {
        /*static void Main(string[] args)
        {
            _19Remove_Nth_Node_From_End_of_List test = new _19Remove_Nth_Node_From_End_of_List();
            ListNode node1 = new ListNode(1);
            ListNode node2 = new ListNode(2);
            //ListNode node3 = new ListNode(3);
            //ListNode node4 = new ListNode(4);
            //ListNode node5 = new ListNode(5);
            node1.next = node2;
            //node2.next = node3;
            //node3.next = node4;
            //node4.next = node5;

            ListNode ret = test.RemoveNthFromEnd(node1, 1);
            while(ret != null)
            {
                Console.WriteLine(ret.val);
                ret = ret.next;
            }

            Console.Read();
        }*/

        public class ListNode 
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }
 

        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
///            if(n == 1)
//            {
//                return null;
//            }

            int i = 0;
            ListNode iter = head;
            ListNode lastNnode = null;
            while(iter.next != null)
            {
                iter = iter.next;

                if (lastNnode != null)
                {
                    lastNnode = lastNnode.next;
                }

                i++;
                if(i == n)
                {
                    lastNnode = head;
                }
            }

            // 队首
            if(lastNnode == null)
            {
                head = head.next;
            }
            else
            {
                lastNnode.next = lastNnode.next.next;
            }

            return head;
        }
    }
}
