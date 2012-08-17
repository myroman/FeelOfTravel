using System;
using System.Collections.Generic;
using System.Linq;

using FeelOfTravel.Business.Domain;
using FeelOfTravel.Business.Repositories;
using FeelOfTravel.SqlDataAccess.MappingExtensions;

namespace FeelOfTravel.SqlDataAccess.Repositories
{
    public class SqlOfferRepository : SqlRepositoryBase, IOfferRepository
    {
        #region Implementation of IRepository<Offer>
        public SqlOfferRepository(string connectionString) : base(connectionString)
        {
        }

        public void Add(Offer @object)
        {
            if (@object == null)
            {
                // ReSharper disable NotResolvedInText
                throw new ArgumentNullException("offer");
                // ReSharper restore NotResolvedInText
            }

            @object.Id = 0;

            Update(@object);
        }

        public Offer Read(int id)
        {
            var offer = DataContext.tbOffers.SingleOrDefault(l => l.id == id);
            if (offer == null)
            {
                return null;
            }
            return offer.ToDomainObject();
        }

        public void Update(Offer @object)
        {
            if (@object == null)
            {
                // ReSharper disable NotResolvedInText
                throw new ArgumentNullException("offer");
                // ReSharper restore NotResolvedInText
            }

            if (@object.Id == 0)
            {
                @object.PublishDate = DateTime.Now;

                var check = @object.Validate();
                if (!string.IsNullOrEmpty(check))
                {
                    throw new DomainException(check);
                }

                var offerDb = new tbOffer();
                @object.FillDbObject(offerDb);

                DataContext.tbCoreArticleDatas.InsertOnSubmit(offerDb.tbCoreArticleData);
                DataContext.tbOffers.InsertOnSubmit(offerDb);
                DataContext.SubmitChanges();

                @object.Id = offerDb.id;
            }
            else if (@object.Id > 0)
            {
                var offerDb = DataContext.tbOffers.SingleOrDefault(l => l.id == @object.Id);
                if (offerDb != null)
                {
                    @object.FillDbObject(offerDb);
                    DataContext.SubmitChanges();
                }
                else
                {
                    throw new DomainException("Нельзя удалить статью с id = " + @object.Id);
                }
            }
        }

        public void Remove(Offer @object)
        {
            var offer = DataContext.tbOffers.SingleOrDefault(art => art.id == @object.Id);
            if (offer == null)
            {
                return;
            }
            var coreArticle = DataContext.tbCoreArticleDatas.SingleOrDefault(i => i.id == offer.coreArticleDataId);
            if (coreArticle != null)
            {
                DataContext.tbCoreArticleDatas.DeleteOnSubmit(coreArticle);
            }
            DataContext.tbOffers.DeleteOnSubmit(offer);

            DataContext.SubmitChanges();
        }

        public IEnumerable<Offer> GetList()
        {
            return DataContext.tbOffers.Select(a => a.ToDomainObject());
        }
        #endregion
    }
}