using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    public interface IRepository
    {
        Task<List<TEntity>> GetAll<TEntity>() where TEntity : class;
        Task<TEntity> Create<TEntity>(TEntity entity) where TEntity : class;
        Task Update<TEntity>(TEntity entity) where TEntity : class;
        Task Delete<TEntity>(TEntity entity) where TEntity : class;
        Task GetById<TEntity>(Guid guid) where TEntity : class;
    }
}
