using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 还可以将数字分为左右两部分，左半部分存储小的一半数字，右半部分存储大的一半数字，
/// 插入数字时在左右两部分间做动态平衡，始终保持两部分数字数量相差1以内，
/// 这样找中位数就比较方便了。至此大家应该已经想到了用堆来对实现上述功能，左半部分用大根堆来存储，
/// 堆顶元素是左半部分最大的，右半部分用小根堆来存储，堆顶元素是右半部分最小的，
/// 始终保持左右两部分数字个数相等或左半部分比右半部分多一个，如果左半部分比右半部分多一个数字，
/// 中位数是左半部分堆顶数字；如果左右两部分数字个数相等，中位数是两个堆顶元素之和除以2。
/// </summary>
public class MedianFinder
{
    public static void Test()
    {
        MedianFinder test = new MedianFinder();
        test.AddNum(1);
        test.AddNum(2);
        Console.WriteLine(test.FindMedian());
        test.AddNum(3);
        Console.WriteLine(test.FindMedian());
    }

    MaxPQ<int> m_left = null;
    MinPQ<int> m_right = null;
    /** initialize your data structure here. */
    public MedianFinder()
    {
        m_left = new MaxPQ<int>(new IntComparer());
        m_right = new MinPQ<int>(new IntComparer());
    }

    public void AddNum(int num)
    {
        if (m_left.Size() == 0 || num > m_left.Top()) 
            m_right.Insert(num);
        else 
            m_left.Insert(num);

        if (m_left.Size() > m_right.Size() + 1)
        {
            m_right.Insert(m_left.DeleteTop());
        }
        else if (m_left.Size() < m_right.Size())
        {
            m_left.Insert(m_right.DeleteTop());
        }  
    }

    public double FindMedian()
    {
        if (m_left.Size() > m_right.Size())
            return m_left.Top();
        else 
            return (m_left.Top() + m_right.Top()) / 2.0; 
    }
}

public class IntComparer : IComparer<int>
{
    public int Compare(int x, int y)
    {
        if(x - y > 0)
        {
            return 1;
        }
        else if(x - y == 0)
        {
            return 0;
        }
        else
        {
            return -1;
        }
    }
}

public class PriorityQueue<T>
{
    protected T[] m_pq = null;
    int m_n = 0;

    protected IComparer<T> m_comparer = null;

    public int m_max = 100;

    public PriorityQueue( IComparer<T> comparer)
    {
        m_pq = new T[m_max + 1];
        m_comparer = comparer;
    }

    public PriorityQueue(IList<T> keys)
    {
        m_n = keys.Count;
        m_pq = new T[keys.Count + 1];
        for (int i = 0; i < m_n; i++)
            m_pq[i + 1] = keys[i];
        for (int k = m_n / 2; k >= 1; k--)
            Sink(k);
    }

    public void Insert(T a)
    {
        ++m_n;
        if(m_n > m_max)
        {
            m_max *= 2;
            T[] newPQ = new T[m_max * 2 + 1];
            Array.Copy(newPQ, m_pq, m_pq.Length);
            m_pq = newPQ;
        }
        m_pq[m_n] = a;
        Swim(m_n);
    }

    public T Top()
    {
        T top = m_pq[1];
        return top;
    }

    public T DeleteTop()
    {
        T top = m_pq[1];
        Exch(1, m_n--);
        m_pq[m_n + 1] = default(T);
        Sink(1);
        return top;
    }

    public bool IsEmpty()
    {
        return m_n == 0;
    }

    public int Size()
    {
        return m_n;
    }

    protected virtual bool less(int i, int j)
    {
        return false;
    }

    void Swim(int k)
    {
        while (k > 1 && less(k / 2, k))
        {
            Exch(k / 2, k);
            k = k / 2;
        }
    }

    void Sink(int k)
    {
        while (2 * k <= m_n)
        {
            int j = 2 * k;
            if (j < m_n && less(j, j + 1))
            {
                j++;
            }
            if (!less(k, j))
            {
                break;
            }
            Exch(k, j);
            k = j;
        }
    }

    void Exch(int i, int j)
    {
        T t = m_pq[i];
        m_pq[i] = m_pq[j];
        m_pq[j] = t;
    }
}

public class MinPQ<T> : PriorityQueue<T>
{
    public MinPQ(IComparer<T> comparer)
        : base(comparer)
    {
        m_pq = new T[m_max + 1];
        m_comparer = comparer;
    }

    public MinPQ(IList<T> keys)
        : base(keys)
    {

    }

    protected override bool less(int i, int j)
    {
        int ret = m_comparer.Compare(m_pq[i], m_pq[j]);
        if (ret > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

public class MaxPQ<T> : PriorityQueue<T>
{
    public MaxPQ(IComparer<T> comparer)
        : base(comparer)
    {
        m_pq = new T[m_max + 1];
        m_comparer = comparer;
    }

    protected override bool less(int i, int j)
    {
        int ret = m_comparer.Compare(m_pq[i], m_pq[j]);
        if (ret > 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
