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
                var people = new List<Person>();
                db.GetAll<Person, PersonProject, Project, Person>((person, personProject, project) =>
                {
                    var p = people.FirstOrDefault(x => x.Id == person.Id);

                    if (p != null)
                    {
                        if (personProject != null && personProject.PersonId == p.Id)
                            p.Projects.Add(project);
                    }
                    else
                    {
                        if (personProject != null && personProject.PersonId == person.Id)
                            person.Projects.Add(project);
                        people.Add(person);                       
                    }                    

                    return person;
                });
                return people;
            }
        }       
    }
}