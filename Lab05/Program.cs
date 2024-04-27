using TextFile;

namespace Lab05
{
    internal class Program
    {
        enum Status { norm, abnormanl };
        static void read(ref Status st, ref double e, ref TextFileReader x)
        {
            st = x.ReadDouble(out e) ? Status.norm : Status.abnormanl;
        }

        static double average(ref TextFileReader x)
        {

            Status st = Status.abnormanl;
            double e = 0;

            double avg, sum = 0;
            int count=0;

            read(ref st, ref e, ref x);
            while (st == Status.norm)
            {
                sum += e;
                count++;
                read(ref st, ref e, ref x);
            }
            return sum / count;
        }

        static void SelectNegative(ref TextFileReader x)
        {
            Status st = Status.abnormanl;
            double e = 0;
            read(ref st, ref e, ref x);
            while(st ==Status.norm && e >= 0)
            {
                read(ref st, ref e, ref x);
            }
        }

        static double averageAfternegative(ref TextFileReader x)
        {
            SelectNegative(ref x);
            return average(ref x);
        }

        static double sumPositive(ref TextFileReader x)
        {
            SelectNegative(ref x);

            Status st = Status.abnormanl;
            double e = 0;

            read(ref st, ref e, ref x);

            double sum = 0, count=0;
            while (st == Status.norm && e >= 0)
            {
                sum += e;
                count++;
                read(ref st, ref e, ref x);
            }
            return sum/count;
        }

        static int CountlocalMin(ref TextFileReader x)
        {
            int count = 0;
            Status st = Status.abnormanl;
            double e = 0;

            read(ref st, ref e, ref x);
            double prev = e;
            read(ref st, ref e, ref x);

            double current = e;
            while(st == Status.norm)
            {
                read(ref st, ref e, ref x);
                if(current<prev && current < e)
                {
                    count++;
                }
                prev = current;
                current = e;
            }
            return count;


        }
        static void Main(string[] args)
     {
            TextFileReader x = new TextFileReader("C:\\Users\\malik\\Downloads\\input 2.txt");

    
            Console.WriteLine(CountlocalMin(ref x));



            
    }
    }

    }
