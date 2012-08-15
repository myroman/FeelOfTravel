using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;

using FeelOfTravel.Logic;

namespace FeelOfTravel.Controls
{
    public partial class EntitiesListControl : UserControl
    {
        public object DataSource
        {
            get { return rptList.DataSource; }

            set { rptList.DataSource = value; }
        }

        public IEditorEntitiesProvider Provider { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected string GetItemText(object dataItem)
        {
            if (Provider == null)
            {
                return string.Empty;
            }

            return Provider.GetItemText(dataItem);
        }
    }
}