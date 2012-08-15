// -----------------------------------------------------------------------
// <copyright file="XDocumentPreserver.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace FeelOfTravelTests.Utils
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml.Linq;

    /// <summary>
    /// Allows to keep opened document in unchanged state by means of "using" pattern.
    /// </summary>
    public class XDocumentPreserver : IDisposable
    {
        private XDocument document;

        private string fileName;

        public XDocumentPreserver(string fileName)
        {
            this.fileName = fileName;
            document = XDocument.Load(fileName);
        }

        public void Dispose()
        {
            document.Save(this.fileName);
        }
    }
}
