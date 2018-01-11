using System;
using System.Collections.Generic;

using System.Text;


namespace leetCode
{

    class _21Merge_Two_Sorted_Lists
    {
        /*static void Main(string[] args)
        {
            _21Merge_Two_Sorted_Lists test = new _21Merge_Two_Sorted_Lists();
            ListNode node1 = new ListNode(2);
            //ListNode node2 = new ListNode(1);
            //node1.next = node2;

            ListNode node3 = new ListNode(1);

            ListNode ret = test.MergeTwoLists(node1, node3);

            Console.WriteLine("end");

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

        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            if(l1 == null && l2 == null)
            {
                return null;
            }
            if(l1 == null)
            {
                return l2;
            }
            if(l2 == null)
            {
                return l1;
            }
            /*if(l1.next == null && l2.next == null)
            {
                l1.next = l2;
                return l1;
            }*/

            bool isAscedingOrder = true;
            /*if(l1.next != null)
            {
                if(l1.val > l1.next.val)
                {
                    isAscedingOrder = false;
                }
            }
            if(l2.next != null)
            {
                if(l2.val > l2.next.val)
                {
                    isAscedingOrder = false;
                }
            }*/

            ListNode head = null;
            ListNode curItem = null;

            ListNode iter1 = l1;
            ListNode iter2 = l2;
            for (; iter1 != null || iter2 != null;)
            {
                ListNode elem = null;
                if(iter1 == null)
                {
                    elem = iter2;
                    iter2 = iter2.next;
                }
                else if(iter2 == null)
                {
                    elem = iter1;
                    iter1 = iter1.next;
                }

                if(elem == null)
                {
                    if (isAscedingOrder)
                    {
                        if(iter1.val < iter2.val)
                        {
                            elem = iter1;
                            iter1 = iter1.next;
                        }
                        else
                        {
                            elem = iter2;
                            iter2 = iter2.next;
                        }
                    }
                    else
                    {
                        if (iter1.val > iter2.val)
                        {
                            elem = iter1;
                            iter1 = iter1.next;
                        }
                        else
                        {
                            elem = iter2;
                            iter2 = iter2.next;
                        }
                    }
                }

                if(head != null)
                {
                    curItem.next = elem;
                    curItem = curItem.next;
                }
                else
                {
                    head = elem;
                    curItem = head;
                }
            }

            return head;
        }
    }
}
