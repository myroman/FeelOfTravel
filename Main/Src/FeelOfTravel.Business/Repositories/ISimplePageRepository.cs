namespace FeelOfTravel.Business.Repositories
{
    public interface ISimplePageRepository
    {
        void SaveContent(string plainText);

        string GetPlainContent();
    }
}