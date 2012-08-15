using System;

namespace FeelOfTravel.Logic.Common
{
    public static class NumberFormatter
    {
         public static string GetFormat(double value)
         {
             return string.Format("{0:0,0}", value) + " руб.";
         }
    }
}