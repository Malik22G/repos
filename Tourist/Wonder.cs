using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tourist
{
    public abstract class Wonder
    {
        protected int x;
        protected int y;
        protected int interest;
        protected int build;
        private Guide guide;

        public int GetX()
        {
            return x;
        }
        public int GetY()
        {
            return y;
        }

        protected Wonder(int _x,int _y, int i, int b)
        {
            x = _x;
            y = _y;
            interest = i;
            build = b;
        }

        public abstract string GetType();

        public int ExpectedTime()
        {
            int g;
            if (guide == null)
            {
                g = 1;
            }
            else
            {
                g = 1 + guide.GetTalkative();
            }
            return Factor() * interest * g;
        }

        protected abstract int Factor();

        private static int Distance(Wonder w1, Wonder w2)
        {
            return Math.Abs(w1.x - w2.x) + Math.Abs(w1.y - w2.y);
        }

        public int Farthest(List<Wonder> ws)
        {
            if(ws.Count == 0)
            {
                throw new Exception("List of wounder is Empty");
            }

            int max = Distance(ws[0], this);

            for(int i = 1; i<ws.Count; i++)
            {
                if(Distance(ws[i], this) > max)
                {
                    max = Distance(ws[i], this);
                }
            }
            return max;
        }

        public void SetGuide(Guide g)
        {
            guide = g;
        }

    }
}
