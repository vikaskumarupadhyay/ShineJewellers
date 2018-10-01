using SJModel.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJModel.Core
{
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        private readonly string _connectionString;
        private MainContainer _dbContext;

        public DatabaseFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DbContext Get()
        {
            return _dbContext ?? (_dbContext = new MainContainer(_connectionString));
        }

        protected override void DisposeCore()
        {
            if (_dbContext != null)
                _dbContext.Dispose();
        }
    }
}
