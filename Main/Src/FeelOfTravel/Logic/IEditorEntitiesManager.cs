namespace FeelOfTravel.Logic
{
    public interface IEditorEntitiesManager
    {
        void Add();

        void Delete(int id);

        bool AddingIsEnabled { get; }
    }
}