using SCS.BLL.Interfaces;
using SCS.DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCS.BLL.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<User> Users { get; }
        void Commit();
        Task CommitAsync();
        void Save();
        Task SaveAsync();
    }
    
}
