using quickTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace quickTask.Contracts
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDBContext _context;
        public IPaitentsRepository Paitents { get; }


        public UnitOfWork(ApplicationDBContext loginApplicationDBContext, IPaitentsRepository paitentsRepository)
        {
            this._context = loginApplicationDBContext;
            this.Paitents = paitentsRepository;
        }
        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }

}
