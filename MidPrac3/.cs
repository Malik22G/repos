using System.Runtime.Intrinsics.X86;
using TextFile;

namespace MidPrac3
{
    public enum Status
    {
        normal,abnormal
    }
    public struct competitorData
    {
        public string name;
        public int competitionNumber;
        public string time;
        public bool isWinner;
    }
    public class Q1
    {
        private TextFileReader x;
        private Status st;
        private competitorData e;
        private int count;


        public Q1(string path)
        {
            x = new TextFileReader(path);
            e = new competitorData();
        }

        public int giveCount()
        {
            return count;
        }

        private void read()
        {
            e.isWinner = true;
            int prevCompetionNo = e.competitionNumber;
            
            bool notEnd = x.ReadString(out e.name);
            x.ReadInt(out e.competitionNumber);
            x.ReadString(out e.time);

            if (prevCompetionNo == e.competitionNumber) e.isWinner = false;


            st = notEnd ? Status.normal : Status.abnormal;
        }
        public void Solve()
        {
            read();
            while (st == Status.normal && !(e.name == "Savadori" && !e.isWinner ))
            {
                read();
            }
            read();
            int cnt = 0;
            while (st == Status.normal)
            {
                if(e.name=="Savadori" && e.isWinner)
                {
                    cnt++;
                }
                read();
            }
            count = cnt;
        }
    }
}
