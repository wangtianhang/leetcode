using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
* Definition for a point.
* public class Point {
*     public int x;
*     public int y;
*     public Point() { x = 0; y = 0; }
*     public Point(int a, int b) { x = a; y = b; }
* }
*/
public class Point
{
    public int x;
    public int y;
    public Point() { x = 0; y = 0; }
    public Point(int a, int b) { x = a; y = b; }
}

class _587_Erect_the_Fence
{
    public static void Test()
    {
        _587_Erect_the_Fence test = new _587_Erect_the_Fence();
        List<Point> input = new List<Point>();
        input.Add(new Point(1, 1));
        input.Add(new Point(2, 2));
        input.Add(new Point(2, 0));
        input.Add(new Point(2, 4));
        input.Add(new Point(3, 3));
        input.Add(new Point(4, 2));
        IList<Point> result = test.OuterTrees(input.ToArray());
        foreach(var iter in result)
        {
            Console.WriteLine(iter.x + " " + iter.y);
        }
    }


    public IList<Point> OuterTrees(Point[] points)
    {
        List<Point> input = new List<Point>(points);
        List<Point> ret2 = FastGetConvexHull(input);
        return ret2;
    }

    public static List<Point> FastGetConvexHull(List<Point> allPoint)
    {
        if(allPoint.Count == 3)
        {
            return allPoint;
        }
        ConverHullScan tmp = new ConverHullScan();
        return tmp.compute(allPoint);
    }


    /**
* Represents either the top or the bottom of a Convex Hull.
* 
* @author George Heineman
* @version 1.0, 6/15/08
* @since 1.0
*/
    class PartialHull
    {
        /** Points that make up the hull. */
        List<Point> m_points = new List<Point>();

        /**
    * Construct the initial partial hull.
    * 
    * @param first     Left-most point (for upper) and right-most (for lower) 
    * @param second    Next one in sorted order, as the next assumed point in the hull.
    */
        public PartialHull(Point first, Point second)
        {
            m_points.Add(first);
            m_points.Add(second);
        }
        /** Add point to the Partial Hull. */
        public void add(Point p)
        {
            m_points.Add(p);
        }
        /** Returns middle of last three. Returns true on success; false otherwise. */
        public bool removeMiddleOfLastThree()
        {
            if (!hasThree())
            {
                return false;
            }

            int pos = m_points.Count;
            Point point = m_points[pos - 2];
            //Console.WriteLine("removeMiddleOfLastThree " + point.x + " " + point.y);
            m_points.RemoveAt(pos - 2);
            return true;
        }

        /** Determine if there are more than 2 points currently in the partial hull. */
        public bool hasThree()
        {
            return m_points.Count > 2;
        }

        /** Helper function to report number of points in the hull. */
        public int size()
        {
            return m_points.Count;
        }

        /** Return the points in this Partial Hull. */
        public List<Point> points()
        {
            return m_points;
        }

        /** 
    * Determines if last three points reflect a right turn.
    * 
    * If hasThree() is false, then this returns false.
    */
        public bool areLastThreeNonRight()
        {
            if (!hasThree()) return false;  // something to do

            double x1, y1, x2, y2, x3, y3;

            int pos = m_points.Count - 3;

            x1 = m_points[pos].x;
            y1 = m_points[pos].y;

            x2 = m_points[pos + 1].x;
            y2 = m_points[pos + 1].y;

            x3 = m_points[pos + 2].x;
            y3 = m_points[pos + 2].y;

            double val1 = (x2 - x1) * (y3 - y1);
            double val2 = (y2 - y1) * (x3 - x1);
            double diff = val1 - val2;
            //leetcode上还要把共线的点加进来 蛋疼
            if (diff > 0.00001) 
            {
                return true;
            }
            else if (diff < 0)
            {
                return false;
            }
            else
            {
                return false;
            }
        }
    }

    /**
    * Computes Convex Hull following Andrew's Algorithm. This algorithm is described
    * in the text.
    * 
    * @author George Heineman
    * @version 1.0, 6/15/08
    * @since 1.0
    */
    class ConverHullScan
    {
        /**
    * Use Andrew's algorithm to return the computed convex hull for 
    * the input set of points.
    * <p>
    * Points must have at least three points to do anything meaningful. If
    * it does not, then the sorted array is returned as the "hull".
    * <p>
    * This algorithm will still work if duplicate points are found in
    * the input set of points.
    *
    * @param points     a set of (n &ge; 3) two dimensional points.
    */
        public List<Point> compute(List<Point> points)
        {
            // sort by x-coordinate (and if ==, by y-coordinate). 
            int n = points.Count;
            points.Sort(new CompareVector2ForConvexHull());
            if (n < 3) { return points; }

            // Compute upper hull by starting with leftmost two points
            PartialHull upper = new PartialHull(points[0], points[1]);
            for (int i = 2; i < n; i++)
            {
                upper.add(points[i]);
                while (upper.hasThree() && upper.areLastThreeNonRight())
                {
                    //Console.WriteLine("upper removeMiddleOfLastThree ");
                    upper.removeMiddleOfLastThree();
                }
            }

            // Compute lower hull by starting with rightmost two points
            PartialHull lower = new PartialHull(points[n - 1], points[n - 2]);
            for (int i = n - 3; i >= 0; i--)
            {
                lower.add(points[i]);
                while (lower.hasThree() && lower.areLastThreeNonRight())
                {
                    //Console.WriteLine("lower removeMiddleOfLastThree ");
                    lower.removeMiddleOfLastThree();
                }
            }

            // remove duplicate end points when combining.
            List<Point> hull = new List<Point>();
            for (int i = 0; i < upper.size(); ++i)
            {
                //Console.WriteLine("upper " + upper.points()[i].x + " " + upper.points()[i].y);
                hull.Add(upper.points()[i]);
            }
            for (int i = 1; i < lower.size() - 1; ++i)
            {
                //Console.WriteLine("lower " + lower.points()[i].x + " " + upper.points()[i].y);
                hull.Add(lower.points()[i]);
            }

            return hull;
        }

        class CompareVector2ForConvexHull : IComparer<Point>
        {
            public int Compare(Point v1, Point v2)
            {
                if (v1.x > v2.x)
                {
                    return 1;
                }
                else if (v1.x < v2.x)
                {
                    return -1;
                }
                else
                {
                    if (v1.y > v2.y)
                    {
                        return 1;
                    }
                    else if (v1.y < v2.y)
                    {
                        return -1;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
        }
    }
}

