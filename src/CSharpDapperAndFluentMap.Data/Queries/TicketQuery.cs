using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using CSharpDapperAndFluentMap.Domain.Entities;
using Dapper;
using Dommel;
using Microsoft.Extensions.Configuration;

namespace CSharpDapperAndFluentMap.Data.Queries
{
    public class TicketQuery : Query<Ticket>
    {
        public override IEnumerable<Ticket> GetAll()
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                return db.GetAll<Ticket, Person, Category, Ticket>((ticket, person, category) =>
                {
                    ticket.Person = person;
                    ticket.Person.Category = category;
                    return ticket;
                });
            }
        }

        public IEnumerable<Ticket> GetAll2()
        {
            var sql = "SELECT " +
                       "    [t].[Id], " +
                       "    [t].[Description], " +
                       "    [t].[PersonId], " +
                       "    [p].[Name], " +
                       "    [p].[CategoryId], " +
                       "    [c].[Description] As [Category], " +
                       "    [t].[PriorityId], " +
                       "    [y].[Description] As [Priority] " +
                       "FROM " +
                       "	[Ticket] AS [t] " +
                       "	INNER JOIN [Person] AS [p] ON [p].[Id] = [t].[PersonId] " +
                       "		INNER JOIN [Category] AS [c] ON [c].[Id] = [p].[CategoryId] " +
                       "	INNER JOIN [Priority] AS [y] ON [y].[Id] = [t].[PriorityId];";

            using (var db = new SqlConnection(ConnectionString))
            {
                var result = db.Query(sql);
                
                return result.Select(ticket => new Ticket
                        {
                            Id = ticket.Id ?? Guid.Empty,
                            Description = ticket.Description,
                            PersonId = ticket.PersonId,
                            Person = new Person
                            {
                                Id = ticket.PersonId,
                                Name = ticket.Name,
                                CategoryId = ticket.CategoryId,
                                Category = new Category
                                {
                                    Id = ticket.CategoryId,
                                    Description = ticket.Category,
                                }
                            },
                            PriorityId = ticket.PriorityId,
                            Priority = new Priority
                            {
                                Id = ticket.PriorityId ?? Guid.Empty,
                                Description = ticket.Priority
                            }
                });
            }
        }
    }
}