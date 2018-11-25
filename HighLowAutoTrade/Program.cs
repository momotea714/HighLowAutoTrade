using HighLowAutoTradeCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighLowAutoTrade
{
    class Program
    {
        static void Main(string[] args)
        {
            var engine = new HighLowAutoTradeEngine(1,1000,1);
            engine.Execute();
        }
    }
}
