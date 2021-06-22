using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace quickTask.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        IPaitentsRepository Paitents { get; }
        int Complete();
    }
}
