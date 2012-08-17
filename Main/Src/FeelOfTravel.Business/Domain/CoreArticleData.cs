using System;

namespace FeelOfTravel.Business.Domain
{
    public class CoreArticleData : BusinessObjectBase
    {
        public InformationCategories Category { get; set; }

        public string Header { get; set; }
        
        public string TextBody { get; set; }

        public DateTime PublishDate { get; set; }

        public string ImageUrl { get; set; }

        public virtual string Validate()
        {
            return string.Empty;
        }
    }
}