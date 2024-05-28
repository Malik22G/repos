using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tourist
{
    public class District
    {
        private string name;
        private List<Wonder> ws;


        public string GetName()
        {
            return name;
        }
        public List<Wonder> GetWounders()
        {
            return ws;
        }
        public District(string n, List<Wonder> wss)
        {
            ws = new List<Wonder>();
            name = n;       
            foreach(var w in wss)
            {
                if (ws.Contains(w))
                {
                    throw new Exception("Wounder Alredy Exists.");
                }
                ws.Add(w);
            }

        }

        public int MaxDistance()
        {
            if (ws.Count == 0) throw new Exception($"No wounders in this {name} district.");

            int max = ws[0].Farthest(ws);
            for(int i = 1; i< ws.Count; i++)
            {
                if(ws[i].Farthest(ws) > max)
                {
                    max = ws[i].Farthest(ws);
                }
            }

            return max;
        }

        public int Cathedrals()
        {
            int count = 0;
            for(int i = 0; i<ws.Count; i++)
            {
                if (ws[i].GetType() == "cath")
                {
                    count++;
                }
            }
            return count;
        }



        public int TotalTime()
        {
            int sum = 0;
            for(int i = 0; i< ws.Count; i++)
            {
                sum += ws[i].ExpectedTime(); 
            }
            return sum;
        }

    }
}
