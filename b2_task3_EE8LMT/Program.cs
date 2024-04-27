namespace b2_task3_EE8LMT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string dnaStrand = Console.ReadLine();
            var result = FindMostRecurringDNASequence(dnaStrand);
            if (result.Item1 == "")
            {
                Console.WriteLine("-1");
            }
            else
            {
                Console.WriteLine($"{result.Item1} {result.Item2}");
            }
        }
        private static Tuple<string, int> FindMostRecurringDNASequence(string dna)
        {
            if (dna.Length < 3) return Tuple.Create<string, int>("", 0);

            int maxCount = 0;
            string longestSequence = "";

            for (int i = 0; i < dna.Length - 2; i++)
            {
                for (int j = i + 3; j <= dna.Length; j++)
                {
                    string sequence = dna.Substring(i, j - i);
                    int count = CountOccurrences(dna, sequence);

                    
                    if (count * sequence.Length > dna.Length) continue;

                    if (count > maxCount || (count == maxCount && sequence.Length > (longestSequence?.Length ?? 0)))
                    {
                        maxCount = count;
                        longestSequence = sequence;
                    }
                }
            }

            return maxCount <= 1 ? Tuple.Create<string, int>("", 0) : Tuple.Create(longestSequence, maxCount);
        }

        private static int CountOccurrences(string str, string substring)
        {
            int count = 0;
            int i = 0;
            while ((i = str.IndexOf(substring, i)) != -1)
            {
                count++;
                i += substring.Length;
            }
            return count;
        }
    }
    }
