using System.Web.UI;

namespace FeelOfTravel.Logic.Common
{
    public static class PageHelper
    {
         public static string GetHost(this Page page)
         {
             return "http://" + page.Request.ServerVariables["HTTP_HOST"];
         }

         public static int GetIdInSpecialWay(string src)
         {
             if (src == null)
             {
                 return 0;
             }

             int tmpId;
             if (!int.TryParse(src, out tmpId))
             {
                 throw new PageException("Cannot get a number from " + src);
             }

             return tmpId;
         }
    }
}