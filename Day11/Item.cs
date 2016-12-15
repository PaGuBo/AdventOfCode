using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day11
{
    public class Item : IComparable<Item>
    {
        public Item(Material material, ItemType itemType)
        {
            Material = material;
            ItemType = itemType;
        }
        public Material Material;
        public ItemType ItemType;

        public int CompareTo(Item other)
        {
            if (Material > other.Material)
            {
                return 1;
            }
            else if(Material < other.Material)
            {
                return -1;
            }
            else
            {
                if (ItemType > other.ItemType)
                {
                    return 1;
                }
                else if (ItemType < other.ItemType)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}
