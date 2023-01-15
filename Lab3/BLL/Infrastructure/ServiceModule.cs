using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.BLL.Infrastructure
{
    public class ServiceModule
    {
        private string connectionString;
        public ServiceModule(string connection = @"Server=(localdb)\mssqllocaldb;Database=Theatre;Trusted_Connection=True;")
        {
            connectionString = connection;
        }

        public DAL.Repositories.EFUnitOfWork InitDatabase()
        {
            return new DAL.Repositories.EFUnitOfWork(connectionString);
        }
    }
}
