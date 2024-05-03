using Microsoft.EntityFrameworkCore;
using SCS.BLL.Interfaces;
using SCS.DAL.Data;
using SCS.DAL.Entites;
using SCS.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCS.BLL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        //inject the AppDbContext
        private readonly AppDbContext _context;

        public IBaseRepository<User> Users { get; private set; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Users = new BaseRepository<User>(_context);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public Task SaveAsync()
        {
            return _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Commit()
        {
            throw new NotImplementedException();
        }

        public Task CommitAsync()
        {
            throw new NotImplementedException();
        }
    }

}
