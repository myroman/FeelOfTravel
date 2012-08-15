namespace FeelOfTravel.Logic
{
    public interface IEditorEntitiesProvider
    {
        string GetItemText(object dataItem);

        EntitiesTransferObject EntitiesTransferObject { get; }
    }
}