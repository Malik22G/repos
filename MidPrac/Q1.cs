using TextFile;

namespace MidPrac
{
    public enum Status
    {
        norm,abnorm
    }
    public struct Stat
    {
        public string name;
        public int points;
    }
    public class Q1
    {
        private TextFileReader x;
        private Status st;
        private Stat e;
        private bool highResults;

        public Q1(string path)
        {
            x = new TextFileReader(path);
            e = new Stat();
            
        }

        public string isHighResults()
        {
            if (highResults) return "yes";
            return "no";
        }
        private void read()
        {
            bool notEnd = x.ReadString(out e.name);
            x.ReadInt(out e.points);

            st = notEnd ? Status.norm : Status.abnorm;
        }
        public void Solve()
        {
            read();
            while(st == Status.norm && !(e.name == "Samy"))
            {
                read();
            }

            highResults = false;
            while (st == Status.norm && !highResults)
            {
                if(e.points > 50)
                {
                    highResults = true;
                }
                read();
            }
        }

        

    }
}
