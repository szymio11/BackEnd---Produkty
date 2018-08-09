﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AplikacjaKulinarna.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Produkty.Data.DbModels;

namespace Produkty.Repository.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly DataContext _context;
        private readonly DbSet<T> _entities;

        public Repository(DataContext context)
        {
            _context = context;
            _entities = _context.Set<T>();
        }

        public virtual IQueryable<T> GetAll()
        {
            return _entities;
        }
        public virtual async Task<bool> ExistAsync(Expression<Func<T, bool>> match)
        {
            return await _context.Set<T>().AnyAsync(match);
        }

        public virtual async Task<ICollection<T>> GetAllAsyn()
        {

            return await _entities.ToListAsync();
        }


        public virtual async Task<T> GetAsync(Guid id)
        {
            return await _entities.FindAsync(id);
        }


        public virtual async Task<T> AddAsyn(T t)
        {
            _entities.Add(t);
            await _context.SaveChangesAsync();
            return t;

        }

        public virtual async Task<T> FindAsync(Expression<Func<T, bool>> match)
        {
            return await _entities.SingleOrDefaultAsync(match);
        }


        public async Task<ICollection<T>> FindAllAsync(Expression<Func<T, bool>> match)
        {
            return await _entities.Where(match).ToListAsync();
        }

        public virtual async Task<int> DeleteAsyn(T entity)
        {
            _entities.Remove(entity);
            return await _context.SaveChangesAsync();
        }


        public virtual async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public virtual IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = _entities.Where(predicate);
            return query;
        }

        public virtual async Task<ICollection<T>> FindByAsyn(Expression<Func<T, bool>> predicate)
        {
            return await _entities.Where(predicate).ToListAsync();
        }
        public virtual async Task<T> FindByAsyn(Expression<Func<T, bool>> predicate, Expression<Func<T, bool>> single)
        {
            return await _entities.Where(predicate).SingleOrDefaultAsync(single);
        }

        public IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {

            IQueryable<T> queryable = GetAll();
            foreach (Expression<Func<T, object>> includeProperty in includeProperties)
            {

                queryable = queryable.Include<T, object>(includeProperty);
            }

            return queryable;
        }

    }
}