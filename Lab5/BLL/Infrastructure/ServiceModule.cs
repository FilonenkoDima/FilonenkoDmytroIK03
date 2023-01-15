using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;


namespace Lab3.BLL.Infrastructure
{
    public class ServiceModule : NinjectModule
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
        public override void Load()
        {
            Bind<IUnitOfWork>().To<EFUnitOfWork>().WithConstructorArgument(connectionString = @"Server=(localdb)\mssqllocaldb;Database=Theatre;Trusted_Connection=True;");
        }
    }
}
