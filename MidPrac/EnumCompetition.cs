
using TextFile;

namespace MidPrac
{
    public class EnumCompetition
    {
        private TextFileReader x;
        private Status st;
        private Stat e;
        private Stat curr;
        private bool _end;

        public EnumCompetition(String path)
        {
            x = new TextFileReader(path);
            e = new Stat();
            curr = new Stat();
        }

        public void read()
        {
            bool notEnd = x.ReadString(out e.name);
            x.ReadInt(out e.points);

            st = notEnd ? Status.norm : Status.abnorm;
        }

        public void first()
        {
            read();
            next();
        }
        public void next()
        {
            _end = (st == Status.abnorm);

            if (!_end)
            {
                curr.name = e.name;
                curr.points = 0;

                while(st == Status.norm && e.name == curr.name)
                {
                    curr.points += e.points;
                    read();
                }
            }
        }
        public Stat current()
        {
            return curr;
        }
        public bool end()
        {
            return _end;
        }
    }
}
