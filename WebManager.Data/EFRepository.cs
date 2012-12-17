using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using WebManager.Data.Contracts;
using System.Data.Entity;

namespace WebManager.Data
{
    /// <summary>
    /// Generic repository class
    /// </summary>
    /// <typeparam name="T">Type to which the repository is associated</typeparam>
    public class EFRepository<T> : IRepository<T> where T : class, IEntity
    {
        protected DbContext DbContext { get; set; }
        protected DbSet<T> DbSet { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbContext"></param>
        public EFRepository(DbContext dbContext)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException("Passed DbContext is null");
            }
            else
            {
                DbContext = dbContext;
                DbSet = DbContext.Set<T>();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IQueryable<T> GetAll()
        {
            return DbSet;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public IQueryable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T GetById(int id)
        {
            return this.DbSet.Where(t => t.Id == id).Single();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newEntity"></param>
        public void Add(T newEntity)
        {
            this.DbSet.Add(newEntity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        public void Remove(T entity)
        {
            this.DbSet.Remove(entity);
        }
    }
}
