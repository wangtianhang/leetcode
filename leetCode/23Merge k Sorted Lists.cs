using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetCode
{
    class _23Merge_k_Sorted_Lists
    {
        /*static void Main(string[] args)
        {
            _23Merge_k_Sorted_Lists test = new _23Merge_k_Sorted_Lists();
            ListNode node1 = new ListNode(1);
            ListNode node2 = new ListNode(2);
            ListNode node3 = new ListNode(3);
            List<ListNode> nodeList = new List<ListNode>();
            //nodeList.Add(node1);
            //nodeList.Add(node2);
            //nodeList.Add(node3);
            ListNode ret = test.MergeKLists(nodeList.ToArray());

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

        public ListNode MergeKLists(ListNode[] lists)
        {
            if(lists.Length == 0)
            {
                return null;
            }

            List<ListNode> nodeLists = new List<ListNode>(lists);
            for (; ; )
            {
                nodeLists = MergeKListsToHalfKLists(nodeLists);
                if(nodeLists.Count == 1)
                {
                    break;
                }
            }
            return nodeLists[0];
        }

        public List<ListNode> MergeKListsToHalfKLists(List<ListNode> nodeLists)
        {
            List<ListNode> retList = new List<ListNode>();
            for (int i = 0; i < nodeLists.Count; )
            {
                ListNode node1 = null;
                ListNode node2 = null;
                if(i < nodeLists.Count)
                {
                    node1 = nodeLists[i];
                }
                if(i + 1 < nodeLists.Count)
                {
                    node2 = nodeLists[i + 1];
                }

                ListNode ret = MergeTwoLists(node1, node2);
                retList.Add(ret);

                ++i;
                ++i;
            }
            return retList;
        }

        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            if (l1 == null && l2 == null)
            {
                return null;
            }
            if (l1 == null)
            {
                return l2;
            }
            if (l2 == null)
            {
                return l1;
            }

            //bool isAscedingOrder = true;

            ListNode head = null;
            ListNode curItem = null;

            ListNode iter1 = l1;
            ListNode iter2 = l2;
            for (; iter1 != null || iter2 != null; )
            {
                ListNode elem = null;
                if (iter1 == null)
                {
                    elem = iter2;
                    iter2 = iter2.next;
                }
                else if (iter2 == null)
                {
                    elem = iter1;
                    iter1 = iter1.next;
                }

                if (elem == null)
                {
                    //if (isAscedingOrder)
                    //{
                        if (iter1.val < iter2.val)
                        {
                            elem = iter1;
                            iter1 = iter1.next;
                        }
                        else
                        {
                            elem = iter2;
                            iter2 = iter2.next;
                        }
                    //}
                    /*else
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
                    }*/
                }

                if (head != null)
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
