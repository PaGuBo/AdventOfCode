using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day10
{
    public class Bin
    {
        public int BinId { get; set; }
        public List<int> Chips { get; set; }
        public Bin(int binId)
        {
            BinId = binId;
            Chips = new List<int>();
        }
    }
}
