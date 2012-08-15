using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

using FeelOfTravel.AutofacSupport;
using FeelOfTravel.Business.Domain;
using FeelOfTravel.Business.Repositories;
using FeelOfTravel.Logic;
using FeelOfTravel.Logic.Common;

namespace FeelOfTravel.Handlers
{
    public class TinyMceEditorHandler : IHttpHandler
    {
        private const string Main = "main";
        private const string About = "About";
        private const string Contacts = "Contacts";

        private const string GetAction = "get";
        private const string SaveAction = "save";

        private CompositionRoot compositionRoot;

        public bool IsReusable
        {
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                compositionRoot = CompositionRootHelper.GetCompositionRoot(context);

                var action = context.Request["action"];

                if (!string.IsNullOrEmpty(action))
                {
                    string response = string.Empty;
                    if (action == GetAction)
                    {
                        response = GetResponse();
                    }
                    else if (action == SaveAction)
                    {
                        Save(context.Request.Params["data"]);
                    }

                    context.Response.StatusCode = 200;
                    context.Response.Clear();
                    context.Response.ContentType = "text/plain";
                    if (string.IsNullOrEmpty(response))
                    {
                        response = "\n";
                    }

                    context.Response.Write(response.ToJSON());
                }
            }
            catch (Exception exc)
            {
                context.Response.StatusCode = 400;
                context.Response.Write(exc.Message);
                throw;
            }
        }

        public string GetResponse()
        {
            var response = new
            {
                About = compositionRoot.GetSimplePageRepository(SimplePageType.About).GetPlainContent(),
                Contacts = compositionRoot.GetSimplePageRepository(SimplePageType.Contacts).GetPlainContent()
            };

            return response.ToJSON();
        }

        private void Save(string content)
        {
            var serializer = new JavaScriptSerializer();
            var contentMap = serializer.Deserialize<Dictionary<string, string>>(content);

            foreach (var key in contentMap.Keys)
            {
                ResolveSimplePageRepository(key).SaveContent(contentMap[key]);
            }
        }

        private ISimplePageRepository ResolveSimplePageRepository(string type)
        {
            var simplePageTypeMapping = new Dictionary<string, SimplePageType>
            {
                { Main, SimplePageType.Main },
                { About, SimplePageType.About },
                { Contacts, SimplePageType.Contacts }
            };

            SimplePageType pageType;
            if (simplePageTypeMapping.TryGetValue(type, out pageType))
            {
                return compositionRoot.GetSimplePageRepository(pageType);
            }

            throw new ArgumentException("Wrong type of biz object", "type");
        }
    }
}
