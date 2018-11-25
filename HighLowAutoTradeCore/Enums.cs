using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighLowAutoTradeCore
{
    public enum TradeType
    {
        HighLow_15min = 1,
        HighLow_1hour = 2,
        HighLow_1day = 3,
        HighLowSpread_15min = 4,
        HighLowSpread_1hour = 5,
        HighLowSpread_1day = 6,
        HighLowTurbo_30sec = 7,
        HighLowTurbo_1min = 8,
        HighLowTurbo_3min = 9,
        HighLowTurbo_5min = 10,
        HighLowTurboSpread_30sec = 11,
        HighLowTurboSpread_1min = 12,
        HighLowTurboSpread_3min = 13,
        HighLowTurboSpread_5min = 14,
    }

    public enum TradeDirection
    {
        Up = 1,
        Down = 2,
    }

    public enum TradePair
    {
        Up = 1,
        Down = 2,
    }

    public enum BrowserName
    {
        None,
        Chrome,
        Firefox,
        InternetExplorer,
        Edge,
        Safari
    }
}
