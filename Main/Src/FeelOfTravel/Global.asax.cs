using System;
using System.Collections.Generic;
using System.Linq;

using FeelOfTravel.AutofacSupport;
using FeelOfTravel.Logic;

namespace FeelOfTravel
{
    public class Global : System.Web.HttpApplication
    {
        private void Application_Start(object sender, EventArgs e)
        {
            var root = CompositionRootBuilder.Build();
            CompositionRootHelper.SetCompositionRoot(root, Context);
        }

        private void Application_End(object sender, EventArgs e)
        {
        }

        private void Application_Error(object sender, EventArgs e)
        {
        }

        private void Session_Start(object sender, EventArgs e)
        {
        }

        private void Session_End(object sender, EventArgs e)
        {
        }

    }
}