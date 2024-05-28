using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tourist
{
    public class Cathedral:Wonder
    {
        public Cathedral(int x, int y, int i, int b) : base(x, y, i, b) { }

        public override string GetType()
        {
            return "cath";
        }
        protected override int Factor()
        {
            return (2023 - build) + 5;
        }

    }
}
