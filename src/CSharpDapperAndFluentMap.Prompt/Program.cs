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
                Console.WriteLine($"\t{category.Description}");
            }

            var people = new PersonQuery().GetAll();

            Console.WriteLine("People and categories");
            foreach (var person in people)
            {
                Console.WriteLine($"\t{person.Name} | {person.Category.Description}");
            }

            var tickets = new TicketQuery().GetAll2();

            Console.WriteLine("Tickets");
            foreach (var ticket in tickets)
            {
                Console.WriteLine($"\t{ticket.Description} | {(ticket.Priority?.Description ?? "No priority")} | {(ticket.Person?.Name ?? "No requester")} | {(ticket.Person?.Category?.Description ?? "No category")}");
            }
        }
    }
}
