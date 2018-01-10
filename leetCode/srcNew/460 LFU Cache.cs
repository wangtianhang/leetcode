using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        foreach (var iter in cache.m_valueDic)
        {
            Console.WriteLine("dic " + iter.Key + " " + iter.Value);
        }
        FrequencyNode node = cache.m_first;
        while(node != null)
        {
            Console.WriteLine("linkedlist " + node);
            node = node.m_next;
        }
    }

    public class FrequencyNode
    {
        public int m_frequency = 0;
        public Dictionary<int, int> m_dic = new Dictionary<int, int>();
        public FrequencyNode m_prev = null;
        public FrequencyNode m_next = null;

        public override string ToString()
        {
            string keys = "";
            foreach(var iter in m_dic)
            {
                keys += iter.Key + ",";
            }
            string ret = "frequency:" + m_frequency.ToString() + ",keys:" + keys;
            if(m_prev != null)
            {
                ret += "prev:" + m_prev.m_frequency + ",";
            }
            else
            {
                ret += "prev:null,";
            }
            if (m_next != null)
            {
                ret += "next:" + m_next.m_frequency + ",";
            }
            else
            {
                ret += "next:null,";
            }
            return ret;
        }
    }

    public class ValueData
    {
        public int m_val = 0;
        public FrequencyNode m_node = null;

        public override string ToString()
        {
            return "value:" + m_val.ToString() + "," + m_node.ToString();
        }
    }

    public FrequencyNode m_first = null; // frequency从小到大 fist为小
    //FrequencyNode m_last = null;
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

            FrequencyNode node = m_valueDic[key].m_node;
            int newFrequency = node.m_frequency + 1;
            node.m_dic.Remove(key);
            if(node.m_dic.Count == 0)
            {
                if(node.m_next != null)
                {
                    node.m_next.m_prev = node.m_prev;
                    if(node == m_first)
                    {
                        m_first = node.m_next;
                    }
                }
                if (node.m_prev != null)
                {
                    node.m_prev.m_next = node.m_next;
                }
            }

            if(node.m_next == null)
            {
                FrequencyNode newNode = new FrequencyNode();
                newNode.m_frequency = newFrequency;
                newNode.m_dic.Add(key, 0);
                newNode.m_prev = node;
                m_valueDic[key].m_node = newNode;

                node.m_next = newNode;
            }
            else
            {
                if (newFrequency == node.m_next.m_frequency)
                {
                    node.m_next.m_dic.Add(key, 0);
                    m_valueDic[key].m_node = node.m_next;
                }
                else if (newFrequency < node.m_next.m_frequency)
                {
                    FrequencyNode newNode = new FrequencyNode();
                    newNode.m_frequency = newFrequency;
                    newNode.m_dic.Add(key, 0);
                    newNode.m_next = node.m_next;
                    newNode.m_prev = node.m_prev;

                    newNode.m_prev.m_next = newNode;
                    newNode.m_next.m_prev = newNode;
                    m_valueDic[key].m_node = newNode;
                }
                else
                {
                    throw new System.Exception("newFrequency can not > node.m_next.m_frequency");
                }
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
                if (m_first == null)
                {
                    m_first = new FrequencyNode();
                    m_first.m_dic.Add(key, 0);

                    //m_last = m_first;

                    ValueData valueData = new ValueData();
                    valueData.m_val = value;
                    valueData.m_node = m_first;
                    m_valueDic.Add(key, valueData);
                }
                else
                {
                    if(m_first.m_frequency == 0)
                    {
                        m_first.m_dic.Add(key, 0);

                        ValueData valueData = new ValueData();
                        valueData.m_val = value;
                        valueData.m_node = m_first;
                        m_valueDic.Add(key, valueData);
                    }
                    else
                    {
                        FrequencyNode newNode = new FrequencyNode();
                        newNode.m_dic.Add(key, 0);
                        newNode.m_next = m_first;
                        m_first.m_prev = newNode;
                        m_first = newNode;

                        ValueData valueData = new ValueData();
                        valueData.m_val = value;
                        valueData.m_node = newNode;
                        m_valueDic.Add(key, valueData);
                    }
                }
            }
            else
            {
                int firstKey = -1;
                // todo 此处的时间复杂度？看c#源码应该是个array
                foreach(var iter in m_first.m_dic)
                {
                    firstKey = iter.Key;
                    break;
                }
                m_first.m_dic.Remove(firstKey);
                m_valueDic.Remove(firstKey);
                if(m_first.m_dic.Count == 0)
                {
                    m_first = m_first.m_next;
                }

                if (m_first.m_frequency == 0)
                {
                    m_first.m_dic.Add(key, 0);

                    ValueData valueData = new ValueData();
                    valueData.m_val = value;
                    valueData.m_node = m_first;
                    m_valueDic.Add(key, valueData);
                }
                else
                {
                    FrequencyNode newNode = new FrequencyNode();
                    newNode.m_dic.Add(key, 0);
                    newNode.m_next = m_first;
                    m_first.m_prev = newNode;
                    m_first = newNode;

                    ValueData valueData = new ValueData();
                    valueData.m_val = value;
                    valueData.m_node = newNode;
                    m_valueDic.Add(key, valueData);
                }
            }
        }
    }
}
