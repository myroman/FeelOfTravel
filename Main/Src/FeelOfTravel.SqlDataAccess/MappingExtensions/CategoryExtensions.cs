using FeelOfTravel.Business.Domain;

namespace FeelOfTravel.SqlDataAccess.MappingExtensions
{
    public static class CategoryExtensions
    {
         public static InformationCategory ToDomainObject(this tbInformationCategory from)
         {
             return new InformationCategory
             {
                 Id = from.id,
                 Name = from.name
             };
         }
    }
}