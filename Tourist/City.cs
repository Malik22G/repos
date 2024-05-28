using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Tourist
{
    public class City
    {
        private List<District> ds;
        public City(List<District> dss)
        {
            ds = new List<District>();

            foreach(var d in dss)
            {
                if (ds.Contains(d))
                {
                    throw new Exception("Error");
                }
                ds.Add(d);
            }
        }

        public District WhichDistrict(Wonder w)
        {
            bool l = false;
            District elem = null;

            for(int i=0; i<ds.Count & ! l; i++)
            {
                for(int j = 0; j < ds[i].GetWounders().Count; j++)
                {
                        if (ds[i].GetWounders()[j].GetX() == w.GetX() && ds[i].GetWounders()[j].GetY() == w.GetY())
                        {
                            l = true;
                            elem = ds[i];
                        }
                }
            }
            if (l)
            {
                return elem;
            }
            else
            {
                throw new Exception("District Not found.");
            }

        }

        public District MaxTotalTime()
        {
            int max = ds[0].TotalTime();
            District elem = ds[0];

            for(int i = 1; i< ds.Count; i++)
            {
                if (ds[i].TotalTime() > max)
                {
                    max = ds[i].TotalTime();
                    elem = ds[i];
                }
            }

            return elem;
        }

        public bool CathedralEverywhere()
        {
            bool l = true;
            District elem = null;
            for(int i = 0; i< ds.Count & l; i++)
            {
                if(!(ds[i].Cathedrals() > 0))
                {
                    l = false;
                    elem = ds[i];
                }
            }

            return l;
        }

        public List<District> GetDistricts()
        {
            return ds;
        }



    }
}
