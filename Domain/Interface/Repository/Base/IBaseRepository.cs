using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface.Repository.Base
{
    public interface IBaseRepository<TEntity> : IDisposable where TEntity : class, new()
    {
        Task Add(TEntity entity);
        Task Update(TEntity entity);
        Task Remove(int id);
        Task<int> SaveChanges();
    }
}
