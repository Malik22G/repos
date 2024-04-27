using TextFile;

namespace Lab06
{
    public struct Stat
    {
        public string acc, date;
        public int amount;

    }
    enum Status  {norm,abnorm};
    public class Bank
    {
        private string _e;
        private  Status _st;
        private TextFileReader _x;

        private Stat _current;
        private bool _end;

        public Bank(string path)
        {
            _x = new TextFileReader(path);
        }

        public int current() { return _current.amount; }
        public bool end() { return _end; }
 

        public void read()
        {
            _st = _x.ReadLine(out _e) ? Status.norm : Status.abnorm;
        }

        public void next() {
            _end = (_st == Status.abnorm);

        if (!_end)
            {
                _current.acc = _e.Split(" ")[0];
                _current.date = _e.Split(" ")[1];
                _current.amount = int.Parse(_e.Split(" ")[1]);
            }
            
        }
        public  void first()
        {
            read();
            next();
        }

        override 
        public string ToString()
        {
            return $"{_current.acc} | {_current.amount}";
        }
    }
}
