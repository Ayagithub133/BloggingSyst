using Microsoft.EntityFrameworkCore;
using BloggingSystem.Models;
using BloggingSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BloggingSystem.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {

        private readonly BloggingDbContext _dbContext;
        public GenericRepository(BloggingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

       

        public async Task<Response> AddEntityAsync(T entity)
        {
            try
            {
                await _dbContext.Set<T>().AddAsync(entity);
                await _dbContext.SaveChangesAsync();
                return new Response
                {
                    Message = "Done Successfully",
                    IsSuccess = true
                };
            }
            catch(Exception ex)
            {
                var m = ex.Message;
                return new Response
                {
                    Message = "Faild try again later",
                    
                };
            }
        }

        public async Task<Response> DeleteEntityAsync(string id)
        {
            try { 
            var Entity = await _dbContext.Set<T>().FindAsync(id);
             _dbContext.Set<T>().Remove(Entity);
            await _dbContext.SaveChangesAsync();
                return new Response
                {
                    Message = "Done Successfully",
                    IsSuccess = true
                };
            }
            catch
            {
                return new Response
                {
                    Message = "Faild try again later",

                };
            }
        }

        public async Task<IEnumerable<T>> GetAllEntitiesAsync()
        {
            return await _dbContext.Set<T>().ToListAsync<T>();
        }

        public async Task<T> GetEntityByConditionAsync(Expression<Func<T,bool>> predicate)
        {
            return await _dbContext.Set<T>().Where(predicate).FirstOrDefaultAsync();
        }


        public IQueryable<T> GetListByConditionAsync(Expression<Func<T, bool>> predicate)
        {
            return _dbContext.Set<T>().Where(predicate).AsQueryable();
        }

        public  IQueryable<T> GetTable()
        {
            return  _dbContext.Set<T>();
        }

        public async Task<Response> UpdateEntityAsync(T entity)
        {
            try { 
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
                return new Response
                {
                    Message = "Done Successfully",
                    IsSuccess = true
                };
            }
            catch
            {
                return new Response
                {
                    Message = "Faild try again later",

                };
            }

        }

       
        Task<IQueryable<T>> IGenericRepository<T>.GetListByConditionAsync(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
