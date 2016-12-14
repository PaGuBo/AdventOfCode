using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day11
{
    public class BuildingComparer : IEqualityComparer<Item>
    {
        public bool Equals(Item x, Item y)
        {
            return x.State == y.State;
        }

        public int GetHashCode(Item obj)
        {
            return obj.State.GetHashCode();
        }
    }
}
