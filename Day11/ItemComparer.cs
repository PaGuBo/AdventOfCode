using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day11
{
    public class ItemComparer : IEqualityComparer<Item>
    {
        public bool Equals(Item x, Item y)
        {
            return x.ItemType == y.ItemType && x.Material == y.Material;
        }

        public int GetHashCode(Item obj)
        {
            var hashcode = 23;
            hashcode = (hashcode * 37) + (byte)obj.ItemType;
            hashcode = (hashcode * 37) + (byte) obj.Material;
            return hashcode;
        }
    }
}
