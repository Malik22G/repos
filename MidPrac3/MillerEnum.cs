using TextFile;

namespace MidPrac3
{
    public struct motoData
    {
        public string name;
        public int competitionNumber;
        public string time;
    }
    public struct winnerData
    {
        public int competitionNumber;
        public bool isMillerWinner;
    }
    public class MillerEnum
    {
        private TextFileReader x;
        private Status st;
        private motoData e;
        private winnerData curr;
        private bool _end;

        private void read()
        {

            bool notEnd = x.ReadString(out e.name);
            x.ReadInt(out e.competitionNumber);
            x.ReadString(out e.time);

            st = notEnd ? Status.normal : Status.abnormal;
        }
        public MillerEnum(string path)
        {
            x = new TextFileReader(path);
            curr = new winnerData();
            e = new motoData();
        }

        public void first()
        {
            read();
            next();
        }
        public void next()
        {
            _end = (st == Status.abnormal);
            if (!_end)
            {
                curr.competitionNumber = e.competitionNumber;
                curr.isMillerWinner = (e.name == "Miller");

                while(st == Status.normal && e.competitionNumber == curr.competitionNumber)
                {
                    read();
                }
            }
        }
        public winnerData current()
        {
            return curr;
        }
        public bool end()
        {
            return _end;
        }
    }
}
