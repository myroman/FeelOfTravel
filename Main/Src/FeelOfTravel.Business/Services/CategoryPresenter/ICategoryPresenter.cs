using FeelOfTravel.Business.Domain;

namespace FeelOfTravel.Business.Services.CategoryPresenter
{
    public interface ICategoryPresenter
    {
        CategoryData[] GetCategories(CoreArticleData articleData);
    }
}