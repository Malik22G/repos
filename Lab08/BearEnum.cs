using TextFile;

namespace Lab08
{

    public struct HunterData
    {
        public string name;
        public string date;
        public string animal;
    }
    public struct BearHuntData
    {
        public string name;
        public bool huntedBear;
    }
    public enum Status
    {
        norm, abnorm
    };
    public class BearEnum
    {

            private TextFileReader _x;
            private HunterData _dx;
            private Status _sx;
            private bool End;
            private BearHuntData curr;
            public BearEnum(String path)
            {
                _x = new TextFileReader(path);
                _dx = new HunterData();
                curr = new BearHuntData();
            }

            public void read()
            {
                _x.ReadString(out _dx.name);
            _x.ReadString(out _dx.date);
            bool tempx = _x.ReadString(out _dx.animal);


            _sx = tempx ? Status.norm : Status.abnorm;
            }

            public void First()
            {
                read();
                Next();
            }
            public void Next()
            {
            End = _sx == Status.abnorm;
            if (!End)
            {
                curr.name = _dx.name;
                curr.huntedBear = false;
                while (_sx == Status.norm && _dx.name == curr.name)
                {
                    curr.huntedBear = curr.huntedBear | (_dx.animal == "Bear");
                    Console.WriteLine(_dx.animal);
                    read();
                }
            }



        }
            public BearHuntData current()
            {
                return curr;
            }

            public bool end()
            {
                return End;
            }


        }
    }


