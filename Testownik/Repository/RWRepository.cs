using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testownik.Model;
using Testownik.Repository.Interface;

namespace Testownik.Repository
{
    public class RWRepository<T> : IRWRepository<T> where T : Entity
    {
        private readonly TestownikContext context;

        public RWRepository(TestownikContext context)
        {
            this.context = context;
        }

        public List<T> GetAll()
        {
            return context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return context.Set<T>().Where(x => x.Ref == id).FirstOrDefault();
        }
        public void Create(T entity)
        {
            context.Set<T>().Add(entity);
            context.SaveChanges();
        }

        public void Delete(T entity)
        {
            context.Set<T>().Remove(entity);
            context.SaveChanges();
        }

        public void Edit(T entity)
        {
            context.Entry<T>(entity).CurrentValues.SetValues(entity);
            context.SaveChanges();
        }
    }
}
