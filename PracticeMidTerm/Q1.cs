using System.IO;
using TextFile;

namespace PracticeMidTerm
{
    public struct semData
    {
        public string sem;
        public string neptune;
        public int numberOfHours;
    }
    public enum Status
    {
        norm,abNorm
    }
    public class Q1
    {
        private TextFileReader x;
        private semData e;
        private Status st;
        private int count;



        public Q1(String path) {
            x = new TextFileReader(path);
            e = new semData();
            count = 0;
        }

        public int giveCount()
        {
            return count;
        }

        private void read()
        {
                bool end = x.ReadString(out e.sem);
                x.ReadString(out e.neptune);
                x.ReadInt(out e.numberOfHours);
            


            st = end ? Status.norm : Status.abNorm;
        }

        public void solve()
        {
            read();
            while(st == Status.norm && !(e.neptune == "gfhdjs" && e.numberOfHours > 15 ))
            {
                read();
            }
            int cnt = 0;

            while (st == Status.norm )
            {
                if(e.neptune == "gfhdjs" && e.numberOfHours < 12)
                {
                    cnt = cnt + 1;
                }
                read();
            }
            count = cnt;
        }



            
    }
}
