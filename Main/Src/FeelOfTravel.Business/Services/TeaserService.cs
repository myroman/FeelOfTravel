using System;
using System.Linq;

using FeelOfTravel.Business.Domain;
using FeelOfTravel.Business.Repositories;

namespace FeelOfTravel.Business.Services
{
    public class TeaserService : ITeaserService
    {
        private readonly ITeaserRepository teaserRepository;
        private readonly IArticleRepository articleRepository;

        public TeaserService(ITeaserRepository teaserRepository, IArticleRepository articleRepository)
        {
            if (teaserRepository == null)
            {
                throw new ArgumentNullException("teaserRepository");
            }
            if (articleRepository == null)
            {
                throw new ArgumentNullException("articleRepository");
            }
            this.teaserRepository = teaserRepository;
            this.articleRepository = articleRepository;
        }

        public Teaser[] GetTeasers()
        {
            var teasers = teaserRepository.GetList().ToArray();
            return teasers;
        }

        public Teaser[] GetTeasers(ArticleTypes relatedArticleType)
        {
            var teasers = teaserRepository.GetList()
                .Where(teaser =>
                       {
                           var article = GetLinkedArticle(teaser);
                           return article != null && article.ArticleType == relatedArticleType;
                       })
                .ToArray();
            return teasers;
        }

        public ITeaserRepository Repository
        {
            get { return teaserRepository; }
        }

        public Article GetLinkedArticle(Teaser teaser)
        {
            if (teaser == null)
            {
                throw new ArgumentNullException("teaser");
            }
            if (teaser.RelatedArticleId == 0)
            {
                return null;
            }
            var article = articleRepository.Read(teaser.RelatedArticleId);
            return article;
        }
    }
}