using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Services
{
    public interface IBackendJobService
    {
        void SendEmail();
        void UpdateDatabase();
        void SyncData();
    }
}