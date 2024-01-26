using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Services
{
    public class BackendJobService : IBackendJobService
    {
        public void SendEmail()
        {
            Console.WriteLine("Short Task");
            Console.WriteLine("Sending email...");
        }

        public void SyncData()
        {
            Console.WriteLine("Short Task");
            Console.WriteLine("Syncing data...");
        }

        public void UpdateDatabase()
        {
            Console.WriteLine("Long Task");
            Console.WriteLine("Updating database...");
        }
    }
}