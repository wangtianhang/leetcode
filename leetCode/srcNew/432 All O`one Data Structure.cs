using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// head and tail can ensure both getMaxKey() and getMaxKey() be done in O(1).
/// keyCountMap maintains the count of keys, 
/// countBucketMap provides O(1) access to a specific Bucket with given count. 
/// Deleting and adding a Bucket in the Bucket list cost O(1), so both inc() and dec() take strict O(1) time.
/// </summary>
public class AllOne
{
    public static void Test()
    {
        AllOne test = new AllOne();
        test.Inc("hello");
        test.Inc("hello");
        test.GetMaxKey();
        test.GetMinKey();
        test.Inc("leet");
        test.GetMaxKey();
        test.GetMinKey();
    }

    // maintain a doubly linked list of Buckets
    private Bucket head;
    private Bucket tail;
    // for accessing a specific Bucket among the Bucket list in O(1) time
    private Dictionary<int, Bucket> countBucketMap = new Dictionary<int,Bucket>();
    // keep track of count of keys
    private Dictionary<String, int> keyCountMap = new Dictionary<string,int>();

    // each Bucket contains all the keys with the same count
    private class Bucket
    {
        public int count;
        public HashSet<String> keySet = new HashSet<string>();
        public Bucket next;
        public Bucket pre;
        public Bucket(int cnt) {
            count = cnt;
        }
    }
    /** Initialize your data structure here. */
    public AllOne()
    {
        head = new Bucket(int.MinValue);
        tail = new Bucket(int.MaxValue);
        head.next = tail;
        tail.pre = head;
    }

    /** Inserts a new key <Key> with value 1. Or increments an existing key by 1. */
    public void Inc(string key)
    {
        if (keyCountMap.ContainsKey(key))
        {
            changeKey(key, 1);
        }
        else
        {
            keyCountMap.Add(key, 1);
            if (head.next.count != 1)
                addBucketAfter(new Bucket(1), head);
            head.next.keySet.Add(key);
            if (countBucketMap.ContainsKey(1))
            {
                countBucketMap[1] = head.next;
            }
            else
            {
                countBucketMap.Add(1, head.next);
            }
        }
    }

    /** Decrements an existing key by 1. If Key's value is 1, remove it from the data structure. */
    public void Dec(string key)
    {
        if (keyCountMap.ContainsKey(key))
        {
            int count = keyCountMap[key];
            if (count == 1)
            {
                keyCountMap.Remove(key);
                removeKeyFromBucket(countBucketMap[count], key);
            }
            else
            {
                changeKey(key, -1);
            }
        }
    }

    /** Returns one of the keys with maximal value. */
    public string GetMaxKey()
    {
        if(tail.pre == head)
        {
            return "";
        }
        else
        {
            foreach(var iter in tail.pre.keySet)
            {
                return iter;
            }
            throw new System.Exception("GetMaxKey");
        }
    }

    /** Returns one of the keys with Minimal value. */
    public string GetMinKey()
    {
        if(head.next == tail)
        {
            return "";
        }
        else
        {
            foreach(var iter in head.next.keySet)
            {
                return iter;
            }
            throw new System.Exception("GetMinKey");
        }
    }

    // helper function to make change on given key according to offset
    private void changeKey(String key, int offset)
    {
        int count = keyCountMap[key];
        keyCountMap[key] = count + offset;
        Bucket curBucket = null;
        countBucketMap.TryGetValue(count, out curBucket);
        Bucket newBucket;
        if (countBucketMap.ContainsKey(count + offset))
        {
            // target Bucket already exists
            newBucket = countBucketMap[count + offset];
        }
        else
        {
            // add new Bucket
            newBucket = new Bucket(count + offset);
            countBucketMap.Add(count + offset, newBucket);
            addBucketAfter(newBucket, offset == 1 ? curBucket : curBucket.pre);
        }
        newBucket.keySet.Add(key);
        removeKeyFromBucket(curBucket, key);
    }

    private void removeKeyFromBucket(Bucket bucket, String key)
    {
        bucket.keySet.Remove(key);
        if (bucket.keySet.Count == 0)
        {
            removeBucketFromList(bucket);
            countBucketMap.Remove(bucket.count);
        }
    }

    private void removeBucketFromList(Bucket bucket)
    {
        bucket.pre.next = bucket.next;
        bucket.next.pre = bucket.pre;
        bucket.next = null;
        bucket.pre = null;
    }

    // add newBucket after preBucket
    private void addBucketAfter(Bucket newBucket, Bucket preBucket)
    {
        newBucket.pre = preBucket;
        newBucket.next = preBucket.next;
        preBucket.next.pre = newBucket;
        preBucket.next = newBucket;
    }
}

