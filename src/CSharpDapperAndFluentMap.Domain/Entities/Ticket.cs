using System;

namespace CSharpDapperAndFluentMap.Domain.Entities
{
    public class Ticket : Entity
    {
        public string Description { get; set; }
        public Guid PersonId { get; set; }
        public Person Person { get; set; }
        public Guid PriorityId { get; set; }
        public Priority Priority { get; set; }
        public Guid? ProjectId { get; set; }   
        public Project Project { get; set; }
    }
}