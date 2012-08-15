using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;

using AjaxControlToolkit;

using FeelOfTravel.Business;
using FeelOfTravel.Business.Domain;
using FeelOfTravel.Business.Repositories;
using FeelOfTravel.Logic;
using FeelOfTravel.Model.Utils;

namespace FeelOfTravel.Controls
{
    public partial class ContentEditorControl : UserControl
    {
        private ISimplePageRepository bizObject;
        private Dictionary<string, string> usedScripts;

        public SimplePageType EditorContentType
        {
            get { return (SimplePageType)ViewState["SimplePageType"]; }
            set { ViewState["SimplePageType"] = value; }
        }

        public ISimplePageRepository PageBizObject
        {
            get { return bizObject ?? RestoreSimplePage(); }
            set { bizObject = value; }
        }

        public Dictionary<string, string> UsedScripts
        {
            get
            {
                if (usedScripts == null)
                {
                    usedScripts = new Dictionary<string, string>
                    {
                        { "bold", ScriptGenerator.InsertBoldTag(txtContent.ClientID) }, 
                        { "italics", ScriptGenerator.InsertItalicsTag(txtContent.ClientID) },
                        { "returnCaret", ScriptGenerator.InsertReturnCaretTag(txtContent.ClientID) },
                        {"enableSaveButton", ScriptGenerator.EnableSaveButton(btnSave.ClientID, "enableButton")}
                    };
                }

                return usedScripts;
            }
        }

        public string ControlCssClass { get; set; }

        private ISimplePageRepository RestoreSimplePage()
        {
            try
            {
                return CompositionRootHelper.GetCompositionRoot(Context).GetSimplePageRepository(EditorContentType);
            }
            catch (Exception)
            {
                return null;
            }
        }

        private void RefreshContent()
        {
            txtContent.Text = PageBizObject.GetPlainContent();
        }

        private void RegisterControlScript()
        {
            const string BASE_NAME = "ContentEditorControl";

            ClientScriptManager clientScriptManager = Page.ClientScript;
            if (!clientScriptManager.IsClientScriptIncludeRegistered(GetType(), BASE_NAME))
            {
                clientScriptManager.RegisterClientScriptInclude(
                    GetType(), 
                    BASE_NAME,
                    ResolveClientUrl(@"~/Scripts/Utils.js"));
                clientScriptManager.RegisterClientScriptInclude(GetType(), BASE_NAME, "//ajax.googleapis.com/ajax/libs/jquery/1.5.2/jquery.min.js");
            }

            foreach (var script in UsedScripts)
            {
                if (!clientScriptManager.IsClientScriptBlockRegistered(script.Key))
                {
                    clientScriptManager.RegisterClientScriptBlock(GetType(), script.Key, script.Value);
                }
            }
        }

        protected string GetUploadCompleteCallbackName()
        {
            return "uploadCompleteFunc_" + this.ClientID;
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RefreshContent();

                afuImageUpload.OnClientUploadComplete = GetUploadCompleteCallbackName();
            }

            RegisterControlScript();
        }

        protected void AfuImageUpload_OnUploadedComplete(object sender, AsyncFileUploadEventArgs ea)
        {
            if (ea.State == AsyncFileUploadState.Success)
            {
                string filename = System.IO.Path.GetFileName(afuImageUpload.FileName);
                var path = Server.MapPath("~/UploadedImages/") + filename;
                afuImageUpload.SaveAs(path);
            }
        }

        protected void BtnSaveClick(object sender, EventArgs e)
        {
            PageBizObject.SaveContent(txtContent.Text);
            RefreshContent();
        }
    }
}