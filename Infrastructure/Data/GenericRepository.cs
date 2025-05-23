﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class GenericRepository<T>(StoreContext storeContext) : IGenericRepository<T> where T : BaseEntity
    {
        public void Add(T entity)
        {
            storeContext.Set<T>().Add(entity);
        }

        public void Remove(T entity)
        {
            storeContext.Set<T>().Remove(entity);
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await storeContext.Set<T>().FindAsync(id);
        }
        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await storeContext.Set<T>().ToListAsync();
        }
        public void Update(T entity)
        {
            storeContext.Set<T>().Attach(entity);
            storeContext.Entry(entity).State = EntityState.Modified;
        }
        public bool Exists(int id)
        {
            return storeContext.Set<T>().Any(e => e.Id == id);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return await storeContext.SaveChangesAsync() > 0;
        }


        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(storeContext.Set<T>().AsQueryable(), spec);
        }

        private IQueryable<TResult> ApplySpecification<TResult>(ISpecification<T,TResult> spec)
        {
            return SpecificationEvaluator<T>.GetQuery<T,TResult>(storeContext.Set<T>().AsQueryable(), spec);
        }

        public async Task<T?> GetEntityWithSpec(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }

        public async Task<TResult?> GetEntityWithSpec<TResult>(ISpecification<T, TResult> spec)
        {
            return await ApplySpecification(spec).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<TResult>> ListAsync<TResult>(ISpecification<T, TResult> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }
    }

}
