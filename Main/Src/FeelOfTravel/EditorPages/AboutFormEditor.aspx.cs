using System;
using System.Collections.Generic;
using System.Linq;

using FeelOfTravel.Business.Domain;

namespace FeelOfTravel.EditorPages
{
    public partial class AboutFormEditor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                AboutEditorControl.ContainerCssClass = "editor-about__text-box_about";
                AboutEditorControl.EditorContentType = SimplePageType.About;

                //ContactsEditorControl.ContainerCssClass = "editor-about__text-box_contacts";
                //ContactsEditorControl.EditorContentType = EditorContentTypes.Contacts;
            }
        }
    }
}