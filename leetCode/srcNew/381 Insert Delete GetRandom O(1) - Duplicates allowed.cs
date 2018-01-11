using System;
using System.Collections.Generic;

using System.Text;



public class RandomizedCollection
{
    class IndexData
    {
        public IndexData(int key, int dicIndex)
        {
            m_key = key;
            m_dicIndex = dicIndex;
        }
        public int m_key = 0;
        public int m_dicIndex = 0;
    }
    Dictionary<int, List<int>> m_dic = new Dictionary<int, List<int>>();
    List<IndexData> m_set = new List<IndexData>();
    System.Random m_ran = null;

    /** Initialize your data structure here. */
    public RandomizedCollection()
    {
        long tick = System.DateTime.Now.Ticks;
        m_ran = new System.Random((int)(tick & 0xffffffffL) | (int)(tick >> 32));
    }

    /** Inserts a value to the collection. Returns true if the collection did not already contain the specified element. */
    public bool Insert(int val)
    {
        if (!m_dic.ContainsKey(val))
        {
            m_set.Add(new IndexData(val, 0));
            List<int> indexList = new List<int>();
            indexList.Add(m_set.Count - 1);
            m_dic.Add(val, indexList);
            return true;
        }
        else
        {
            
            List<int> indexList = m_dic[val];

            m_set.Add(new IndexData(val, indexList.Count));

            indexList.Add(m_set.Count - 1);
            return true;
        }
    }

    /** Removes a value from the collection. Returns true if the collection contained the specified element. */
    public bool Remove(int val)
    {
        if (m_dic.ContainsKey(val))
        {
            List<int> indexList = m_dic[val];
            if(indexList.Count > 0)
            {
                int index = indexList[indexList.Count - 1];
                indexList.RemoveAt(indexList.Count - 1);
                
                if(index != m_set.Count - 1)
                {
                    IndexData indexData = m_set[m_set.Count - 1];
                    m_set[index] = m_set[m_set.Count - 1];
                    List<int> replaceList = m_dic[indexData.m_key];
                    replaceList[indexData.m_dicIndex] = index;
                }

                m_set.RemoveAt(m_set.Count - 1);

                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    /** Get a random element from the collection. */
    public int GetRandom()
    {
        int index = m_ran.Next(0, m_set.Count);
        return m_set[index].m_key;
    }
}

