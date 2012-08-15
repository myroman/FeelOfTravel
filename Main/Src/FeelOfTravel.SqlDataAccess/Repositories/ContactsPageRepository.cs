using System.Linq;

using FeelOfTravel.Business.Repositories;
using FeelOfTravel.Business.Utils;

namespace FeelOfTravel.SqlDataAccess.Repositories
{
    public class ContactsPageRepository : SqlRepositoryBase, ISimplePageRepository
    {
        public ContactsPageRepository(string connectionString) : base(connectionString)
        {
        }

        public void SaveContent(string plainText)
        {
            var pageEntry = new tbContactsPage
            {
                entryId = GetNewId(),
                text = HtmlCoder.Encode(plainText)
            };

            DataContext.tbContactsPages.DeleteAllOnSubmit(DataContext.tbContactsPages);
            DataContext.tbContactsPages.InsertOnSubmit(pageEntry);
            DataContext.SubmitChanges();
        }

        private static int GetNewId()
        {
            var table = DataContext.tbContactsPages;
            var id = table.Select(entry => entry.entryId).FirstOrDefault();
            return id != 0 ? id : 1;
        }

        public string GetPlainContent()
        {
            var text = DataContext.tbContactsPages
                .Select(entry => entry.text)
                .FirstOrDefault();
            return text ?? string.Empty;
        }
    }
}