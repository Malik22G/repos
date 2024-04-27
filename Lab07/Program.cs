namespace LongestWordEnum_nps
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LongestWordEnum t = new LongestWordEnum("C:\\Users\\malik\\Downloads\\test.txt");
            bool l = false;
            int max = 0;
            string longestWord = "";

            while (!t.end())
            {
                if (t.current().w && l)
                {
                    if (t.current().word.Length > max)
                    {
                        max = t.current().word.Length;
                        longestWord = t.current().word;
                    }
                }
                if (t.current().w && !l)
                {
                    l = true;
                    max = t.current().word.Length;
                    longestWord = t.current().word;
                }
                t.Next();
            }

            Console.WriteLine(longestWord);
        }
    }
}