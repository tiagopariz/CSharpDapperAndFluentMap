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
    public class PersonRepository : Repository<Person>
    {
        public PersonRepository(Query<Person> query)
            : base(query)
        {
        }
    }
}