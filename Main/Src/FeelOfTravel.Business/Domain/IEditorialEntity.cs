namespace FeelOfTravel.Business.Domain
{
    public interface IEditorialEntity
    {
        string EntityName { get; }

        IEditorialEntity[] GetList();
    }
}
