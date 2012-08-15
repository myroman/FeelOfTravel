using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Script.Serialization;

namespace FeelOfTravel.Logic.Common
{
    public static class JsonHelper
    {
        public static string ToJSON(this object obj)
        {
            var serializer = new JavaScriptSerializer();
            return serializer.Serialize(obj);
        }

        public static string ToJSON(this object obj, int recursionDepth)
        {
            var serializer = new JavaScriptSerializer {RecursionLimit = recursionDepth};
            return serializer.Serialize(obj);
        }

    }
}