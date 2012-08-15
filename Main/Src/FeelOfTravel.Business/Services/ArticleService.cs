using System;
using System.Linq;

using FeelOfTravel.Business.Domain;
using FeelOfTravel.Business.Repositories;

namespace FeelOfTravel.Business.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IArticleRepository articleRepository;
        private readonly ITeaserRepository teaserRepository;
        private readonly IArticleTypeRepository articleTypeRepository;

        public ArticleService(
            IArticleRepository articleRepository, 
            ITeaserRepository teaserRepository,
            IArticleTypeRepository articleTypeRepository)
        {
            if (articleRepository == null)
            {
                throw new ArgumentNullException("articleRepository");
            }
            if (teaserRepository == null)
            {
                throw new ArgumentNullException("teaserRepository");
            }
            if (articleTypeRepository == null)
            {
                throw new ArgumentNullException("articleTypeRepository");
            }
            this.articleRepository = articleRepository;
            this.teaserRepository = teaserRepository;
            this.articleTypeRepository = articleTypeRepository;
        }

        #region Implementation of IArticleService
        public IArticleRepository Repository
        {
            get { return articleRepository; }
        }

        public Article[] GetArticles()
        {
            return articleRepository.GetList().ToArray();
        }

        public ArticleType[] GetArticleTypes()
        {
            return articleTypeRepository.GetList().ToArray();
        }

        public ArticleType GetArticleType(Article article)
        {
            if (article == null)
            {
                throw new ArgumentNullException("article");
            }
            if ((int)article.ArticleType > 0)
            {
                var articleType = articleTypeRepository.Read((int)article.ArticleType);
                return articleType;
            }
            return null;
        }

        public void DeleteArticle(Article articleToDelete, bool deleteRelatedTeasers)
        {
            if (articleToDelete == null)
            {
                throw new ArgumentNullException("articleToDelete");
            }
            
            if (deleteRelatedTeasers)
            {
                var teasers = teaserRepository.GetList().Where(t => t.RelatedArticleId == articleToDelete.Id);
                foreach (var teaser in teasers)
                {
                    teaserRepository.Remove(teaser);
                }
            }
            articleRepository.Remove(articleToDelete);
        }
        #endregion
    }
}