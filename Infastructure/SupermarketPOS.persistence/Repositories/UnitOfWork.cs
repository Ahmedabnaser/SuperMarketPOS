using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SupermarketPOS.Abstraction.RepositoreiesInterfaces;
using SupermarketPOS.persistence.Data;
using SupermarketPOS.persistence.Repositoriess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketPOS.persistence.Repositories
{
    public class UnitOfWork : Iunitofwork
    {
        private readonly ApplicationDbContext dbContext;
        private readonly ILoggerFactory _loggerFactory;
        private bool _disposed;
          private readonly Dictionary<Type, object> _repositories = new();

        public UnitOfWork(ApplicationDbContext dbContext, ILoggerFactory loggerFactory)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _loggerFactory = loggerFactory ?? throw new ArgumentNullException(nameof(loggerFactory));
            _disposed = false;
            _repositories = new Dictionary<Type, object>();
        }
        public IGenricRepository<T> Repository<T>() where T : class
        {
            if (_repositories.ContainsKey(typeof(T)))
            {
                return (IGenricRepository<T>)_repositories[typeof(T)];
            }
            var logger = _loggerFactory.CreateLogger<GenricRepository<T>>();
            var repository = new GenricRepository<T>(dbContext, logger);
            _repositories[typeof(T)] = repository;
            return repository;
        }

        public async Task<int> CommitChangesAsync(CancellationToken cancellationToken = default)
        {
            return await dbContext.SaveChangesAsync(cancellationToken);
        }


        public async Task RollbackAsync()
        {
           await dbContext.Database.RollbackTransactionAsync();
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    dbContext.Dispose();
                }
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
