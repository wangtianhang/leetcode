using System;
using System.Collections.Generic;

using System.Text;


public interface NestedInteger {

    // @return true if this NestedInteger holds a single integer, rather than a nested list.
    bool IsInteger();

    // @return the single integer that this NestedInteger holds, if it holds a single integer
    // Return null if this NestedInteger holds a nested list
    int GetInteger();

    // @return the nested list that this NestedInteger holds, if it holds a nested list
    // Return null if this NestedInteger holds a single integer
    IList<NestedInteger> GetList();
}

public class NestedIterator
{
    //IList<NestedInteger> m_nestedList = null;
    List<int> m_cacheList = new List<int>();
    int m_index = 0;
    public NestedIterator(IList<NestedInteger> nestedList)
    {
        //m_nestedList = nestedList;
        Recursion(nestedList);
    }

    void Recursion(IList<NestedInteger> nestedList)
    {
        if (nestedList == null)
        {
            return;
        }
        for (int i = 0; i < nestedList.Count; ++i)
        {
            if (nestedList[i].IsInteger())
            {
                m_cacheList.Add(nestedList[i].GetInteger());
            }
            else
            {
                Recursion(nestedList[i].GetList());
            }
        }
    }

    public bool HasNext()
    {
        return m_index < m_cacheList.Count;
    }

    public int Next()
    {
        int ret = m_cacheList[m_index];
        m_index += 1;
        return ret;
    }    
}

