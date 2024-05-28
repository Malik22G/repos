

namespace Tourist
{
    public class Castle:Wonder
    {
        public Castle(int x, int y, int i, int b) : base(x, y, i, b) { }

        public override string GetType()
        {
            return "cast";
        }
        protected override int Factor()
        {
            return (2023 - build) * 2;
        }
    }
}
