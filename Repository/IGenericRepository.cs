using BloggingSystem.Models;
using BloggingSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BloggingSystem.Repository
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        public Task<Response> AddEntityAsync(T entity);
        public Task<Response> DeleteEntityAsync(string id);
        public Task<Response> UpdateEntityAsync(T entity);
        public Task<T> GetEntityByConditionAsync(Expression<Func<T, bool>> predicate);
        public Task<IEnumerable<T>> GetAllEntitiesAsync();
        public Task<IQueryable<T>> GetListByConditionAsync(Expression<Func<T,bool>> predicate);
        public IQueryable<T> GetTable();
     
       
    }
}
