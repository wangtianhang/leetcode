using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Node
{
    public System.Object m_data = null;
    public Node m_prev = null;
    public Node m_next = null;

    public override string ToString()
    {
        return m_data.ToString(); 
    }
}

public class DoubleLinkedList
{
    public Node m_first = null;
    public int Count = 0;

//     public int Count()
//     {
//         return m_count;
//     }

//     public void AddNodeAtFirst(System.Object data)
//     {
//         Node newNode = new Node();
//         newNode.m_data = data;
//         newNode.m_next = m_first;
//         if(m_first != null)
//         {
//             newNode.m_prev = newNode;
//         }
//         m_first = newNode;
// 
//         Count++;
//     }

    public void RemoveNode(Node node)
    {
        if(node == null)
        {
            return;
        }
        //独立节点
        if(node.m_next == null
            && node.m_prev == null)
        {
            if(node == m_first)
            {
                m_first = null;
                Count--;
            }
            else
            {
                throw new Exception("RemoveNode exception");
            }
            return;
        }
        //队尾
        if(node.m_next == null
            && node.m_prev != null)
        {
            node.m_prev.m_next = null;
            Count--;
            return;
        }
        // 队首
        if(node.m_prev == null
            && node.m_next != null)
        {
            node.m_next.m_prev = null;
            m_first = node.m_next;
            Count--;
            return;
        }
        // 队中间
        if (node.m_prev != null
            && node.m_next != null)
        {
            node.m_next.m_prev = node.m_prev;
            node.m_prev.m_next = node.m_next;
            Count--;
            return;
        }

        
    }

    public Node InsertNode(Node prev, System.Object data)
    {
        // 无节点
        if(m_first == null)
        {
            Node newNode = new Node();
            newNode.m_data = data;
            m_first = newNode;
            Count++;
            return newNode;
        }
        // 独立节点
//         else if(prev.m_prev == null
//             && prev.m_next == null)
//         {
//             if(m_first == prev)
//             {
//                 Node newNode = new Node();
//                 newNode.m_data = data;
//                 m_first.m_next = newNode;
//                 newNode.m_prev = m_first;
//                 Count++;
//                 return newNode;
//             }
//             else
//             {
//                 throw new Exception("InsertNode exception");
//             }
//         }
        // 队首
        else if (prev == null)
        {
            Node newNode = new Node();
            newNode.m_data = data;
            newNode.m_next = m_first;
            m_first.m_prev = newNode;
            m_first = newNode;
            Count++;
            return newNode;
        }
        // 队尾
        else if(prev.m_next == null)
        {
            Node newNode = new Node();
            newNode.m_data = data;
            newNode.m_prev = prev;
            prev.m_next = newNode;
            Count++;
            return newNode;
        }
        // 队中间
        else
        {
            Node newNode = new Node();
            newNode.m_data = data;
            newNode.m_prev = prev;
            newNode.m_next = prev.m_next;
            prev.m_next = newNode;
            newNode.m_next.m_prev = newNode;
            Count++;
            return newNode;
        }
        
    }
}

public class LFUCache
{
    public static void Test()
    {
        LFUCache cache = new LFUCache(2 /* capacity */ );

        cache.Put(1, 1);
        Console.WriteLine("cache.Put(1, 1);");
        DebugState(cache);
        cache.Put(2, 2);
        Console.WriteLine("cache.Put(2, 2);");
        DebugState(cache);
        int ret = cache.Get(1);
        Console.WriteLine("cache.Get(1);");
        DebugState(cache);
        Console.WriteLine(ret);       // returns 1
        cache.Put(3, 3);    // evicts key 2
        Console.WriteLine("cache.Put(3, 3);");
        DebugState(cache);
        ret = cache.Get(2);
        Console.WriteLine("cache.Get(2);");
        DebugState(cache);
        Console.WriteLine(ret);       // returns -1 (not found)
        ret = cache.Get(3);
        Console.WriteLine("cache.Get(3);");
        DebugState(cache);
        Console.WriteLine(ret);       // returns 3.
        cache.Put(4, 4);    // evicts key 1.
        Console.WriteLine("cache.Put(4, 4);");
        DebugState(cache);
        ret = cache.Get(1);
        Console.WriteLine("cache.Get(1)");
        DebugState(cache);
        Console.WriteLine(ret);       // returns -1 (not found)
        ret = cache.Get(3);
        Console.WriteLine("cache.Get(3)");
        DebugState(cache);
        Console.WriteLine(ret);       // returns 3
        ret = cache.Get(4);
        Console.WriteLine("cache.Get(4)");
        DebugState(cache);
        Console.WriteLine(ret);       // returns 4
    }

    public static void DebugState(LFUCache cache)
    {
//         foreach (var iter in cache.m_valueDic)
//         {
//             Console.WriteLine("dic " + iter.Key + " " + iter.Value);
//         }
//         FrequencyNode node = cache.m_first;
//         while(node != null)
//         {
//             Console.WriteLine("linkedlist " + node);
//             node = node.m_next;
//         }
        foreach(var iter in cache.m_valueDic)
        {
            Console.WriteLine("dic " + iter.Key + " " + iter.Value);
        }
        Node node = cache.m_doubleLinkedList.m_first;
        while(node != null)
        {
            
            Console.WriteLine("linkedlist " + node);
            node = node.m_next;
        }
    }

//     public class FrequencyNode
//     {
//         public int m_frequency = 0;
//         public Dictionary<int, int> m_dic = new Dictionary<int, int>();
//         public FrequencyNode m_prev = null;
//         public FrequencyNode m_next = null;
// 
//         public override string ToString()
//         {
//             string keys = "";
//             foreach(var iter in m_dic)
//             {
//                 keys += iter.Key + ",";
//             }
//             string ret = "frequency:" + m_frequency.ToString() + ",keys:" + keys;
//             if(m_prev != null)
//             {
//                 ret += "prev:" + m_prev.m_frequency + ",";
//             }
//             else
//             {
//                 ret += "prev:null,";
//             }
//             if (m_next != null)
//             {
//                 ret += "next:" + m_next.m_frequency + ",";
//             }
//             else
//             {
//                 ret += "next:null,";
//             }
//             return ret;
//         }
//     }

