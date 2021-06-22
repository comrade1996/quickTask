using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace quickTask.Contracts
{
   public interface ITypedHubClient
    {
        Task SendMessageToClient(string title, string name, string message);
    }
}
