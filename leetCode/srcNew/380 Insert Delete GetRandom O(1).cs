using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class RandomizedSet
{
    public static void Test()
    {
        RandomizedSet test = new RandomizedSet();
        test.Insert(3);
        test.Insert(-2);
        test.Remove(2);
        test.Insert(1);
        test.Insert(-3);
        test.Insert(-2);
        test.Remove(-2);
        test.Remove(3);
        test.Insert(-1);
        test.Remove(-3);
        test.Insert(1);
        test.Insert(-2);
        test.Insert(-2);
        test.Insert(-2);
        test.Insert(1);
        test.GetRandom();
        test.Insert(-2);
        test.Remove(0);
        test.Insert(-3);
        test.Insert(1);
    }

    Dictionary<int, int> m_dic = new Dictionary<int, int>();
    List<int> m_set = new List<int>();
    System.Random m_ran = null;
    /** Initialize your data structure here. */
    public RandomizedSet()
    {
        long tick = System.DateTime.Now.Ticks;
        m_ran = new System.Random((int)(tick & 0xffffffffL) | (int)(tick >> 32));
    }

    /** Inserts a value to the set. Returns true if the set did not already contain the specified element. */
    public bool Insert(int val)
    {
        if (!m_dic.ContainsKey(val))
        {
            m_set.Add(val);
            m_dic.Add(val, m_set.Count - 1);
            return true;
        }
        else
        {
            return false;
        }
    }

    /** Removes a value from the set. Returns true if the set contained the specified element. */
    public bool Remove(int val)
    {
        if(m_dic.ContainsKey(val))
        {
            int index = m_dic[val];
            int key = m_set[m_set.Count - 1];
            m_dic.Remove(val);

            m_set[index] = m_set[m_set.Count - 1];
            m_set.RemoveAt(m_set.Count - 1);

            m_dic[key] = index;
            return true;
        }
        else
        {
            return false;
        }
    }

    /** Get a random element from the set. */
    public int GetRandom()
    {
        int index = m_ran.Next(0, m_set.Count);
        return m_set[index];
    }
}

