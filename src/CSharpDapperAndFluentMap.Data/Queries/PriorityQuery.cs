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
    public class PriorityQuery : Query<Priority>
    {
    }
}