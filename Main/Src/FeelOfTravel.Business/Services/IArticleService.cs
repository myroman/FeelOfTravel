using FeelOfTravel.Business.Domain;
using FeelOfTravel.Business.Repositories;

namespace FeelOfTravel.Business.Services
{
    public interface IArticleService
    {
        IArticleRepository Repository { get; }

        Article[] GetArticles();
        
        ArticleType[] GetArticleTypes();
        
        ArticleType GetArticleType(Article article);
        
        void DeleteArticle(Article articleToDelete, bool deleteRelatedTeasers);
    }
}