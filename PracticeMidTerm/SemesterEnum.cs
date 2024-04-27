using TextFile;

namespace PracticeMidTerm
{
    public struct semHoursData
    {
        public string sem;
        public int hours;
    }
    public class SemesterEnum
    {
        private bool _end;
        private TextFileReader x;
        private Status st;
        private semData e;
        private semHoursData curr;

        public SemesterEnum(string path)
        {
            x = new TextFileReader(path);
            e = new semData();
            curr = new semHoursData();
        }
        private void read()
        {
            bool end = x.ReadString(out e.sem);
            x.ReadString(out e.neptune);
            x.ReadInt(out e.numberOfHours);



            st = end ? Status.norm : Status.abNorm;
            
        }


        public void first()
        {
            read();
            next();
        }
        public void next()
        {
            _end = st == Status.abNorm ? true : false;
            if (!_end)
            {
                curr.sem = e.sem;
                curr.hours = 0;
                while(st==Status.norm && e.sem == curr.sem)
                {
                    curr.hours += e.numberOfHours;
                    read();
                }
            }

        }
        public semHoursData current()
        {
            return curr;
        }
        public bool end()
        {
            return _end;
        }
    }
}
