using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;

using FeelOfTravel.Business.Domain;
using FeelOfTravel.Business.Repositories;
using FeelOfTravel.SqlDataAccess.MappingExtensions;

namespace FeelOfTravel.SqlDataAccess.Repositories
{
    public class SqlArticleRepository : SqlRepositoryBase, IArticleRepository
    {
        #region Implementation of IRepository<Article>
        public SqlArticleRepository(string connectionString) : base(connectionString)
        {
        }

        public void Add(Article @object)
        {
            if (@object == null)
            {
                // ReSharper disable NotResolvedInText
                throw new ArgumentNullException("article");
                // ReSharper restore NotResolvedInText
            }

            @object.Id = 0;

            Update(@object);
        }

        public Article Read(int id)
        {
            if (id <= 0)
            {
                throw new DomainException("Нет статьи с id = " + id);
            }

            var relArticle = DataContext.tbArticles.SingleOrDefault(l => l.articleId == id);
            return relArticle != null ? relArticle.ToDomainObject() : null;
        }

        public void Update(Article @object)
        {
            if (@object == null)
            {
                // ReSharper disable NotResolvedInText
                throw new ArgumentNullException("article");
                // ReSharper restore NotResolvedInText
            }

            if (@object.Id == 0)
            {
                var check = @object.Validate();
                if (!string.IsNullOrEmpty(check))
                {
                    throw new DomainException(check);
                }

                var relArticle = new tbArticle();
                @object.FillDbObject(relArticle);

                DataContext.tbArticles.InsertOnSubmit(relArticle);
                DataContext.SubmitChanges();

                @object.Id = relArticle.articleId;
            }
            else if (@object.Id > 0)
            {
                var relArticle = DataContext.tbArticles.SingleOrDefault(l => l.articleId == @object.Id);
                if (relArticle != null)
                {
                    @object.FillDbObject(relArticle);
                    DataContext.SubmitChanges();
                }
                else
                {
                    throw new DomainException("Нельзя удалить статью с id = " + @object.Id);
                }
            }
        }

        public void Remove(Article @object)
        {
            var article = DataContext.tbArticles.SingleOrDefault(art => art.articleId == @object.Id);
            if (article == null)
            {
                return;
            }
            if (article.tbTeasers.AsEnumerable().Any())
            {
                throw new DomainException("Нельзя удалить статью, так как для нее существуют тизеры.");
            }

            DataContext.tbArticles.DeleteOnSubmit(article);
            DataContext.SubmitChanges();
        }

        public IEnumerable<Article> GetList()
        {
            return DataContext.tbArticles.Select(a => a.ToDomainObject());
        }
        #endregion
    }
}