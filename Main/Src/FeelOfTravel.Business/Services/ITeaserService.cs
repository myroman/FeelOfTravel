using FeelOfTravel.Business.Domain;
using FeelOfTravel.Business.Repositories;

namespace FeelOfTravel.Business.Services
{
    public interface ITeaserService
    {
        Teaser[] GetTeasers();
        
        Teaser[] GetTeasers(ArticleTypes relatedArticleType);
        
        ITeaserRepository Repository { get; }
        
        Article GetLinkedArticle(Teaser teaser);
    }
}