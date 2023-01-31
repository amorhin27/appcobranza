using AppData.Application.Contracts.Peristence;
using AppData.Domain.Comon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Application.Contracts.IUnitWork
{
    public interface IUnitOfWork : IDisposable
    {
        //IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : BaseModel;
        Task<int> Complete();
    }
}
