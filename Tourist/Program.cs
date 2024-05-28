using TextFile;
namespace Tourist
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<District> input = new List<District>();

            Console.WriteLine("Give Input file path:");
            string filename = Console.ReadLine();
            

            TextFileReader x = new TextFileReader(filename);

            x.ReadInt(out int Q1index);

            x.ReadString(out string type);
            x.ReadInt(out int X);
            x.ReadInt(out int Y);
            x.ReadInt(out int interest);
            x.ReadInt(out int build);

            Wonder w;

            switch (type)
            {
                case "museum":
                    w = new Museum(X, Y, interest, build);
                    break;
                case "castle":
                    w = new Castle(X, Y, interest, build);
                    break;
                case "cathedral":
                    w = new Cathedral(X, Y, interest, build);
                    break;
                default:
                    throw new Exception("Invalid type of wounder.");

            }


            while (x.ReadString(out string distName))
            {
                x.ReadInt(out int num);

                List<Wonder> wounders = new List<Wonder>();

                for (int i = 0; i< num; i++)
                {
                    x.ReadString(out type);
                    x.ReadInt(out X);
                    x.ReadInt(out Y);
                    x.ReadInt(out interest);
                    x.ReadInt(out build);

                    switch (type)
                    {
                        case "museum":
                            wounders.Add(new Museum(X, Y, interest, build));
                            break;
                        case "castle":
                            wounders.Add(new Castle(X, Y, interest, build));
                            break;
                        case "cathedral":
                            wounders.Add(new Cathedral(X, Y, interest, build));
                            break;
                        default:
                            throw new Exception("Invalid type of wounder.");

                    }

                }

                input.Add(new District(distName, wounders));
            }

            City Budapest = new City(input);

            Console.WriteLine($"Q1: {Budapest.GetDistricts()[Q1index].MaxDistance()}");


            Console.WriteLine($"Q2: {Budapest.WhichDistrict(w).GetName()}");


            Console.WriteLine($"Q3: {Budapest.GetDistricts()[Q1index].Cathedrals()}");

            Console.WriteLine($"Q4: {Budapest.MaxTotalTime().GetName()}");

            Console.WriteLine($"Q5: {Budapest.CathedralEverywhere()}");



        }
    }
}