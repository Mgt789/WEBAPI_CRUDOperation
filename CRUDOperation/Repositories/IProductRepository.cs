using System.Collections.Generic;
using CRUDOperation.Model;

namespace CRUDOperation.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Production> GetAll();
        Production GetById(int id);
        void Add(Production product);
        //void Update(Production product);
        //void Delete(int id);
    }
}
