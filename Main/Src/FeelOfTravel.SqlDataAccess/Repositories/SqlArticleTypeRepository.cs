using System.Collections.Generic;
using System.Linq;

using FeelOfTravel.Business.Domain;
using FeelOfTravel.Business.Repositories;

using FeelOfTravel.SqlDataAccess.MappingExtensions;

namespace FeelOfTravel.SqlDataAccess.Repositories
{
    public class SqlArticleTypeRepository : SqlRepositoryBase, IArticleTypeRepository
    {
        public SqlArticleTypeRepository(string connectionString) : base(connectionString)
        {
        }

        public ArticleType Read(int id)
        {
            if (id <= 0)
            {
                throw new DomainException("Нет типа статьи с id = " + id);
            }

            var selectedObject = DataContext.tbArticleTypes.SingleOrDefault(l => l.articleTypeId == id);
            return selectedObject != null ? selectedObject.ToDomainObject() : null;
        }

        public IEnumerable<ArticleType> GetList()
        {
            return DataContext.tbArticleTypes.Select(at => at.ToDomainObject());
        }

        #region Non implemented

        public void Add(ArticleType @object)
        {
            throw new System.NotImplementedException();
        }

        public void Update(ArticleType @object)
        {
            throw new System.NotImplementedException();
        }

        public void Remove(ArticleType @object)
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}