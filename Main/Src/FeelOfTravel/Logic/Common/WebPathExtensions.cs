using System;
using System.Collections.Generic;
using System.Linq;

namespace FeelOfTravel.Logic.Common
{
    public static class WebPathExtensions
    {
        public static string FormatForHtml(this string link, string host)
        {
            if (string.IsNullOrEmpty(link))
            {
                return string.Empty;
            }
            return host + link.Replace("\\", "/");
        }
    }
}