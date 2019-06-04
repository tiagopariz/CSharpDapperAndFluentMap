using System;

namespace CSharpDapperAndFluentMap.Domain.Entities
{
    public class Ticket : Entity
    {
        // public Ticket(Guid Id,
        //               string description,
        //               Guid personId,
        //               Person person,
        //               Guid priorityId,
        //               Priority priority) 
        //     : base(Id) 
        // {
        //     Description = description;
        //     PersonId = personId;
        //     Person = person;
        //     PriorityId = priorityId;
        //     Priority = priority;
        // }

        public string Description { get; set; }
        public Guid PersonId { get; set; }
        public Person Person { get; set; }
        public Guid PriorityId { get; set; }
        public Priority Priority { get; set; }        
    }
}