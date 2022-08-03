using Domain_Layer.Data;
using Domain_Layer.Models;
using Microsoft.EntityFrameworkCore;
using Repository_Layer.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Layer.Repository
{
    public class Repository <T>:IRepository<T> where T :BaseEntity
    {
        #region property
        private readonly ApplicationDbContext _dbContext;
        private DbSet<T> _entity;
        #endregion
        #region constructure
        public Repository(ApplicationDbContext dbContext)
        { 
        this._dbContext = dbContext;
        this._entity = _dbContext.Set<T>();
        }
        #endregion
        public IEnumerable<T> GetAll()
        {
            return _entity.AsEnumerable();
        }

        public T Get(int id)
        {
            return _entity.SingleOrDefault(s => s.Id == id);
        }

        public void Insert(T entity)
        {
            if (entity==null)
            {
                throw new ArgumentNullException("entity");
            }
            _entity.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Update(T entity)
        {
            if (entity==null)
            {
                throw new ArgumentNullException("entity");
            }
            _entity.Update(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            if (entity==null)
            {
                throw new ArgumentNullException("entity");
            }
            _entity.Remove(entity);
            _dbContext.SaveChanges();
        }

        public void Remove(T entity)
        {
            if (entity==null)
            {
                throw new ArgumentNullException("entity");
            }
            this._entity.Remove(entity);    
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
        
    }
}
