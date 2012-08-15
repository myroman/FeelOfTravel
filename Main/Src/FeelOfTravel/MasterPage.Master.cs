using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FeelOfTravel
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataBind();
        }

        protected bool CurrentUserIsNotVisitor
        {
            get { return HttpContext.Current.User.IsInRole("Editors"); }
        }
    }
}