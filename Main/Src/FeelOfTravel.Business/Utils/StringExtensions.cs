namespace FeelOfTravel.Model.Utils
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class StringExtensions
    {
        public static string SafeCrop(this string src, int length)
        {
            if (src == null)
            {
                return null;
            }
            if (length > src.Length)
            {
                return src;
            }

            return src.Substring(0, length);
        }

        public static string SafeCropAndComplete(this string src, int length)
        {
            string cropped = src.SafeCrop(length);
            return cropped.Length < src.Length ? cropped + "..." : cropped;
        }
    }
}
