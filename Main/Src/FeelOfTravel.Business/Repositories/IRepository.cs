using System.Collections.Generic;

namespace FeelOfTravel.Business.Repositories
{
    public interface IRepository<TObject>
    {
        void Add(TObject @object);

        TObject Read(int id);
        
        void Update(TObject @object);

        void Remove(TObject @object);

        IEnumerable<TObject> GetList();
    }
}