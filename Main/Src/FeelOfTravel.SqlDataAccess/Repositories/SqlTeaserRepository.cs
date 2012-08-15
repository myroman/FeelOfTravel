using System;
using System.Collections.Generic;
using System.Linq;

using FeelOfTravel.Business.Domain;
using FeelOfTravel.Business.Repositories;
using FeelOfTravel.SqlDataAccess.MappingExtensions;

namespace FeelOfTravel.SqlDataAccess.Repositories
{
    public class SqlTeaserRepository : SqlRepositoryBase, ITeaserRepository
    {
        public SqlTeaserRepository(string connectionString) : base(connectionString)
        {
        }

        public void Add(Teaser @object)
        {
            if (@object == null)
            {
                // ReSharper disable NotResolvedInText
                throw new ArgumentNullException("teaser");
                // ReSharper restore NotResolvedInText
            }

            @object.Id = 0;

            Update(@object);
        }

        public Teaser Read(int id)
        {
            if (id <= 0)
            {
                throw new DomainException("Нет тизера с id = " + id);
            }

            var relTeaser = DataContext.tbTeasers.SingleOrDefault(l => l.teaserId == id);
            return relTeaser.ToDomainObject();
        }

        public void Update(Teaser @object)
        {
            if (@object == null)
            {
                // ReSharper disable NotResolvedInText
                throw new ArgumentNullException("teaser");
                // ReSharper restore NotResolvedInText
            }

            if (@object.Id == 0)
            {
                var check = @object.Validate();
                if (!string.IsNullOrEmpty(check))
                {
                    throw new DomainException(check);
                }

                var relTeaser = new tbTeaser();
                @object.FillDbObject(relTeaser);

                DataContext.tbTeasers.InsertOnSubmit(relTeaser);
                DataContext.SubmitChanges();

                @object.Id = relTeaser.teaserId;
            }
            else if (@object.Id > 0)
            {
                var relTeaser = DataContext.tbTeasers.SingleOrDefault(l => l.teaserId == @object.Id);
                if (relTeaser != null)
                {
                    @object.FillDbObject(relTeaser);
                    DataContext.SubmitChanges();
                }
                else
                {
                    throw new DomainException("Нельзя удалить тизер с id = " + @object.Id);
                }
            }
        }

        public void Remove(Teaser @object)
        {
            if (@object.Id > 0)
            {
                var teaserInDb = DataContext.tbTeasers.SingleOrDefault(teaser => teaser.teaserId == @object.Id);
                if (teaserInDb != null)
                {
                    DataContext.tbTeasers.DeleteOnSubmit(teaserInDb);
                    DataContext.SubmitChanges();
                }
            }
        }

        public IEnumerable<Teaser> GetList()
        {
            return DataContext.tbTeasers.Select(t => t.ToDomainObject());
        }
    }

}