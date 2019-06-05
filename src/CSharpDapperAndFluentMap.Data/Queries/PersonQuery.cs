using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using CSharpDapperAndFluentMap.Domain.Entities;
using Dommel;
using Microsoft.Extensions.Configuration;

namespace CSharpDapperAndFluentMap.Data.Queries
{
    public class PersonQuery : Query<Person>
    {
        public override IEnumerable<Person> GetAll()
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                return db.GetAll<Person, Category, Person>((person, category) =>
                {
                    person.Category = category;
                    return person;
                });
            }
        } 

        public IEnumerable<Person> GetAllWithProjects()
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                return db.GetAll<Person, PersonProject, Project, Person>((person, personProject, project) =>
                {
                    var p = project;
                    return person;
                });
            }
        }       
    }
}