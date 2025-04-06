using Demo.DataAccess.Data.DbContexts;
using Demo.DataAccess.Models.DepartmentModel;
using Demo.DataAccess.Models.Shared;
using Demo.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAccess.Repositories.Classes
{
    public class GenericRepository<TEntity>(ApplicationDbContext _dbContext) : IGenetricRepository<TEntity> where TEntity : BaseEntity
    {
        public IEnumerable<TEntity> GetAll(bool withTracking = false)
        {
            if (withTracking)
                return _dbContext.Set<TEntity>().Where(e => e.IsDeleted != true).ToList();
            else
                return _dbContext.Set<TEntity>().Where(e => e.IsDeleted != true).AsNoTracking().ToList();
        }
        //Get By Id
        public TEntity? GetById(int id)
        {
            return _dbContext.Set<TEntity>().Find(id);
        }
        //Update
        public int Update(TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);//update locally
            return _dbContext.SaveChanges();
        }
        //Delete
        public int Remove(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
            return _dbContext.SaveChanges();
        }
        //Insert
        public int Add(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
            return _dbContext.SaveChanges();
        }

        public IEnumerable<TResult> GetAll<TResult>(Expression<Func<TEntity, TResult>> selector)
        {
            return _dbContext.Set<TEntity>().Where(e =>e.IsDeleted != true)
                                            .Select(selector).ToList();
        }
    }
}
