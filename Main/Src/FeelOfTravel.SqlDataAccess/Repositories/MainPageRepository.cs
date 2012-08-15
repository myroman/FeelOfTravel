using System.Linq;

using FeelOfTravel.Business.Repositories;
using FeelOfTravel.Business.Utils;

namespace FeelOfTravel.SqlDataAccess.Repositories
{
    public class MainPageRepository : SqlRepositoryBase, ISimplePageRepository
    {
        public MainPageRepository(string connectionString) : base(connectionString)
        {
        }

        public void SaveContent(string plainText)
        {
            var pageEntry = new tbMainPage
            {
                entryId = GetNewId(),
                text = HtmlCoder.Encode(plainText)
            };

            DataContext.tbMainPages.DeleteAllOnSubmit(DataContext.tbMainPages);
            DataContext.tbMainPages.InsertOnSubmit(pageEntry);
            DataContext.SubmitChanges();
        }

        private static int GetNewId()
        {
            var table = DataContext.tbMainPages;
            var id = table.Select(entry => entry.entryId).FirstOrDefault();
            return id != 0 ? id : 1;
        }

        public string GetPlainContent()
        {
            var text = DataContext.tbMainPages
                .Select(entry => entry.text)
                .FirstOrDefault();
            return text ?? string.Empty;
        }
    }
}