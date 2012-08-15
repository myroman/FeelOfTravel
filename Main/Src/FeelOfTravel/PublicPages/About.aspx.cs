using System;
using System.Collections.Generic;
using System.Linq;

using FeelOfTravel.AutofacSupport;
using FeelOfTravel.Business.Domain;
using FeelOfTravel.Logic;

namespace FeelOfTravel.PublicPages
{
    public partial class About : System.Web.UI.Page
    {
        private CompositionRoot compositionRoot;

        protected void Page_Load(object sender, EventArgs e)
        {
            compositionRoot = CompositionRootHelper.GetCompositionRoot(Context);
        }

        protected string AboutContent
        {
            get { return compositionRoot.GetSimplePageRepository(SimplePageType.About).GetPlainContent(); }
        }

        protected string ContactsContent
        {
            get { return compositionRoot.GetSimplePageRepository(SimplePageType.Contacts).GetPlainContent(); }
        }
    }
}
