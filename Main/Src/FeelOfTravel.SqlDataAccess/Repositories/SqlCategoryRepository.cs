using System.Collections.Generic;
using System.Linq;

using FeelOfTravel.Business.Domain;
using FeelOfTravel.Business.Repositories;
using FeelOfTravel.SqlDataAccess.MappingExtensions;

namespace FeelOfTravel.SqlDataAccess.Repositories
{
    public class SqlCategoryRepository : SqlRepositoryBase, ICategoryRepository
    {
        public SqlCategoryRepository(string connectionString) : base(connectionString)
        {
        }

        public void Add(InformationCategory @object)
        {
            throw new System.NotImplementedException();
        }

        public InformationCategory Read(int id)
        {
            var category = DataContext.tbInformationCategories.SingleOrDefault(cat => cat.id == id);
            return category != null ? category.ToDomainObject() : null;
        }

        public void Update(InformationCategory @object)
        {
            throw new System.NotImplementedException();
        }

        public void Remove(InformationCategory @object)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<InformationCategory> GetList()
        {
            throw new System.NotImplementedException();
        }
    }
}