using System.Web;

using FeelOfTravel.AutofacSupport;

namespace FeelOfTravel.Logic
{
    public class CompositionRootHelper
    {
        public static void SetCompositionRoot(CompositionRoot value, HttpContext context)
        {
            HttpContext.Current.Application["compositionRoot"] = value;
        }

        public static CompositionRoot GetCompositionRoot(HttpContext context)
        {
            var root = HttpContext.Current.Application["compositionRoot"] as CompositionRoot;
            return root;
        }
    }
}