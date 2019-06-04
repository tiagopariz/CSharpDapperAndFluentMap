using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq.Expressions;
using CSharpDapperAndFluentMap.Data.Queries;
using CSharpDapperAndFluentMap.Domain.Entities;
using Dommel;
using Microsoft.Extensions.Configuration;

namespace CSharpDapperAndFluentMap.Data.Repositories
{
    public class Repository<T> where T : Entity
    {
        protected readonly string ConnectionString;
        protected readonly Query<T> Query;

        public Repository(Query<T> query)
        {
            var configurationFile = new ConfigurationBuilder()
                                            .SetBasePath(AppContext.BaseDirectory)
                                            .AddJsonFile($"appsettings.Development.json")
                                            .Build();

            ConnectionString = configurationFile
                                    .GetConnectionString("CSharpDapperAndFluentMapDb");

            Query = query;
        }

        public void Add(T entity)
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                db.Insert(entity); 
            }
        }

        public void Remove(T entity)
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                db.Delete(entity);
            }
        }

        public void Update(T entity)
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                db.Update(entity);
            }
        }
    }
}