using System;
using System.Collections.Generic;
using System.Linq;

namespace FeelOfTravel.Logic.Common
{
    public static class Utils
    {
        public static string MakePublicHeader(string header)
        {
            return header + " - " + Constants.HEADER_SUFFIX;
        }

        public static void ThrowInvalidOperationException()
        {
            throw new InvalidOperationException("Image corrupted");
        }

        public static string MakeEditorHeader(string header)
        {
            return "Редактор - " + header;
        }
    }
}