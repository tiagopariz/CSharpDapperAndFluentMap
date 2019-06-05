using System;
using CSharpDapperAndFluentMap.Data;
using CSharpDapperAndFluentMap.Data.Queries;

namespace CSharpDapperAndFluentMap.Prompt
{
    class Program
    {
        static void Main(string[] args)
        {
            RegisterMappings.Register();

            var categories = new CategoryQuery().GetAll();
            Console.WriteLine("Categories");
            foreach (var category in categories)
            {
                Console.WriteLine($"\t{category.Id} | {category.Description}");
            }

            var people = new PersonQuery().GetAll();
            Console.WriteLine("People and categories");
            foreach (var person in people)
            {
                Console.WriteLine($"\t{person.Id} | {person.Name} | {person.Age} | {person.CategoryId} | {person.Category.Description}");
            }

            var peopleProjects = new PersonQuery().GetAllWithProjects();
            Console.WriteLine("People and projects");
            foreach (var person in peopleProjects)
            {
                Console.WriteLine($"\t{person.Id} | {person.Name}");
                if (person.Projects != null)
                    foreach (var project in person.Projects)
                        Console.WriteLine($"\t\t{project.Id} | {project.Name}");
                else
                    Console.WriteLine($"\t\tNo projects");
            }

            var priorities = new PriorityQuery().GetAll();
            Console.WriteLine("Priorities");
            foreach (var priority in priorities)
            {
                Console.WriteLine($"\t{priority.Id} | {priority.Description}");
            }

            var tickets = new TicketQuery().GetAll();
            Console.WriteLine("Tickets");
            foreach (var ticket in tickets)
            {
                Console.WriteLine($"\t{ticket.Description} | {ticket.PersonId} | {(ticket.Person?.Name ?? "No requester")} | {(ticket.Person?.CategoryId.ToString() ?? "No category id")} | {(ticket.Person?.Category?.Description ?? "No category")} | {(ticket.PriorityId.ToString() ?? "No priority Id")} | {(ticket.Priority?.Description ?? "No Priority")}");
            }
        }
    }
}
