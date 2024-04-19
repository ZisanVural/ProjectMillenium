using Microsoft.EntityFrameworkCore;
using ProjectMillenium.Core.Entity;
using ProjectMillenium.Data.Context;
using ProjectMillenium.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMillenium.Data.Implements
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Create(T Entity)
        {
            _context.Set<T>().Add(Entity);
            _context.SaveChanges();
        }

        public void Delete(T Entity)
        {
            _context.Set<T>().Remove(Entity);
            _context.SaveChanges();
        }

        public void Edit(T Entity)
        {
            _context.Set<T>().Update(Entity);
            _context.SaveChanges();
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().AsNoTracking().ToList<T>();

        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);

        }

    }

}

