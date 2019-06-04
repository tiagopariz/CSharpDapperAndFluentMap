using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq.Expressions;
using CSharpDapperAndFluentMap.Domain.Entities;
using Dommel;
using Microsoft.Extensions.Configuration;

namespace CSharpDapperAndFluentMap.Data.Queries
{
    public class Query<T> where T : Entity
    {
        protected readonly string ConnectionString;

        public Query()
        {
            var configurationFile = new ConfigurationBuilder()
                                            .SetBasePath(AppContext.BaseDirectory)
                                            .AddJsonFile($"appsettings.Development.json")
                                            .Build();

            ConnectionString = configurationFile
                                    .GetConnectionString("CSharpDapperAndFluentMapDb");
        }

        public virtual T GetById(Guid id)
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                return db.Get<T>(id);
            }
        }

        public virtual IEnumerable<T> GetAll()
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                return db.GetAll<T>();
            }
        }
    }
}