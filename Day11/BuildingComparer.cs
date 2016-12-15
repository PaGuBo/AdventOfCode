using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day11
{
    public class BuildingComparer : IEqualityComparer<Building>
    {
        public bool Equals(Building x, Building y)
        {
            return x.State == y.State;
        }

        public int GetHashCode(Building obj)
        {
            return obj.State.GetHashCode();
        }
    }
}
