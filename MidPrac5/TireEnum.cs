using TextFile;

namespace MidPrac5
{
    public enum Status
    {
        normal,abnormal
    }
    public struct serviceData
    {
        public string date;
        public int year;
        public int kms;
        public string service;
    }

    public struct tireData {
        public int year;
        public int tireChange;
    }

    public class TireEnum
    {
        private TextFileReader x;
        private Status st;
        private serviceData e;
        private tireData curr;
        private bool _end;

        private void read()
        {
            bool notEnd = x.ReadString(out e.date);
            x.ReadInt(out e.kms);
            x.ReadLine(out e.service);
            
            if(notEnd) e.year = int.Parse(e.date.Split("/")[0]);

            st = notEnd ? Status.normal : Status.abnormal;
        }

        public TireEnum(string path)
        {
            x = new TextFileReader(path);
            e = new serviceData();
            curr = new tireData();
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
                curr.year = e.year;
                curr.tireChange = 0;

                while(st == Status.normal && e.year == curr.year)
                {
                   if (e.service == "tire change")
                    {
                        curr.tireChange++;
                    }
                    read();
                }
            }
        }
        public tireData current()
        {
            return curr;
        }
        public bool end()
        {
            return _end;
        }

    }
}
