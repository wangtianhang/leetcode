using System;
using System.Collections.Generic;

using System.Text;



public class MyStack
{
    public static void Test()
    {
        MyStack myStack = new MyStack();
        myStack.Push(1);
        myStack.Push(2);
        myStack.Push(3);
        Console.WriteLine(myStack.Top());
        Console.WriteLine(myStack.Pop());
        Console.WriteLine(myStack.Top());
        Console.WriteLine(myStack.Pop());
        Console.WriteLine(myStack.Top());
        Console.WriteLine(myStack.Empty());
        Console.WriteLine(myStack.Pop());
        Console.WriteLine(myStack.Empty());
    }

    Queue<int> m_queueA = new Queue<int>();
    Queue<int> m_queueB = new Queue<int>();

    /** Initialize your data structure here. */
    public MyStack()
    {

    }

    /** Push element x onto stack. */
    public void Push(int x)
    {
        if(m_queueA.Count != 0)
        {
            m_queueA.Enqueue(x);
        }
        else if (m_queueB.Count != 0)
        {
            m_queueB.Enqueue(x);
        }
        else
        {
            m_queueA.Enqueue(x);
        }
    }

    /** Removes the element on top of the stack and returns that element. */
    public int Pop()
    {
        if (m_queueA.Count != 0)
        {
            while(m_queueA.Count != 1)
            {
                m_queueB.Enqueue(m_queueA.Dequeue());
            }
            return m_queueA.Dequeue();
        }
        else if (m_queueB.Count != 0)
        {
            while (m_queueB.Count != 1)
            {
                m_queueA.Enqueue(m_queueB.Dequeue());
            }
            return m_queueB.Dequeue();
        }
        else
        {
            throw new System.Exception("can not pop");
        }
    }

    /** Get the top element. */
    public int Top()
    {
        if (m_queueA.Count != 0)
        {
            while (m_queueA.Count != 1)
            {
                m_queueB.Enqueue(m_queueA.Dequeue());
            }
            int ret = m_queueA.Dequeue();
            m_queueB.Enqueue(ret);
            return ret;
        }
        else if (m_queueB.Count != 0)
        {
            while (m_queueB.Count != 1)
            {
                m_queueA.Enqueue(m_queueB.Dequeue());
            }
            int ret = m_queueB.Dequeue();
            m_queueA.Enqueue(ret);
            return ret;
        }
        else
        {
            throw new System.Exception("can not top");
        }
    }

    /** Returns whether the stack is empty. */
    public bool Empty()
    {
        if (m_queueA.Count + m_queueB.Count == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

