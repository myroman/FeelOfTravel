using System.Collections.Generic;
using System.Linq;

using FeelOfTravel.Business.Domain;
using FeelOfTravel.Business.Repositories;

using FeelOfTravel.SqlDataAccess.MappingExtensions;

namespace FeelOfTravel.SqlDataAccess.Repositories
{
    public class SqlOfferTypeRepository : SqlRepositoryBase, IOfferTypeRepository
    {
        public SqlOfferTypeRepository(string connectionString) : base(connectionString)
        {
        }

        public OfferType Read(int id)
        {
            var selectedObject = DataContext.tbOfferTypes.SingleOrDefault(l => l.id == id);
            return selectedObject != null ? selectedObject.ToDomainObject() : null;
        }

        public IEnumerable<OfferType> GetList()
        {
            return DataContext.tbOfferTypes.Select(at => at.ToDomainObject());
        }

        #region Non implemented

        public void Add(OfferType @object)
        {
            throw new System.NotImplementedException();
        }

        public void Update(OfferType @object)
        {
            throw new System.NotImplementedException();
        }

        public void Remove(OfferType @object)
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}