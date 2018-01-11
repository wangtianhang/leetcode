using System;
using System.Collections.Generic;

using System.Text;



public class Twitter
{
    public static void Test()
    {
         Twitter test = new Twitter();
//         test.PostTweet(1, 5);
//         foreach (var iter in test.GetNewsFeed(1))
//         {
//             Console.Write(iter + ",");
//         }
//         Console.WriteLine();
//         test.Follow(1, 2);
//         test.PostTweet(2, 6);
//         foreach (var iter in test.GetNewsFeed(1))
//         {
//             Console.Write(iter + ",");
//         }
//         Console.WriteLine();
//         test.Unfollow(1, 2);
//         foreach (var iter in test.GetNewsFeed(1))
//         {
//             Console.Write(iter + ",");
//         }
//         Console.WriteLine();
         for (int i = 0; i < 11; ++i )
         {
             test.PostTweet(1, i);
         }
        foreach(var iter in test.GetNewsFeed(1))
        {
            Console.Write(iter + ",");
        }
    }
    class User
    {
        public List<int> m_followee = new List<int>();
        public List<NewData> m_news = new List<NewData>();
    }

    class NewData
    {
        public NewData(int id, int time)
        {
            m_id = id;
            m_time = time;
        }
        public int m_id;
        public int m_time;
    }

    class NewDataCompare : IComparer<NewData>
    {
        public int Compare(NewData x, NewData y)
        {
            if(x.m_time - y.m_time > 0)
            {
                return 1;
            }
            else if (x.m_time - y.m_time == 0)
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }
    }

    int m_curTime = 0;
    Dictionary<int, User> m_hash = new Dictionary<int, User>();

    /** Initialize your data structure here. */
    public Twitter()
    {

    }

    /** Compose a new tweet. */
    public void PostTweet(int userId, int tweetId)
    {
        if (!m_hash.ContainsKey(userId))
        {
            m_hash.Add(userId, new User());
        }
        m_hash[userId].m_news.Add(new NewData(tweetId, ++m_curTime));
    }

    /** Retrieve the 10 most recent tweet ids in the user's news feed. Each item in the news feed must be posted by users who the user followed or by the user herself. Tweets must be ordered from most recent to least recent. */
    public IList<int> GetNewsFeed(int userId)
    {
        if(m_hash.ContainsKey(userId))
        {
            User user = m_hash[userId];
            MaxPQWithSize<NewData> maxTimeQueue = new MaxPQWithSize<NewData>(10, new NewDataCompare());
            foreach(var newData in user.m_news)
            {
                maxTimeQueue.Insert(newData);
            }
            foreach (var followee in user.m_followee)
            {
                User followUser = null;
                if(m_hash.TryGetValue(followee, out followUser))
                {
                    foreach(var newData in followUser.m_news)
                    {
                        maxTimeQueue.Insert(newData);
                    }
                }
            }
//             List<int> ret = new List<int>();
//             while (maxTimeQueue.Size() != 0)
//             {
//                 ret.Add(maxTimeQueue.DeleteTop().m_id);
//             }
            List<NewData> maxTimeList = maxTimeQueue.GetAll();
            List<int> ret = new List<int>();
            foreach(var iter in maxTimeList)
            {
                ret.Add(iter.m_id);
            }
            return ret;
        }
        else
        {
            return new List<int>();
        }
    }

    /** Follower follows a followee. If the operation is invalid, it should be a no-op. */
    public void Follow(int followerId, int followeeId)
    {
        if (followerId == followeeId)
        {
            return;
        }
        if (!m_hash.ContainsKey(followerId))
        {
            m_hash.Add(followerId, new User());
        }
        if (!m_hash[followerId].m_followee.Contains(followeeId))
        {
            m_hash[followerId].m_followee.Add(followeeId);
        }
    }

    /** Follower unfollows a followee. If the operation is invalid, it should be a no-op. */
    public void Unfollow(int followerId, int followeeId)
    {
        if (!m_hash.ContainsKey(followerId))
        {
            m_hash.Add(followerId, new User());
        }
        m_hash[followerId].m_followee.Remove(followeeId);
    }
}

public class PriorityQueue<T>
{
    protected T[] m_pq = null;
    int m_n = 0;

    protected IComparer<T> m_comparer = null;

    public PriorityQueue(int max, IComparer<T> comparer)
    {
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
        m_pq[++m_n] = a;
        Swim(m_n);
    }

    public void ChangeTop(T a)
    {
        m_pq[1] = a;
        Swim(1);
        Sink(1);
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
    public MinPQ(int max, IComparer<T> comparer)
        : base(max, comparer)
    {
        m_pq = new T[max + 1];
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
    public MaxPQ(int max, IComparer<T> comparer)
        : base(max, comparer)
    {
        m_pq = new T[max + 1];
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

public class MaxPQWithSize<T>
{
    MinPQ<T> m_minPQ = null;
    IComparer<T> m_comparer = null;
    int m_max = 0;
    public MaxPQWithSize(int max, IComparer<T> comparer)
    {
        //m_pq = new T[max + 2];
        m_max = max;
        m_minPQ = new MinPQ<T>(max, comparer);
        m_comparer = comparer;
    }

    public int Size()
    {
        return m_minPQ.Size();
    }

    public void Insert(T a)
    {
        if (m_minPQ.Size() < m_max)
        {
            m_minPQ.Insert(a);
        }
        else
        {
            if (m_comparer.Compare(m_minPQ.Top(), a) < 0)
            {
                m_minPQ.ChangeTop(a);
            }
        }
    }

    public List<T> GetAll()
    {
        List<T> ret = new List<T>();
        while(m_minPQ.Size() != 0)
        {
            ret.Add(m_minPQ.DeleteTop());
        }
        ret.Reverse();
        return ret;
    }
}



