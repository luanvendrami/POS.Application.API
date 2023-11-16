using Data.Infra.Context;
using Domain.Interface.Repository.Base;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository.Base
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, new()
    {
        protected readonly DataContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public BaseRepository(DataContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public async Task Add(TEntity entity)
        {
            _dbSet.Add(entity);
            await SaveChanges();
        }

        public async Task Update(TEntity entity)
        {
            _dbSet.Update(entity);
            await SaveChanges();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }

        public async Task Remove(int id)
        {
            _dbSet.Remove(_dbSet.Find(id));
             await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}