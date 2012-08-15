using System;
using System.Collections.Generic;
using System.Linq;

namespace FeelOfTravel
{
    using AjaxControlToolkit;

    public partial class TestPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           if(!IsPostBack)
           {
               ;
           }
        }

        protected string TextFromTextBox
        {
            get { return ViewState["text"] != null ? (string) ViewState["text"] : null; }
            set { ViewState["text"] = value; }
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
        }

        protected void btnChange_Click(object sender, EventArgs e)
        {
            //litText.Text = txtNewText.Text;
        }

    }
}