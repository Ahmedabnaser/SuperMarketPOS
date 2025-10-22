using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketPOS.Abstraction.RepositoreiesInterfaces
{
    public interface Iunitofwork:IDisposable
    {
        public Task<int> CommitChangesAsync(CancellationToken cancellationToken =default);
        Task RollbackAsync();
    }
}
