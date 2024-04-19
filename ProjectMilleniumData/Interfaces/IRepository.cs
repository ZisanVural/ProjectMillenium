using ProjectMillenium.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMillenium.Data.Interfaces
{
    public interface IRepository<T> where T : class
    {
        void Create(T Entity);
        void Delete(T Entity);
        void Edit(T Entity);
        T GetById(int id);
        List<T> GetAll();
    }

}
