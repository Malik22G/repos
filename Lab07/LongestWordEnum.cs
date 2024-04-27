

using System.Runtime.CompilerServices;

namespace LongestWordEnum_nps
{

    public struct Word
    {
       public string word;
        public bool w;
    }
    public enum Status
    {
        norm,abnorm
    };
    public class LongestWordEnum
    {
        private StreamReader _x;
        private char _dx;
        private Status _sx;
        private bool End;
        private Word curr;
        public LongestWordEnum(String path)
        {
            _x = new StreamReader(path);
            curr = new Word();
        }

        public void read()
        {
            _dx = (char)_x.Read();
            _sx = _x.Peek() == -1 ? Status.abnorm : Status.norm;
        }

        public void First()
        {
            read();
            Next();
        }
        public void Next()
        {
         
            
                while (_sx == Status.norm && _dx == ' ')
                {
                    read();
                }
            
            End = _sx == Status.abnorm;
            if (!End)
            {
                curr.word = "";
                curr.w = false;
                while (_sx == Status.norm && _dx != ' ')
                {
                    curr.word += _dx;
                    curr.w = curr.w | (_dx == 'w');
                    read();
                }
            }
        }
        public Word current()
        {
            return curr;
        }

        public bool end()
        {
            return End;
        }


    }
}
