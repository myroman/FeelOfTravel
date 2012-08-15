using System;
using System.Web.UI;

using FeelOfTravel.Logic;

namespace FeelOfTravel.Controls
{
    public partial class EditorEntitiesManagementControl : System.Web.UI.UserControl
    {
        public IEditorEntitiesManager Manager { get; set; }

        public object DataSource
        {
            get { return entitiesList.DataSource; }

            set { entitiesList.DataSource = value; }
        }

        public void Initialize(IEditorEntitiesProvider provider, IEditorEntitiesManager manager)
        {
            if (entitiesList != null)
            {
                entitiesList.Provider = provider;
            }

            Manager = manager;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                const string editorEntitiesControl = "EditorEntitiesControl";

                ClientScriptManager scriptManager = Page.ClientScript;
                if (!scriptManager.IsClientScriptIncludeRegistered(GetType(), editorEntitiesControl))
                {
                    scriptManager.RegisterClientScriptInclude(GetType(), editorEntitiesControl,
                        ResolveClientUrl(@"~/Scripts/Utils.js"));
                }

                DataBind();
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (Manager != null)
            {
                Manager.Add();
            }
        }

        protected bool AddingIsEnabled
        {
            get
            {
                if (Manager == null)
                {
                    return false;
                }

                return Manager.AddingIsEnabled;
            }
        }
    }
}