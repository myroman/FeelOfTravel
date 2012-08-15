using System;
using System.Collections.Generic;
using System.Linq;

using FeelOfTravel.Business;
using FeelOfTravel.Business.Domain;
using FeelOfTravel.Business.Repositories;
using FeelOfTravel.Logic;

namespace FeelOfTravel.Controls
{
    public partial class TinyMceEditorControl : System.Web.UI.UserControl
    {
        public string ContainerCssClass { get; set; }
        
        protected string TextAreaCssClass
        {
            get { return ContainerCssClass + "_content"; }
        }

        protected string StatusCssClass
        {
            get { return ContainerCssClass + "_status"; }
        }

        public ISimplePageRepository SimplePage
        {
            get { return RestoreSimplePage(); }
        }

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

        public SimplePageType EditorContentType
        {
            get { return (SimplePageType)ViewState["SimplePageType"]; }
            set { ViewState["SimplePageType"] = value; }
        }

        protected string BizObjTypeName
        {
            get
            {
                switch (EditorContentType)
                {
                    case SimplePageType.Main:
                        return "main";
                    case SimplePageType.About:
                        return "about";
                    default:
                        return string.Empty;
                }
            }
        }
    }
}