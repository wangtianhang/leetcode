using System;
using System.Collections.Generic;

using System.Text;



public class MyQueue
{
    Stack<int> m_stackA = new Stack<int>();
    Stack<int> m_stackB = new Stack<int>();
    /** Initialize your data structure here. */
    public MyQueue()
    {

    }

    /** Push element x to the back of queue. */
    public void Push(int x)
    {
        m_stackB.Push(x);
    }

    /** Removes the element from in front of queue and returns that element. */
    public int Pop()
    {
        if (Empty())
        {
            throw new System.Exception("can not dequeue");
        }

        if (m_stackA.Count == 0)
        {
            while (m_stackB.Count != 0)
            {
                m_stackA.Push(m_stackB.Pop());
            }
        }
        return m_stackA.Pop();
    }

    /** Get the front element. */
    public int Peek()
    {
        if (Empty())
        {
            throw new System.Exception("can not dequeue");
        }

        if (m_stackA.Count == 0)
        {
            while (m_stackB.Count != 0)
            {
                m_stackA.Push(m_stackB.Pop());
            }
        }

        return m_stackA.Peek();
    }

    /** Returns whether the queue is empty. */
    public bool Empty()
    {
        return m_stackA.Count + m_stackB.Count == 0;
    }
}