    public class ValueData
    {
        public ValueData(int val, Node node)
        {
            m_val = val;
            m_node = node;
        }
        public int m_val = 0;
        public Node m_node = null;

        public override string ToString()
        {
            return "value:" + m_val.ToString() + ", " + m_node.ToString();
        }
    }

    public class FrequencyData
    {
        public FrequencyData(int frequency, int key)
        {
            m_frequency = frequency;
            m_dic.Add(key, 0);
        }
        public int m_frequency = 0;
        public Dictionary<int, int> m_dic = new Dictionary<int, int>();

        public override string ToString()
        {
            string ret = "";
            foreach(var iter in m_dic)
            {
                ret += iter.Key.ToString() + ",";
            }
            return "frequency:" + m_frequency.ToString() + " keys:" + ret;
        }
    }

    //public FrequencyNode m_first = null; // frequency从小到大 fist为小
    //FrequencyNode m_last = null;
    public DoubleLinkedList m_doubleLinkedList = new DoubleLinkedList();
    public Dictionary<int, ValueData> m_valueDic = new Dictionary<int, ValueData>();
    public int m_capacity = 0;
    public int m_n = 0;


    public LFUCache(int capacity)
    {
        m_capacity = capacity;
    }

    public int Get(int key)
    {
        if(m_valueDic.ContainsKey(key))
        {
            int val = m_valueDic[key].m_val;

            FrequencyData frequencyData = m_valueDic[key].m_node.m_data as FrequencyData;
            int newFrequency = frequencyData.m_frequency + 1;
            frequencyData.m_dic.Remove(key);
            Node oldNode = m_valueDic[key].m_node;

            Node nextNode = m_valueDic[key].m_node.m_next;
            // 队尾巴
            if (nextNode == null)
            {
                Node node = m_doubleLinkedList.InsertNode(m_valueDic[key].m_node, new FrequencyData(newFrequency, key));
                m_valueDic[key].m_node = node;
            }
            else
            {
                FrequencyData nextFrequencyData = nextNode.m_data as FrequencyData;
                if(newFrequency == nextFrequencyData.m_frequency)
                {
                    nextFrequencyData.m_dic.Add(key, 0);
                    m_valueDic[key].m_node = nextNode;
                }
                else if (newFrequency < nextFrequencyData.m_frequency)
                {
                    Node node = m_doubleLinkedList.InsertNode(m_valueDic[key].m_node, new FrequencyData(newFrequency, key));
                    m_valueDic[key].m_node = node;
                }
            }

            if (frequencyData.m_dic.Count == 0)
            {
                m_doubleLinkedList.RemoveNode(oldNode);
            }
            return val;
        }
        else
        {
            return -1;
        }
    }

    public void Put(int key, int value)
    {
        if(!m_valueDic.ContainsKey(key))
        {
            if (m_n < m_capacity)
            {
                m_n += 1;
                if(m_doubleLinkedList.Count == 0)
                {
                    Node node = m_doubleLinkedList.InsertNode(null, new FrequencyData(0, key));
                    m_valueDic.Add(key, new ValueData(value, node));
                }
                else
                {
                    FrequencyData frequencyData = m_doubleLinkedList.m_first.m_data as FrequencyData;
                    if (frequencyData.m_frequency == 0)
                    {
                        frequencyData.m_dic.Add(key, 0);
                        m_valueDic.Add(key, new ValueData(value, m_doubleLinkedList.m_first));
                    }
                    else
                    {
                        Node node = m_doubleLinkedList.InsertNode(null, new FrequencyData(0, key));
                        m_valueDic.Add(key, new ValueData(value, node));
                    }
                }
            }
            else
            {
                FrequencyData frequencyData = m_doubleLinkedList.m_first.m_data as FrequencyData;
                int firstKey = -1;
                // todo 此处的时间复杂度？看c#源码应该是个array
                foreach(var iter in frequencyData.m_dic)
                {
                    firstKey = iter.Key;
                    break;
                }
                frequencyData.m_dic.Remove(firstKey);
                m_valueDic.Remove(firstKey);
                if(frequencyData.m_dic.Count == 0)
                {
                    m_doubleLinkedList.RemoveNode(m_doubleLinkedList.m_first);
                }

                frequencyData = m_doubleLinkedList.m_first.m_data as FrequencyData;
                if (frequencyData.m_frequency == 0)
                {
                    frequencyData.m_dic.Add(key, 0);
                    m_valueDic.Add(key, new ValueData(value, m_doubleLinkedList.m_first));
                }
                else
                {
                    Node node = m_doubleLinkedList.InsertNode(null, new FrequencyData(0, key));
                    m_valueDic.Add(key, new ValueData(value, node));
                }
            }
        }
    }
}
