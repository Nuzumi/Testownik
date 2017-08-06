using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testownik.Model;

namespace Testownik.Repository.Interface
{
    public interface IRWRepository<T> where T : Entity
    {
        List<T> GetAll();
        T GetById(int id);
        void Create(T entity);
        void Delete(T entity);
        void Edit(T entity);
    }
}
