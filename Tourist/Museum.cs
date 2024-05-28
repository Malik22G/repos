using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tourist
{
    public class Museum: Wonder
    {
        public Museum(int x, int y, int i, int b) : base(x, y, i, b) { }

        public override string GetType()
        {
            return "mus";
        }
        protected override int Factor()
        {
            return 10000 / (x*x + y*y + 1);
        }
    }
}
