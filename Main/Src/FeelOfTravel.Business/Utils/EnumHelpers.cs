using System;
using System.Linq;

namespace FeelOfTravel.Business.Utils
{
    public class EnumHelpers
    {
        public static TEnum GetMaxEnumValue<TEnum>()
            where TEnum : IComparable, IConvertible, IFormattable
        {
            var type = typeof(TEnum);

            return (TEnum)Enum.ToObject(type, GetMaxValue<TEnum>());
        }

        public static int GetMaxValue<TEnum>()
            where TEnum : IComparable, IConvertible, IFormattable
        {
            var type = typeof(TEnum);

            if (!type.IsSubclassOf(typeof(Enum)))
            {
                throw new InvalidCastException("Cannot cast '" + type.FullName + "' to System.Enum.");
            }

            return Enum.GetValues(type).Cast<int>().Last();
        }
    }
}