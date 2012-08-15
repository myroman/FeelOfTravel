using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;

namespace FeelOfTravel.Controls
{
    public partial class HorizontalMenuControl : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataBind();
        }

        protected bool CurrentUserIsEditor
        {
            get
            {
                var belongs = Context.User.IsInRole("Editors");
                return belongs;
            }
        }
    }
}