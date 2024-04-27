using System.Data.Common;
using System.Runtime.CompilerServices;

namespace Polygon
{
    internal class Program
    {
        class Point
        {
            private int x, y;

            public Point(int x = 0, int y = 0)
            {
                this.x = x;
                this.y = y;
            }
            public int X { get { return x; } set { x = value; } }

            public int Y { 
                get { return y; } 
                set { y = value; } 
            }

            public void SetPoint(int x,int y) { 
                this.X = x;
                this.Y = y; 
            }

            public override string ToString()
            {
                return string.Format($"({x},{y})");
            }
            public Point Translate(Point mp)
            {
                return new Point(this.X + mp.X, this.Y + mp.Y);
            }
            public static Point operator+(Point a,Point b)
            {
                return new Point(a.X + b.X, a.Y + b.Y);
            }

            public static Point operator/(Point a,int f)
            {
                return new Point(a.X / f, a.Y / f);
            }
        }

        class Polygon
        {
            class FewVerticesException : Exception { }
            private readonly Point[] vertices;

            public Polygon(int size)
            {
                if (size < 3)
                {
                    throw new FewVerticesException();
                }
                vertices = new Point[size];
                for(int i = 0; i < size; i++)
                {
                    vertices[i] = new Point();
                }
            }
            public Point this[int i]
            {
                get 
                {
                    return vertices[i];
                }
                set
                {
                    vertices[i] = value;
                }
            }

            public override string ToString()
            {
                String str = "<";
                foreach(Point vertex in vertices)
                {
                    str += vertex.ToString();
                    str += ">";
                }
                return str;
            }
            public int NoOfSides
            {
                get
                {
                    return vertices.Length;
                }
            }
            
        }
        static void Main(string[] args)
        {
            Point p = new Point { X=3, Y=4 };
            Point q = new Point { X = 2, Y = 1 };

            Console.WriteLine((p/4).ToString());
        }
    }
}