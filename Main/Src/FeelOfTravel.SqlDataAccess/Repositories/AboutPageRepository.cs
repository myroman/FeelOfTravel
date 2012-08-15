using System.Linq;

using FeelOfTravel.Business.Repositories;
using FeelOfTravel.Business.Utils;

namespace FeelOfTravel.SqlDataAccess.Repositories
{
    public class AboutPageRepository : SqlRepositoryBase, ISimplePageRepository
    {
        public AboutPageRepository(string connectionString) : base(connectionString)
        {
        }

        public void SaveContent(string plainText)
        {
            var pageEntry = new tbAboutPage
            {
                entryId = GetNewId(),
                text = HtmlCoder.Encode(plainText)
            };

            DataContext.tbAboutPages.DeleteAllOnSubmit(DataContext.tbAboutPages);
            DataContext.tbAboutPages.InsertOnSubmit(pageEntry);
            DataContext.SubmitChanges();
        }

        private static int GetNewId()
        {
            var table = DataContext.tbAboutPages;
            var id = table.Select(entry => entry.entryId).FirstOrDefault();
            return id != 0 ? id : 1;
        }

        public string GetPlainContent()
        {
            var text = DataContext.tbAboutPages
                .Select(entry => entry.text)
                .FirstOrDefault();
            return text ?? string.Empty;
        }
    }
}