using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighLowAutoTradeCore.Biz.Extensions
{
    public static class EnumExtensions
    {
        public static T ToEnum<T>(this object obj)
        {
            return (T)Enum.ToObject(typeof(T), obj);
        }

        public static T ToEnum<T>(this int value)
        {
            return (T)Enum.ToObject(typeof(T), value);
        }
    }
}
