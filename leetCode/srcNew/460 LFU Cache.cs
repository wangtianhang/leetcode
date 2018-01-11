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
        /*LFUCache cache = new LFUCache(2);
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
        */

        /*LFUCache cache = new LFUCache(1);
        cache.Put(2, 1);
        cache.Get(2);
        cache.Put(3, 2);
        cache.Get(2);
        cache.Get(3);*/
        /*LFUCache cache = new LFUCache(2);
        cache.Put(3, 1);
        cache.Put(2, 1);
        cache.Put(2, 2);
        cache.Put(4, 4);
        cache.Get(2);*/
        /*LFUCache cache = new LFUCache(2);
        cache.Put(2, 1);
        cache.Put(1, 1);
        cache.Put(2, 3);
        cache.Put(4, 1);
        Console.WriteLine(cache.Get(1));
        Console.WriteLine(cache.Get(2));*/

        LFUCache cache = new LFUCache(10);
        string[] op = new string[] { "put", "put", "put", "put", "put", "get", "put", "get", "get", "put", "get", "put", "put", "put", "get", "put", "get", "get", "get", "get", "put", "put", "get", "get", "get", "put", "put", "get", "put", "get", "put", "get", "get", "get", "put", "put", "put", "get", "put", "get", "get", "put", "put", "get", "put", "put", "put", "put", "get", "put", "put", "get", "put", "put", "get", "put", "put", "put", "put", "put", "get", "put", "put", "get", "put", "get", "get", "get", "put", "get", "get", "put", "put", "put", "put", "get", "put", "put", "put", "put", "get", "get", "get", "put", "put", "put", "get", "put", "put", "put", "get", "put", "put", "put", "get", "get", "get", "put", "put", "put", "put", "get", "put", "put", "put", "put", "put", "put", "put" };
        string opParam = "[10,13],[3,17],[6,11],[10,5],[9,10],[13],[2,19],[2],[3],[5,25],[8],[9,22],[5,5],[1,30],[11],[9,12],[7],[5],[8],[9],[4,30],[9,3],[9],[10],[10],[6,14],[3,1],[3],[10,11],[8],[2,14],[1],[5],[4],[11,4],[12,24],[5,18],[13],[7,23],[8],[12],[3,27],[2,12],[5],[2,9],[13,4],[8,18],[1,7],[6],[9,29],[8,21],[5],[6,30],[1,12],[10],[4,15],[7,22],[11,26],[8,17],[9,29],[5],[3,4],[11,30],[12],[4,29],[3],[9],[6],[3,4],[1],[10],[3,29],[10,28],[1,20],[11,13],[3],[3,12],[3,8],[10,9],[3,26],[8],[7],[5],[13,17],[2,27],[11,15],[12],[9,19],[2,15],[3,16],[1],[12,17],[9,1],[6,19],[4],[5],[5],[8,1],[11,7],[5,2],[9,28],[1],[2,2],[7,4],[4,22],[7,24],[9,26],[13,28],[11,26]";
        opParam = opParam.Replace("[", "").Replace("]", "");
        List<int> opParamList = new List<int>();
        string[] opParamSub = opParam.Split(',');
        foreach(var iter in opParamSub)
        {
            opParamList.Add(int.Parse(iter));
        }
        //string[] opParamSub = opParam.Split(',');
        for (int i = 0; i < op.Length; ++i)
        {
            string iter = op[i];
            if (iter == "put")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("cache.Put " + opParamList[0] + " " + opParamList[1]);
                Console.ForegroundColor = ConsoleColor.White;
                cache.Put(opParamList[0], opParamList[1]);
                DebugState(cache);
                opParamList.RemoveAt(0);
                opParamList.RemoveAt(0);
                
            }
            else if (iter == "get")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("cache.Get " + opParamList[0]);
                Console.ForegroundColor = ConsoleColor.White;

                cache.Get(opParamList[0]);
                DebugState(cache);
                opParamList.RemoveAt(0);
            }
        }
    }

    public static void DebugState(LFUCache cache)
    {
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
        if (m_capacity == 0)
        {
            return -1;
        }

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

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(val);
            Console.ForegroundColor = ConsoleColor.White;
            return val;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(-1);
            Console.ForegroundColor = ConsoleColor.White;
            return -1;
        }
    }

    public void Put(int key, int value)
    {
        if (m_capacity == 0)
        {
            return;
        }
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
                Console.WriteLine("remove firstKey " + firstKey + " frequency " + frequencyData.m_frequency);
                if(frequencyData.m_dic.Count == 0)
                {
                    m_doubleLinkedList.RemoveNode(m_doubleLinkedList.m_first);
                }

                if (m_doubleLinkedList.Count == 0)
                {
                    Node node = m_doubleLinkedList.InsertNode(null, new FrequencyData(0, key));
                    m_valueDic.Add(key, new ValueData(value, node));
                }
                else
                {
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
        else
        {
            m_valueDic[key].m_val = value;

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
                if (newFrequency == nextFrequencyData.m_frequency)
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
        }
    }
}
