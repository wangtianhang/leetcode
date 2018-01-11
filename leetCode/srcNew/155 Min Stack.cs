using System;
using System.Collections.Generic;

using System.Text;



class FastGetMinStack<T> where T : IComparable<T>
{
    List<T> m_stackItemList = new List<T>();
    List<int> m_link2NextMinItem = new List<int>();
    int m_minStackItemIndex = -1;

    public void Push(T x)
    {
        m_stackItemList.Add(x);
        if (m_minStackItemIndex < 0 || x.CompareTo(Min()) < 0)
        {
            m_link2NextMinItem.Add(m_stackItemList.Count - 1);
            m_minStackItemIndex = m_stackItemList.Count - 1;
        }
        else
        {
            m_link2NextMinItem.Add(m_minStackItemIndex);
        }
    }

    public T Pop()
    {
        if (m_stackItemList.Count == 0)
        {
            throw new System.Exception("no item to pop");
        }
        else
        {
            T ret = m_stackItemList[m_stackItemList.Count - 1];
            if (m_minStackItemIndex == m_stackItemList.Count - 1)
            {
                int willReadTop = m_stackItemList.Count - 1 - 1;
                if (willReadTop >= 0)
                {
                    m_minStackItemIndex = m_link2NextMinItem[willReadTop];
                }
                else
                {
                    m_minStackItemIndex = -1;
                }
            }
            m_stackItemList.RemoveAt(m_stackItemList.Count - 1);
            m_link2NextMinItem.RemoveAt(m_link2NextMinItem.Count - 1);
            return ret;
        }
    }

    public int Count()
    {
        return m_stackItemList.Count;
    }

    public T Min()
    {
        if (m_minStackItemIndex < 0)
        {
            throw new System.Exception("no min");
        }
        return m_stackItemList[m_minStackItemIndex];
    }

    public T Top()
    {
        if (m_stackItemList.Count == 0)
        {
            throw new System.Exception("no item to pop");
        }
        else
        {
            T ret = m_stackItemList[m_stackItemList.Count - 1];
            return ret;
        }
    }
}

public class MinStack
{
    public static void Test()
    {
        MinStack minStack = new MinStack();
        minStack.Push(-2);
        minStack.Push(0);
        minStack.Push(-3);
        Console.WriteLine(minStack.GetMin());
        minStack.Pop();
        Console.WriteLine(minStack.Top());
        Console.WriteLine(minStack.GetMin());  
    }

    FastGetMinStack<int> m_minStack = new FastGetMinStack<int>();
    /** initialize your data structure here. */
    public MinStack()
    {

    }

    public void Push(int x)
    {
        m_minStack.Push(x);
    }

    public void Pop()
    {
        m_minStack.Pop();
    }

    public int Top()
    {
        return m_minStack.Top();
    }

    public int GetMin()
    {
        return m_minStack.Min();
    }
}

