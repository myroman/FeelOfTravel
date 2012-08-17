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
            
        }

        private static int GetNewId()
        {
            return 0;
        }

        public string GetPlainContent()
        {
            return null;
        }
    }
}