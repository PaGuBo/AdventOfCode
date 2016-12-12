using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day10
{
    public class Bot
    {
        private const int val1 = 61;
        private const int val2 = 17;
        public Bot(string botId, int? high, int? low)
        {
            BotId = botId;
            High = high;
            Low = low;
        }

        public string BotId { get; private set; }
        public int? High { get; set; }
        public int? Low { get; set; }

        public void SetValue(int value)
        {
            if (High != null && Low != null)
            {
                throw new Exception("Bot already has two chips, can't take another");
            }
            else if (High == null & Low == null)
            {
                Low = value;
            }
            else
            {
                var temp = High.HasValue ? High.Value : Low.Value;
                if ((temp == val1 || temp == val2) &&
                    (value == val1 || value == val2))
                    Console.WriteLine("The bot we are looking for is # " + BotId);
                if (temp > value)
                {
                    High = temp;
                    Low = value;
                }
                else
                {
                    High = value;
                    Low = temp;
                }
            }

        }

        internal bool HasTwoChips()
        {
            return High != null && Low != null;
        }
    }
}
